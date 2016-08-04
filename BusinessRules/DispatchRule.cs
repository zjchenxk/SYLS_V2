using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class DispatchRule
    {
        /// <summary>
        /// 新增调度单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listDeliverPlan"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertDispatchBill(DispatchBill bill, List<DispatchBillDeliverPlan> listDeliverPlan, List<DispatchBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nDispatchBillId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //新增计划数据
                        nDispatchBillId = dao.InsertDispatchBill(bill, nOpStaffId, strOpStaffName, out strErrText);
                        if (nDispatchBillId <= 0)
                            return 0;

                        //新增计划数据
                        foreach (DispatchBillDeliverPlan deliverPlan in listDeliverPlan)
                        {
                            deliverPlan.DispatchBillId = nDispatchBillId;

                            if (!dao.InsertDispatchBillDeliverPlan(deliverPlan, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }

                        //新增货物数据
                        foreach (DispatchBillGoods goods in listGoods)
                        {
                            goods.DispatchBillId = nDispatchBillId;

                            if (!dao.InsertDispatchBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }

                        //校验调度单数据
                        if (!dao.CheckDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return 0;
                        }
                    }
                    transScope.Complete();
                }
                return nDispatchBillId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 修改调度单
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listDeliverPlan"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDispatchBill(DispatchBill bill, List<DispatchBillDeliverPlan> listDeliverPlan, List<DispatchBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        #region 处理计划和货物数据

                        int totalOldPackages = 0;
                        decimal totalOldTunnages = 0;
                        decimal totalOldPiles = 0;
                        decimal totalOldTenThousands = 0;
                        decimal totalOldTransportCharges = 0;

                        foreach (DispatchBillDeliverPlan newPlan in listDeliverPlan)
                        {
                            //读取当前调度计划原数据
                            DispatchBillDeliverPlan oldPlan = dao.LoadDispatchBillDeliverPlan(newPlan.DispatchBillId, newPlan.PlanId, nOpStaffId, strOpStaffName, out strErrText);
                            if (oldPlan == null)
                            {
                                return false;
                            }
                            totalOldPackages += oldPlan.Packages;
                            totalOldTunnages += oldPlan.Tunnages;
                            totalOldPiles += oldPlan.Piles;
                            totalOldTenThousands += oldPlan.TenThousands;
                            totalOldTransportCharges += oldPlan.TransportCharges;

                            //修改当前调度计划新数据
                            if (!dao.UpdateDispatchBillDeliverPlan(newPlan, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //删除当前调度计划原货物数据
                            if (!dao.DeleteDispatchBillDeliverPlanAllGoods(newPlan.DispatchBillId, newPlan.PlanId, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //新增当前调度计划货物新数据
                            foreach (DispatchBillGoods goods in listGoods)
                            {
                                if (goods.DispatchBillId == newPlan.DispatchBillId && goods.PlanId == newPlan.PlanId)
                                {
                                    if (!dao.InsertDispatchBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                        #endregion

                        #region 处理调度单数据

                        //读取调度单原数据
                        DispatchBill oldBill = dao.LoadDispatchBill(bill.Id, nOpStaffId, strOpStaffName, out  strErrText);
                        if (oldBill == null)
                        {
                            return false;
                        }
                        bill.TotalPackages = oldBill.TotalPackages - totalOldPackages + bill.TotalPackages;
                        bill.TotalTunnages = oldBill.TotalTunnages - totalOldTunnages + bill.TotalTunnages;
                        bill.TotalPiles = oldBill.TotalPiles - totalOldPiles + bill.TotalPiles;
                        bill.TotalTenThousands = oldBill.TotalTenThousands - totalOldTenThousands + bill.TotalTenThousands;
                        bill.TotalTransportCharges = oldBill.TotalTransportCharges - totalOldTransportCharges + bill.TotalTransportCharges;

                        if (!dao.UpdateDispatchBill(bill, nOpStaffId, strOpStaffName, out  strErrText))
                        {
                            return false;
                        }

                        #endregion

                        #region 校验调度单数据

                        if (!dao.CheckDispatchBill(bill.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        #endregion
                    }
                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除指定的调度单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //删除调度单数据
                        if (!dao.DeleteDispatchBill(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除调度计划数据
                        if (!dao.DeleteDispatchBillDeliverPlans(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除调度货物数据
                        if (!dao.DeleteDispatchBillAllGoods(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }
                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 修改调度单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listPlan"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDispatchBill(DispatchBill data, List<DispatchBillDeliverPlan> listPlan, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        #region 修改调度单数据
                        DispatchBill oldData = dao.LoadDispatchBill(data.Id, nOpStaffId, strOpStaffName, out  strErrText);
                        if (oldData == null)
                        {
                            return false;
                        }
                        data.TotalPackages = oldData.TotalPackages;
                        data.TotalTunnages = oldData.TotalTunnages;
                        data.TotalPiles = oldData.TotalPiles;
                        data.TotalTenThousands = oldData.TotalTenThousands;
                        data.TotalTransportCharges = oldData.TotalTransportCharges;

                        if (!dao.UpdateDispatchBill(data, nOpStaffId, strOpStaffName, out  strErrText))
                        {
                            return false;
                        }
                        #endregion

                        #region 修改调度计划数据
                        List<DispatchBillDeliverPlan> listOldPlan = dao.LoadDispatchBillDeliverPlans(data.Id, nOpStaffId, strOpStaffName, out  strErrText);
                        if (listOldPlan == null)
                        {
                            return false;
                        }
                        if (!dao.DeleteDispatchBillDeliverPlans(data.Id, nOpStaffId, strOpStaffName, out  strErrText))
                        {
                            return false;
                        }
                        foreach (DispatchBillDeliverPlan oldPlan in listOldPlan)
                        {
                            DispatchBillDeliverPlan newPlan = listPlan.Find(delegate(DispatchBillDeliverPlan p) { return p.PlanId == oldPlan.PlanId; });
                            if (newPlan != null)
                            {
                                oldPlan.ReceiveType = newPlan.ReceiveType;
                            }

                            if (!dao.InsertDispatchBillDeliverPlan(oldPlan, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                        #endregion

                        #region 修改调度货物数据
                        List<DispatchBillGoods> listOldGoods = dao.LoadDispatchBillAllGoods(data.Id, nOpStaffId, strOpStaffName, out strErrText);
                        if (listOldGoods == null)
                        {
                            return false;
                        }
                        if (!dao.DeleteDispatchBillAllGoods(data.Id, nOpStaffId, strOpStaffName, out  strErrText))
                        {
                            return false;
                        }
                        foreach (DispatchBillGoods goods in listOldGoods)
                        {
                            if (!dao.InsertDispatchBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                        #endregion

                        #region 校验调度单数据
                        if (!dao.CheckDispatchBill(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                        #endregion
                    }
                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除指定调度单编码和计划编码的已调度计划数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchedPlan(long nDispatchBillId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        #region 删除计划和货物数据
                        int totalPackages = 0;
                        decimal totalTunnages = 0;
                        decimal totalPiles = 0;
                        decimal totalTenThousands = 0;
                        decimal totalTransportCharges = 0;

                        //读取当前调度计划数据
                        DispatchBillDeliverPlan deliverPlan = dao.LoadDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                        if (deliverPlan == null)
                        {
                            return false;
                        }
                        totalPackages = deliverPlan.Packages;
                        totalTunnages = deliverPlan.Tunnages;
                        totalPiles = deliverPlan.Piles;
                        totalTenThousands = deliverPlan.TenThousands;
                        totalTransportCharges = deliverPlan.TransportCharges;

                        //删除当前调度计划数据
                        if (!dao.DeleteDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除当前调度计划货物数据
                        if (!dao.DeleteDispatchBillDeliverPlanAllGoods(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                        #endregion

                        #region 修改调度单数据
                        //读取调度单原数据
                        DispatchBill bill = dao.LoadDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out  strErrText);
                        if (bill == null)
                        {
                            return false;
                        }
                        bill.TotalPackages -= totalPackages;
                        bill.TotalTunnages -= totalTunnages;
                        bill.TotalPiles -= totalPiles;
                        bill.TotalTenThousands -= totalTenThousands;
                        bill.TotalTransportCharges -= totalTransportCharges;

                        //如果调度单为空（即计划已经全部删除了），则同时删除调度单数据
                        if (bill.TotalPackages == 0 && bill.TotalPiles == 0)
                        {
                            if (!dao.DeleteDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out  strErrText))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!dao.UpdateDispatchBill(bill, nOpStaffId, strOpStaffName, out  strErrText))
                            {
                                return false;
                            }

                            if (!dao.CheckDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                        #endregion
                    }
                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 提交指定调度单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitDispatchBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    #region 提交调度单

                    long nContractId = 0;
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //校验调度单数据
                        if (!dao.CheckDispatchBill(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //提交调度单数据
                        if (!dao.SubmitDispatchBill(nId, out nContractId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    #endregion

                    #region 提交打印特殊合同

                    if (nContractId > 0)
                    {
                        #region 修改合同打印状态

                        using (ContractDAO dao = new ContractDAO())
                        {
                            if (!dao.SubmitPrintContract(nContractId, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }

                        #endregion

                        #region 读取合同价格最大超出比例和超出金额

                        decimal decOverPercentage = 0;
                        decimal decOverAmount = 0;

                        using (ContractDAO dao = new ContractDAO())
                        {
                            //读取合同价格超出比例
                            decOverPercentage = dao.LoadContractPriceOverPercentage(nContractId, nOpStaffId, strOpStaffName, out strErrText);

                            //读取合同价格超出金额
                            decOverAmount = dao.LoadContractPriceOverAmount(nContractId, nOpStaffId, strOpStaffName, out strErrText);
                        }

                        #endregion

                        #region 处理合同价格审批流程

                        int nApproveFlowStepNum = 0;
                        string strApproveFlowStepName = string.Empty;
                        long nApproverId = 0;
                        string strApproverName = string.Empty;

                        using (FlowDAO dao = new FlowDAO())
                        {
                            List<ApproveFlowStep> listStep = dao.LoadApproveFlowStepsByFlowType(InnoSoft.LS.Resources.Options.PriceApproveFlow, nOpStaffId, strOpStaffName, out strErrText);
                            if (listStep == null)
                            {
                                return false;
                            }
                            if (listStep.Count > 0)
                            {
                                int nStepIndex = 0;
                                for (nStepIndex = 0; nStepIndex < listStep.Count; nStepIndex++)
                                {
                                    //获取审批步骤数据
                                    long nStepId = listStep[nStepIndex].Id;
                                    string strStepName = listStep[nStepIndex].StepName;
                                    int nStepNum = listStep[nStepIndex].StepNum;
                                    long nDisposerId = listStep[nStepIndex].DisposerId;
                                    string strDisposerName = listStep[nStepIndex].DisposerName;
                                    string strConditionExpression = listStep[nStepIndex].ConditionExpression;

                                    //读取审批步骤条件数据
                                    List<ApproveFlowStepCondition> listCondition = dao.LoadApproveFlowStepConditionsByStepId(nStepId, nOpStaffId, strOpStaffName, out strErrText);
                                    if (listCondition == null)
                                    {
                                        return false;
                                    }

                                    //创建条件运算结果中间变量
                                    string[] arrayIntermediateResults = new string[listCondition.Count + 1];//为什么加1？因为条件序号是从1开始的

                                    //对每个条件进行运算，运算结果存入中间变量中
                                    int nConditionIndex = 0;
                                    for (nConditionIndex = 0; nConditionIndex < listCondition.Count; nConditionIndex++)
                                    {
                                        //获取条件数据
                                        string strFieldName = listCondition[nConditionIndex].FieldName;
                                        string strCompareOperator = listCondition[nConditionIndex].CompareOperator;
                                        string strFieldValue = listCondition[nConditionIndex].FieldValue;

                                        if (strFieldName == InnoSoft.LS.Resources.Options.OverPercentage)
                                        {
                                            decimal decFieldValue = decimal.Parse(strFieldValue);

                                            if (strCompareOperator == InnoSoft.LS.Resources.Options.Equal)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverPercentage == decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.GreaterThanOrEqual)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverPercentage >= decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.LessThanOrEqual)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverPercentage <= decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.GreaterThan)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverPercentage > decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.LessThan)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverPercentage < decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.NotEqual)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverPercentage != decFieldValue)).ToString();
                                            }
                                            else
                                            {
                                                strErrText = string.Format(InnoSoft.LS.Resources.Strings.OverPercentageConditionNotSupportOperator, strCompareOperator);
                                                return false;
                                            }
                                        }
                                        else if (strFieldName == InnoSoft.LS.Resources.Options.OverAmount)
                                        {
                                            decimal decFieldValue = decimal.Parse(strFieldValue);

                                            if (strCompareOperator == InnoSoft.LS.Resources.Options.Equal)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverAmount == decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.GreaterThanOrEqual)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverAmount >= decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.LessThanOrEqual)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverAmount <= decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.GreaterThan)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverAmount > decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.LessThan)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverAmount < decFieldValue)).ToString();
                                            }
                                            else if (strCompareOperator == InnoSoft.LS.Resources.Options.NotEqual)
                                            {
                                                arrayIntermediateResults[nConditionIndex + 1] = ((bool)(decOverAmount != decFieldValue)).ToString();
                                            }
                                            else
                                            {
                                                strErrText = string.Format(InnoSoft.LS.Resources.Strings.OverAmountConditionNotSupportOperator, strCompareOperator);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            strErrText = string.Format(InnoSoft.LS.Resources.Strings.NotSupportApproveCondition, strFieldName);
                                            return false;
                                        }
                                    }

                                    //对所有条件运算的结果进行综合判断
                                    bool bFinalResult;
                                    if (listCondition.Count == 0)
                                    {
                                        bFinalResult = true;
                                    }
                                    else if (listCondition.Count == 1)
                                    {
                                        bFinalResult = bool.Parse(arrayIntermediateResults[1]);
                                    }
                                    else
                                    {
                                        //根据条件组合表达式计算最终结果
                                        string strFinalConditionExpression = string.Format(strConditionExpression, arrayIntermediateResults);
                                        bFinalResult = Utils.CalculateApproveFlowStepConditionExpression(strFinalConditionExpression);
                                    }

                                    //根据最终结果决定下一个步骤
                                    if (!bFinalResult)
                                    {
                                        //如果不执行当前步骤，则继续匹配下一步骤
                                        continue;
                                    }
                                    else
                                    {
                                        //设置当前审批人
                                        nApproveFlowStepNum = nStepNum;
                                        strApproveFlowStepName = strStepName;
                                        nApproverId = nDisposerId;
                                        strApproverName = strDisposerName;

                                        break;
                                    }
                                }
                            }
                        }

                        //修改合同审批人和审批状态
                        using (ContractDAO dao = new ContractDAO())
                        {
                            if (!dao.UpdateContractApprover(nContractId, nApproveFlowStepNum, strApproveFlowStepName, nApproverId, strApproverName, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //修改合同状态为“已审批”
                            if (nApproverId == 0)
                            {
                                if (!dao.UpdateContractApproveState(nContractId, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }

                        if (nApproverId > 0)
                        {
                            strErrText = string.Format(InnoSoft.LS.Resources.Strings.ContractNeedApprove, strApproverName);
                        }

                        #endregion
                    }

                    #endregion

                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

    }
}
