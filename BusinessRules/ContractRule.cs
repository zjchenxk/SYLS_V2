using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class ContractRule
    {
        /// <summary>
        /// 新增合同数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listPlan"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertContract(Contract data, List<ContractDeliverPlan> listPlan, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nContractId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        //新增合同数据
                        nContractId = dao.InsertContract(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nContractId <= 0)
                            return 0;

                        //新增合同计划数据
                        foreach (ContractDeliverPlan plan in listPlan)
                        {
                            plan.ContractId = nContractId;

                            if (!dao.InsertContractDeliverPlan(plan, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }

                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //检查调度单数据
                        if (!dao.CheckDispatchBill(data.DispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return 0;
                        }
                    }
                    transScope.Complete();
                }
                return nContractId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 修改合同发货数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractDeliverPlan(ContractDeliverPlan data, List<ContractGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        if (!dao.UpdateContractDeliverPlan(data, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        foreach (ContractGoods goods in listGoods)
                        {
                            if (!dao.UpdateContractGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }

                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //检查调度单数据
                        if (!dao.CheckDispatchBill(data.DispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除合同数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteContract(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        //删除合同数据
                        if (!dao.DeleteContract(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除合同计划数据
                        if (!dao.DeleteContractDeliverPlans(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 提交打印合同数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool SubmitPrintContract(long nId, long nOpStaffId, string strOpStaffName, out string strMessage)
        {
            strMessage = string.Empty;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    #region 修改合同打印状态

                    using (ContractDAO dao = new ContractDAO())
                    {
                        if (!dao.SubmitPrintContract(nId, nOpStaffId, strOpStaffName, out strMessage))
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
                        decOverPercentage = dao.LoadContractPriceOverPercentage(nId, nOpStaffId, strOpStaffName, out strMessage);

                        //读取合同价格超出金额
                        decOverAmount = dao.LoadContractPriceOverAmount(nId, nOpStaffId, strOpStaffName, out strMessage);
                    }

                    #endregion

                    #region 处理合同价格审批流程

                    int nApproveFlowStepNum = 0;
                    string strApproveFlowStepName = string.Empty;
                    long nApproverId = 0;
                    string strApproverName = string.Empty;

                    using (FlowDAO dao = new FlowDAO())
                    {
                        List<ApproveFlowStep> listStep = dao.LoadApproveFlowStepsByFlowType(InnoSoft.LS.Resources.Options.PriceApproveFlow, nOpStaffId, strOpStaffName, out strMessage);
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
                                List<ApproveFlowStepCondition> listCondition = dao.LoadApproveFlowStepConditionsByStepId(nStepId, nOpStaffId, strOpStaffName, out strMessage);
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
                                            strMessage = string.Format(InnoSoft.LS.Resources.Strings.OverPercentageConditionNotSupportOperator, strCompareOperator);
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
                                            strMessage = string.Format(InnoSoft.LS.Resources.Strings.OverAmountConditionNotSupportOperator, strCompareOperator);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        strMessage = string.Format(InnoSoft.LS.Resources.Strings.NotSupportApproveCondition, strFieldName);
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
                        if (!dao.UpdateContractApprover(nId, nApproveFlowStepNum, strApproveFlowStepName, nApproverId, strApproverName, nOpStaffId, strOpStaffName, out strMessage))
                        {
                            return false;
                        }

                        //修改合同状态为“已审批”
                        if (nApproverId == 0)
                        {
                            if (!dao.UpdateContractApproveState(nId, nOpStaffId, strOpStaffName, out strMessage))
                            {
                                return false;
                            }
                        }
                    }

                    if (nApproverId > 0)
                    {
                        strMessage = string.Format(InnoSoft.LS.Resources.Strings.ContractNeedApprove, strApproverName);
                    }

                    #endregion

                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strMessage = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 审批合同价格数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="listPlan"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool ApproveContract(long nId, List<ContractDeliverPlan> listPlan, long nOpStaffId, string strOpStaffName, out string strMessage)
        {
            strMessage = string.Empty;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    #region 修改审批价格数据

                    Contract data = null;
                    using (ContractDAO dao = new ContractDAO())
                    {
                        //读取合同数据
                        data = dao.LoadContract(nId, nOpStaffId, strOpStaffName, out strMessage);
                        if (data == null)
                        {
                            return false;
                        }

                        //修改合同计划数据
                        foreach (ContractDeliverPlan plan in listPlan)
                        {
                            if (!dao.UpdateContractDeliverPlanApprovedTransportPrice(plan, nOpStaffId, strOpStaffName, out strMessage))
                            {
                                return false;
                            }
                        }
                    }

                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //检查调度单数据
                        if (!dao.CheckDispatchBill(data.DispatchBillId, nOpStaffId, strOpStaffName, out strMessage))
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
                        decOverPercentage = dao.LoadContractPriceOverPercentage(nId, nOpStaffId, strOpStaffName, out strMessage);

                        //读取合同价格超出金额
                        decOverAmount = dao.LoadContractPriceOverAmount(nId, nOpStaffId, strOpStaffName, out strMessage);
                    }

                    #endregion

                    #region 处理合同价格审批流程

                    int nCurrentStepNum = data.ApproveFlowStepNum;
                    int nApproveFlowStepNum = 0;
                    string strApproveFlowStepName = string.Empty;
                    long nApproverId = 0;
                    string strApproverName = string.Empty;

                    using (FlowDAO dao = new FlowDAO())
                    {
                        List<ApproveFlowStep> listStep = dao.LoadApproveFlowNextStepsByFlowTypeAndStepNum(InnoSoft.LS.Resources.Options.PriceApproveFlow, nCurrentStepNum, nOpStaffId, strOpStaffName, out strMessage);
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
                                List<ApproveFlowStepCondition> listCondition = dao.LoadApproveFlowStepConditionsByStepId(nStepId, nOpStaffId, strOpStaffName, out strMessage);
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
                                            strMessage = string.Format(InnoSoft.LS.Resources.Strings.OverPercentageConditionNotSupportOperator, strCompareOperator);
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
                                            strMessage = string.Format(InnoSoft.LS.Resources.Strings.OverAmountConditionNotSupportOperator, strCompareOperator);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        strMessage = string.Format(InnoSoft.LS.Resources.Strings.NotSupportApproveCondition, strFieldName);
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
                        if (!dao.UpdateContractApprover(nId, nApproveFlowStepNum, strApproveFlowStepName, nApproverId, strApproverName, nOpStaffId, strOpStaffName, out strMessage))
                        {
                            return false;
                        }

                        //修改合同状态为“已审批”
                        if (nApproverId == 0)
                        {
                            if (!dao.UpdateContractApproveState(nId, nOpStaffId, strOpStaffName, out strMessage))
                            {
                                return false;
                            }
                        }
                    }

                    if (nApproverId > 0)
                    {
                        strMessage = string.Format(InnoSoft.LS.Resources.Strings.ContractNeedApprove, strApproverName);
                    }

                    #endregion

                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strMessage = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 新增冲帐记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listDetail"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertContractReverse(ContractReverse data, List<ContractReverseDetail> listDetail, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nReverseId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        //新增冲帐数据
                        nReverseId = dao.InsertContractReverse(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nReverseId <= 0)
                            return 0;

                        //新增冲帐明细数据
                        foreach (ContractReverseDetail detail in listDetail)
                        {
                            detail.ReverseId = nReverseId;

                            if (!dao.InsertContractReverseDetail(detail, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nReverseId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 合同罚款处理
        /// </summary>
        /// <param name="listContract"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool FineContracts(List<Contract> listContract, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            strErrText = string.Empty;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        //修改合同罚款金额数据
                        foreach (Contract contract in listContract)
                        {
                            if (!dao.UpdateContractFineAmount(contract.Id, contract.FineAmount, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
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
        /// 合同退回修改
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool ReturnModifyContract(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    //修改合同数据
                    Contract data = null;
                    using (ContractDAO dao = new ContractDAO())
                    {
                        data = dao.LoadContract(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return false;
                        }

                        if (!dao.ReturnModifyContract(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    //检查调度单数据
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        if (!dao.CheckDispatchBill(data.DispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除冲帐记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteContractReverse(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        if (!dao.DeleteContractReverse(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        if (!dao.DeleteContractReverseDetails(nId, nOpStaffId, strOpStaffName, out strErrText))
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

    }
}
