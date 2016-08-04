using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class PlanSystem : MarshalByRefObject
    {
        /// <summary>
        /// 读取待提交的计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadSubmitDeliverPlans(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadSubmitDeliverPlans(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取待客户审批的纸发货计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadCustomerApproveDeliverPlans(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadCustomerApproveDeliverPlans(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定计划数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverPlan LoadDeliverPlan(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DeliverPlan dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadDeliverPlan(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定计划的所有货物数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlanGoods> LoadDeliverPlanAllGoods(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlanGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadDeliverPlanAllGoods(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增发货计划
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertDeliverPlan(DeliverPlan data, List<DeliverPlanGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            PlanRule rule = new PlanRule();
            return rule.InsertDeliverPlan(data, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 修改发货计划
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverPlan(DeliverPlan data, List<DeliverPlanGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            PlanRule rule = new PlanRule();
            return rule.UpdateDeliverPlan(data, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 复制发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long CopyDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nPlanId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        nPlanId = dao.CopyDeliverPlan(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (nPlanId <= 0)
                        {
                            return 0;
                        }
                    }
                    transScope.Complete();
                }
                return nPlanId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 删除发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        if (!dao.DeleteDeliverPlan(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 提交发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="bIsAgreed"></param>
        /// <param name="strApproveComment"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool SubmitDeliverPlan(long nId, bool bIsAgreed, string strApproveComment, long nOpStaffId, string strOpStaffName, out string strMessage)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        if (!dao.SubmitDeliverPlan(nId, bIsAgreed, strApproveComment, nOpStaffId, strOpStaffName, out strMessage))
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
                strMessage = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 客户同意计划
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CustomerAgreeDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        if (!dao.CustomerAgreeDeliverPlan(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 客户不同意计划
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="strDisagreeOpinion"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CustomerDisagreeDeliverPlan(long nId, string strDisagreeOpinion, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        if (!dao.CustomerDisagreeDeliverPlan(nId, strDisagreeOpinion, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 读取待审批的纸发货计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadApproveDeliverPlans(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadApproveDeliverPlans(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据综合条件读取发货计划数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strShipmentNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strDeliverType"></param>
        /// <param name="strReceiverName"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strGoodsNo"></param>
        /// <param name="strPlanNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadDeliverPlansByConditions(string strStartTime, string strEndTime, string strCustomerName, string strShipmentNo, string strDeliveryNo, string strDeliverType, string strReceiverName, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarNo, string strGoodsNo, string strPlanNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadDeliverPlansByConditions(strStartTime, strEndTime, strCustomerName, strShipmentNo, strDeliveryNo, strDeliverType, strReceiverName, strStartCountry, strStartProvince, strStartCity, strDestCountry, strDestProvince, strDestCity, strCarNo, strGoodsNo, strPlanNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取全部待调度发货计划数据
        /// </summary>
        /// <param name="strOrganId"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strShipmentNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strReceiverName"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strArrivalTime"></param>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadDispatchDeliverPlans(string strOrganId, string strCustomerName, string strShipmentNo, string strDeliveryNo, string strReceiverName, string strDestCountry, string strDestProvince, string strDestCity, string strWarehouse, string strArrivalTime, string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadDispatchDeliverPlans(strOrganId, strCustomerName, strShipmentNo, strDeliveryNo, strReceiverName, strDestCountry, strDestProvince, strDestCity, strWarehouse, strArrivalTime, strCarNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取外地来货计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadForeignDeliverPlans(int nPageIndex, int nRowCount, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadForeignDeliverPlans(nPageIndex, nRowCount, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 取消发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CancelDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        if (!dao.CancelDeliverPlan(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 读取指定货物编码、客户编码、寄库交货单号、仓库和批次号的所有计划货物结存数据
        /// </summary>
        /// <param name="strCustomerId"></param>
        /// <param name="strGoodsId"></param>
        /// <param name="strBatchNo"></param>
        /// <param name="strPacking"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strLocation"></param>
        /// <param name="strProductionDate"></param>
        /// <param name="strEnterWarehouseBillId"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlanGoods> LoadDeliverPlanGoodsBalancesByConditions(string strCustomerId, string strGoodsId, string strBatchNo, string strPacking, string strWarehouse, string strLocation, string strProductionDate, string strEnterWarehouseBillId, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlanGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadDeliverPlanGoodsBalancesByConditions(strCustomerId, strGoodsId, strBatchNo, strPacking, strWarehouse, strLocation, strProductionDate, strEnterWarehouseBillId, strDeliveryNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定客户编码和仓库的待调度计划
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadDispatchDeliverPlansByCustomerIdAndWarehouse(long nCustomerId, string strWarehouse, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        dataResult = dao.LoadDispatchDeliverPlansByCustomerIdAndWarehouse(nCustomerId, strWarehouse, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 退回修改发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool ReturnDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        if (!dao.ReturnDeliverPlan(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 修改发货计划备注
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="strRemark"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverPlanRemark(long nId, string strRemark, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            PlanRule rule = new PlanRule();
            return rule.UpdateDeliverPlanRemark(nId, strRemark, nOpStaffId, strOpStaffName, out strErrText);
        }




    }
}
