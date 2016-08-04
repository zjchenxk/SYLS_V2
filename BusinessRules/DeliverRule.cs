using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class DeliverRule
    {
        /// <summary>
        /// 修改出仓单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="decTransportCharges">运费</param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateShipmentBill(long nId, decimal decTransportCharges, List<ShipmentBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                strErrText = string.Empty;
                long nDispatchBillId = 0;
                long nPlanId = 0;
                string strOutType = string.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    //修改出仓单货物数据
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        ShipmentBill bill = dao.LoadShipmentBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }
                        nDispatchBillId = bill.DispatchBillId;
                        nPlanId = bill.PlanId;
                        strOutType = bill.OutType;

                        foreach (ShipmentBillGoods goods in listGoods)
                        {
                            if (!dao.UpdateShipmentBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }

                    //如果是划拨出库，则需要修改入库单
                    if (strOutType == InnoSoft.LS.Resources.Options.AllocateGoods)
                    {
                        using (StockDAO dao = new StockDAO())
                        {
                            //读取入库单编码
                            EnterWarehouseBill bill = dao.LoadEnterWarehouseBillByPlanId(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                            if (bill == null)
                            {
                                return false;
                            }
                            long nEnterWarehouseBillId = bill.Id;

                            //读取入库单货物数据
                            List<EnterWarehouseBillGoods> listEnterWarehouseBillGoods = dao.LoadEnterWarehouseBillAllGoods(nEnterWarehouseBillId, nOpStaffId, strOpStaffName, out strErrText);
                            if (listEnterWarehouseBillGoods == null)
                            {
                                return false;
                            }
                            foreach (EnterWarehouseBillGoods goods in listEnterWarehouseBillGoods)
                            {
                                int nNewPackages = 0;
                                decimal decNewTunnages = 0;
                                decimal decNewPiles = 0;
                                decimal decNewTenThousands = 0;

                                string[] strShipmentBillGoodsIds = goods.ShipmentBillGoodsIds.Split(',');
                                foreach (string strShipmentBillGoodsId in strShipmentBillGoodsIds)
                                {
                                    ShipmentBillGoods goods1 = listGoods.Find(delegate(ShipmentBillGoods g) { return g.Id == long.Parse(strShipmentBillGoodsId); });
                                    if (goods1 == null)
                                    {
                                        strErrText = InnoSoft.LS.Resources.Strings.NotFoundShipmentBillGoodsForEnterWarehouseBill;
                                        return false;
                                    }
                                    nNewPackages += goods1.Packages;
                                    decNewTunnages += goods1.Tunnages;
                                    decNewPiles += goods1.Piles;
                                    decNewTenThousands += goods1.TenThousands;
                                }
                                goods.Packages = nNewPackages;
                                goods.Tunnages = decNewTunnages;
                                goods.Piles = decNewPiles;
                                goods.TenThousands = decNewTenThousands;

                                if (!dao.UpdateEnterWarehouseBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    //如果是发货出库，则需要修改调度记录数据
                    if (strOutType == InnoSoft.LS.Resources.Options.DeliverGoods)
                    {
                        using (DispatchDAO dao = new DispatchDAO())
                        {
                            //读取调度单计划数据
                            DispatchBillDeliverPlan plan = dao.LoadDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                            if (plan == null)
                            {
                                return false;
                            }
                            decimal decOldTransportCharges = plan.TransportCharges;

                            //修改调度单计划数据
                            plan.TransportCharges = decTransportCharges;
                            if (!dao.UpdateDispatchBillDeliverPlan(plan, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //读取调度单数据
                            DispatchBill bill = dao.LoadDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText);
                            if (bill == null)
                            {
                                return false;
                            }

                            //修改调度单数据
                            bill.TotalTransportCharges = bill.TotalTransportCharges - decOldTransportCharges + decTransportCharges;
                            if (!dao.UpdateDispatchBill(bill, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //校验调度单数据
                            if (!dao.CheckDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 取消出仓单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CancelShipmentBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                strErrText = string.Empty;
                long nDispatchBillId = 0;
                long nPlanId = 0;
                string strOutType = string.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    //删除出仓单数据
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        //读取出仓单数据
                        ShipmentBill bill = dao.LoadShipmentBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }
                        nDispatchBillId = bill.DispatchBillId;
                        nPlanId = bill.PlanId;
                        strOutType = bill.OutType;

                        //删除出仓单数据
                        if (!dao.DeleteShipmentBill(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除出仓单货物数据
                        if (!dao.DeleteShipmentBillAllGoods(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    //删除出库单数据
                    using (StockDAO dao = new StockDAO())
                    {
                        //读取出库单数据
                        OutWarehouseBill bill = dao.LoadOutWarehouseBillByShipmentBillId(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }

                        //删除出库单数据
                        if (!dao.DeleteOutWarehouseBill(bill.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除出库单货物数据
                        if (!dao.DeleteOutWarehouseBillAllGoods(bill.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    //如果是划拨出库，则删除入库单数据
                    if (strOutType == InnoSoft.LS.Resources.Options.AllocateGoods)
                    {
                        using (StockDAO dao = new StockDAO())
                        {
                            //读取入库单编码
                            EnterWarehouseBill bill = dao.LoadEnterWarehouseBillByPlanId(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                            if (bill == null)
                            {
                                return false;
                            }

                            //删除入库单货物数据
                            if (!dao.DeleteEnterWarehouseBillAllGoods(bill.Id, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //删除入库单数据
                            if (!dao.DeleteEnterWarehouseBill(bill.Id, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }

                    //如果是发货出库，则修改调度记录数据
                    if (strOutType == InnoSoft.LS.Resources.Options.DeliverGoods)
                    {
                        using (DispatchDAO dao = new DispatchDAO())
                        {
                            //读取调度单计划数据
                            DispatchBillDeliverPlan plan = dao.LoadDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                            if (plan == null)
                            {
                                return false;
                            }

                            //读取调度单数据
                            DispatchBill bill = dao.LoadDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText);
                            if (bill == null)
                            {
                                return false;
                            }

                            //修改或删除调度单数据
                            bill.TotalPackages = bill.TotalPackages - plan.Packages;
                            bill.TotalTunnages = bill.TotalTunnages - plan.Tunnages;
                            bill.TotalPiles = bill.TotalPiles - plan.Piles;
                            bill.TotalTenThousands = bill.TotalTenThousands - plan.TenThousands;
                            bill.TotalTransportCharges = bill.TotalTransportCharges - plan.TransportCharges;

                            if (bill.TotalPackages == 0 && bill.TotalTunnages == 0 && bill.TotalPiles == 0 && bill.TotalTenThousands == 0)
                            {
                                if (!dao.DeleteDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (!dao.UpdateDispatchBill(bill, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }

                            //删除调度单计划数据
                            if (!dao.DeleteDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //删除调度计划货物数据
                            if (!dao.DeleteDispatchBillDeliverPlanAllGoods(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }

                            //校验调度单数据
                            if (bill.TotalPackages != 0 || bill.TotalTunnages != 0 || bill.TotalPiles != 0 || bill.TotalTenThousands != 0)
                            {
                                if (!dao.CheckDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    //如果是划拨出库，则直接取消发货计划
                    if (strOutType == InnoSoft.LS.Resources.Options.AllocateGoods)
                    {
                        using (PlanDAO dao = new PlanDAO())
                        {
                            if (!dao.CancelDeliverPlan(nPlanId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 修改送货单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="decTransportCharges">运费</param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverBill(long nId, decimal decTransportCharges, List<DeliverBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                strErrText = string.Empty;
                long nDispatchBillId = 0;
                long nPlanId = 0;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        //读取送货单数据
                        DeliverBill bill = dao.LoadDeliverBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }
                        nDispatchBillId = bill.DispatchBillId;
                        nPlanId = bill.PlanId;

                        //修改货物数据
                        foreach (DeliverBillGoods goods in listGoods)
                        {
                            if (!dao.UpdateDeliverBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }

                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //读取调度单计划数据
                        DispatchBillDeliverPlan plan = dao.LoadDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                        if (plan == null)
                        {
                            return false;
                        }
                        decimal decOldTransportCharges = plan.TransportCharges;

                        //修改调度单计划数据
                        plan.TransportCharges = decTransportCharges;
                        if (!dao.UpdateDispatchBillDeliverPlan(plan, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //读取调度单数据
                        DispatchBill bill = dao.LoadDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }

                        //修改调度单数据
                        bill.TotalTransportCharges = bill.TotalTransportCharges - decOldTransportCharges + decTransportCharges;
                        if (!dao.UpdateDispatchBill(bill, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //校验调度单数据
                        if (!dao.CheckDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 取消送货单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CancelDeliverBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                strErrText = string.Empty;
                long nShipmentBillId = 0;
                long nDispatchBillId = 0;
                long nPlanId = 0;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        //读取送货单数据
                        DeliverBill bill = dao.LoadDeliverBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }
                        nShipmentBillId = bill.ShipmentBillId;
                        nDispatchBillId = bill.DispatchBillId;
                        nPlanId = bill.PlanId;

                        //删除送货单数据
                        if (!dao.DeleteDeliverBill(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除送货单货物数据
                        if (!dao.DeleteDeliverBillAllGoods(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除出仓单数据
                        if (!dao.DeleteShipmentBill(nShipmentBillId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除出仓单货物数据
                        if (!dao.DeleteShipmentBillAllGoods(nShipmentBillId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    using (StockDAO dao = new StockDAO())
                    {
                        //读取出库单数据
                        OutWarehouseBill bill = dao.LoadOutWarehouseBillByShipmentBillId(nShipmentBillId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }

                        //删除出库单数据
                        if (!dao.DeleteOutWarehouseBill(bill.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除出库单货物数据
                        if (!dao.DeleteOutWarehouseBillAllGoods(bill.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        //读取调度单计划数据
                        DispatchBillDeliverPlan plan = dao.LoadDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                        if (plan == null)
                        {
                            return false;
                        }

                        //读取调度单数据
                        DispatchBill bill = dao.LoadDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }

                        //修改或删除调度单数据
                        bill.TotalPackages = bill.TotalPackages - plan.Packages;
                        bill.TotalTunnages = bill.TotalTunnages - plan.Tunnages;
                        bill.TotalPiles = bill.TotalPiles - plan.Piles;
                        bill.TotalTenThousands = bill.TotalTenThousands - plan.TenThousands;
                        bill.TotalTransportCharges = bill.TotalTransportCharges - plan.TransportCharges;

                        if (bill.TotalPackages == 0 && bill.TotalTunnages == 0 && bill.TotalPiles == 0 && bill.TotalTenThousands == 0)
                        {
                            if (!dao.DeleteDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!dao.UpdateDispatchBill(bill, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }

                        //删除调度单计划数据
                        if (!dao.DeleteDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除调度计划货物数据
                        if (!dao.DeleteDispatchBillDeliverPlanAllGoods(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //校验调度单数据
                        if (bill.TotalPackages != 0 || bill.TotalTunnages != 0 || bill.TotalPiles != 0 || bill.TotalTenThousands != 0)
                        {
                            if (!dao.CheckDispatchBill(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 提交打印送货单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitPrintDeliverBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    #region 提交送货单

                    long nContractId = 0;
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        if (!dao.SubmitPrintDeliverBill(nId, out nContractId, nOpStaffId, strOpStaffName, out strErrText))
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
