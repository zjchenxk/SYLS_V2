using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class SettlementRule
    {
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
            long nCustomerTransportChargesSettlementId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        //新增发票数据
                        nCustomerTransportChargesSettlementId = dao.InsertCustomerTransportChargesSettlement(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nCustomerTransportChargesSettlementId <= 0)
                            return 0;

                        //新增发票明细数据
                        foreach (CustomerTransportChargesSettlementDetail detail in listDetail)
                        {
                            detail.CustomerTransportChargesSettlementId = nCustomerTransportChargesSettlementId;

                            if (!dao.InsertCustomerTransportChargesSettlementDetail(detail, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nCustomerTransportChargesSettlementId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
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
            long nCarrierTransportChargesSettlementId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        //新增结算数据
                        nCarrierTransportChargesSettlementId = dao.InsertCarrierTransportChargesSettlement(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nCarrierTransportChargesSettlementId <= 0)
                            return 0;

                        //新增结算明细数据
                        foreach (CarrierTransportChargesSettlementDetail detail in listDetail)
                        {
                            detail.CarrierTransportChargesSettlementId = nCarrierTransportChargesSettlementId;

                            if (!dao.InsertCarrierTransportChargesSettlementDetail(detail, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nCarrierTransportChargesSettlementId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        if (!dao.DeleteCustomerTransportChargesSettlement(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        if (!dao.DeleteCustomerTransportChargesSettlementDetails(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除承运单位结算记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierTransportChargesSettlement(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (SettlementDAO dao = new SettlementDAO())
                    {
                        if (!dao.DeleteCarrierTransportChargesSettlement(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        if (!dao.DeleteCarrierTransportChargesSettlementDetails(nId, nOpStaffId, strOpStaffName, out strErrText))
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
