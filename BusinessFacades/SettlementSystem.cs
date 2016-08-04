using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class SettlementSystem : MarshalByRefObject
    {
        /// <summary>
        /// 根据条件读取客户对帐单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strPayerName"></param>
        /// <param name="strReceiverName"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarrierName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strGoodsName"></param>
        /// <param name="strAllowStatementWhenConsignedDeliverPlanNotCompleted"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerStatement> LoadCustomerStatementByConditions(string strStartTime, string strEndTime, string strPayerName, string strReceiverName, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarrierName, string strCarNo, string strGoodsName, string strAllowStatementWhenConsignedDeliverPlanNotCompleted, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerStatement> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadCustomerStatementByConditions(strStartTime, strEndTime, strPayerName, strReceiverName, strStartCountry, strStartProvince, strStartCity, strDestCountry, strDestProvince, strDestCity, strCarrierName, strCarNo, strGoodsName, strAllowStatementWhenConsignedDeliverPlanNotCompleted, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增发票
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listDetail"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertCustomerTransportChargesSettlement(CustomerTransportChargesSettlement data, List<CustomerTransportChargesSettlementDetail> listDetail, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            SettlementRule rule = new SettlementRule();
            return rule.InsertCustomerTransportChargesSettlement(data, listDetail, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 根据综合条件读取发票数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strInvoiceNo"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerTransportChargesSettlement> LoadCustomerTransportChargesSettlementsByConditions(string strStartTime, string strEndTime, string strInvoiceNo, string strDeliverBillNo, string strCustomerName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerTransportChargesSettlement> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadCustomerTransportChargesSettlementsByConditions(strStartTime, strEndTime, strInvoiceNo, strDeliverBillNo, strCustomerName, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定发票的明细数据
        /// </summary>
        /// <param name="nCustomerTransportChargesSettlementId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerTransportChargesSettlementDetail> LoadCustomerTransportChargesSettlementDetails(long nCustomerTransportChargesSettlementId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerTransportChargesSettlementDetail> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadCustomerTransportChargesSettlementDetails(nCustomerTransportChargesSettlementId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据条件读取承运单位对帐单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarrierName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliverBillReceiptReceived"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierStatement> LoadCarrierStatementByConditions(string strStartTime, string strEndTime, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarrierName, string strCarNo, string strDeliverBillReceiptReceived, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierStatement> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadCarrierStatementByConditions(strStartTime, strEndTime, strStartCountry, strStartProvince, strStartCity, strDestCountry, strDestProvince, strDestCity, strCarrierName, strCarNo, strDeliverBillReceiptReceived, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增承运单位结算记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listDetail"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertCarrierTransportChargesSettlement(CarrierTransportChargesSettlement data, List<CarrierTransportChargesSettlementDetail> listDetail, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            SettlementRule rule = new SettlementRule();
            return rule.InsertCarrierTransportChargesSettlement(data, listDetail, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 根据综合条件读取承运单位结算记录
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCarrierName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierTransportChargesSettlement> LoadCarrierTransportChargesSettlementsByConditions(string strStartTime, string strEndTime, string strCarrierName, string strCarNo, string strDeliverBillNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierTransportChargesSettlement> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadCarrierTransportChargesSettlementsByConditions(strStartTime, strEndTime, strCarrierName, strCarNo, strDeliverBillNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定承运单位结算记录明细数据
        /// </summary>
        /// <param name="nCarrierTransportChargesSettlementId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierTransportChargesSettlementDetail> LoadCarrierTransportChargesSettlementDetails(long nCarrierTransportChargesSettlementId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierTransportChargesSettlementDetail> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadCarrierTransportChargesSettlementDetails(nCarrierTransportChargesSettlementId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定送货单编码的特殊结算价格记录
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBillCustomerTransportPrice LoadDeliverBillCustomerTransportPriceByDeliverBillId(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DeliverBillCustomerTransportPrice dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadDeliverBillCustomerTransportPriceByDeliverBillId(nDeliverBillId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增特殊结算价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertDeliverBillCustomerTransportPrice(DeliverBillCustomerTransportPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        if (!dao.InsertDeliverBillCustomerTransportPrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 根据综合条件读取特殊结算价格数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBillCustomerTransportPrice> LoadDeliverBillCustomerTransportPricesByConditions(string strStartTime, string strEndTime, string strDeliverBillNo, string strCustomerName, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBillCustomerTransportPrice> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadDeliverBillCustomerTransportPricesByConditions(strStartTime, strEndTime, strDeliverBillNo, strCustomerName, strDeliveryNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 删除特殊结算价格记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverBillCustomerTransportPrice(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        if (!dao.DeleteDeliverBillCustomerTransportPrice(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 删除开票记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCustomerTransportChargesSettlement(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            SettlementRule rule = new SettlementRule();
            return rule.DeleteCustomerTransportChargesSettlement(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除承运单位结算记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierTransportChargesSettlement(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            SettlementRule rule = new SettlementRule();
            return rule.DeleteCarrierTransportChargesSettlement(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取指定送货单编码的特殊承运价格记录
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBillCarrierTransportPrice LoadDeliverBillCarrierTransportPriceByDeliverBillId(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DeliverBillCarrierTransportPrice dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadDeliverBillCarrierTransportPriceByDeliverBillId(nDeliverBillId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增特殊承运价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertDeliverBillCarrierTransportPrice(DeliverBillCarrierTransportPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        if (!dao.InsertDeliverBillCarrierTransportPrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 根据综合条件读取特殊承运价格数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBillCarrierTransportPrice> LoadDeliverBillCarrierTransportPricesByConditions(string strStartTime, string strEndTime, string strDeliverBillNo, string strCarNo, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBillCarrierTransportPrice> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        dataResult = dao.LoadDeliverBillCarrierTransportPricesByConditions(strStartTime, strEndTime, strDeliverBillNo, strCarNo, strDeliveryNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 删除特殊承运价格记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverBillCarrierTransportPrice(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        if (!dao.DeleteDeliverBillCarrierTransportPrice(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
