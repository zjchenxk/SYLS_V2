using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class StatisticsSystem : MarshalByRefObject
    {
        /// <summary>
        /// 根据综合条件读取办事处总产值明细数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<OrganTotalOutputDetail> LoadOrganTotalOutputDetailsByConditions(string strStartTime, string strEndTime, string strOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<OrganTotalOutputDetail> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StatisticsDAO dao = new StatisticsDAO())
                    {
                        dataResult = dao.LoadOrganTotalOutputDetailsByConditions(strStartTime, strEndTime, strOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据综合条件读取办事处毛利率明细数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<OrganGrossProfitRateDetail> LoadOrganGrossProfitRateDetailsByConditions(string strStartTime, string strEndTime, string strOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<OrganGrossProfitRateDetail> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StatisticsDAO dao = new StatisticsDAO())
                    {
                        dataResult = dao.LoadOrganGrossProfitRateDetailsByConditions(strStartTime, strEndTime, strOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据综合条件读取客户总产值明细数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerTotalOutputDetail> LoadCustomerTotalOutputDetailsByConditions(string strStartTime, string strEndTime, string strCustomerName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerTotalOutputDetail> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StatisticsDAO dao = new StatisticsDAO())
                    {
                        dataResult = dao.LoadCustomerTotalOutputDetailsByConditions(strStartTime, strEndTime, strCustomerName, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 修改综合查询数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="strShipmentNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nPayerId"></param>
        /// <param name="strPayerName"></param>
        /// <param name="nContractId"></param>
        /// <param name="strOriginalContractNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SyntheticalSearchModifyData(long nPlanId, string strShipmentNo, string strDeliveryNo, long nPayerId, string strPayerName, long nContractId, string strOriginalContractNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StatisticsRule rule = new StatisticsRule();
            return rule.SyntheticalSearchModifyData(nPlanId, strShipmentNo, strDeliveryNo, nPayerId, strPayerName, nContractId, strOriginalContractNo, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 在送货单退回调度之前进行检查
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CheckForReturnDispatch(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StatisticsDAO dao = new StatisticsDAO())
                    {
                        if (!dao.CheckForReturnDispatch(nDeliverBillId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 退回送货单重新调度
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool ReturnDispatchDeliverBill(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StatisticsDAO dao = new StatisticsDAO())
                    {
                        if (!dao.ReturnDispatchDeliverBill(nDeliverBillId, nOpStaffId, strOpStaffName, out strErrText))
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
