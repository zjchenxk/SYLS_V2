using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class DeliverSystem : MarshalByRefObject
    {
        /// <summary>
        /// 读取待打印调度出仓单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadPrintDispatchedShipmentBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ShipmentBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadPrintDispatchedShipmentBills(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 提交指定的待打印出仓单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOutWarehouseBillId"></param>
        /// <param name="nEnterWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitPrintShipmentBill(long nId, out long nOutWarehouseBillId, out long nEnterWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        if (!dao.SubmitPrintShipmentBill(nId, out nOutWarehouseBillId, out nEnterWarehouseBillId, nOpStaffId, strOpStaffName, out strErrText))
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
                nOutWarehouseBillId = 0;
                nEnterWarehouseBillId = 0;
                strErrText = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 读取待打印划拨出仓单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadPrintAllocateShipmentBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ShipmentBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadPrintAllocateShipmentBills(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取待打印划拨出仓单货物数据
        /// </summary>
        /// <param name="nShipmentBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBillGoods> LoadShipmentBillAllGoods(long nShipmentBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ShipmentBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadShipmentBillAllGoods(nShipmentBillId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定出仓单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public ShipmentBill LoadShipmentBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                ShipmentBill dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadShipmentBill(nId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取待提交出仓单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadSubmitShipmentBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ShipmentBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadSubmitShipmentBills(nOpStaffId, strOpStaffName, out strErrText);
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
            DeliverRule rule = new DeliverRule();
            return rule.UpdateShipmentBill(nId, decTransportCharges, listGoods, nOpStaffId, strOpStaffName, out strErrText);
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
            DeliverRule rule = new DeliverRule();
            return rule.CancelShipmentBill(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 提交出仓单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitShipmentBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        if (!dao.SubmitShipmentBill(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 读取待打印送货单
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadPrintDeliverBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadPrintDeliverBills(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取送货单所有货物数据
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBillGoods> LoadDeliverBillAllGoods(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBillAllGoods(nDeliverBillId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取送货单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBill LoadDeliverBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DeliverBill dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBill(nId, nOpStaffId, strOpStaffName, out strErrText);
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
            DeliverRule rule = new DeliverRule();
            return rule.UpdateDeliverBill(nId, decTransportCharges, listGoods, nOpStaffId, strOpStaffName, out strErrText);
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
            DeliverRule rule = new DeliverRule();
            return rule.CancelDeliverBill(nId, nOpStaffId, strOpStaffName, out strErrText);
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
            DeliverRule rule = new DeliverRule();
            return rule.SubmitPrintDeliverBill(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 根据条件读取待接收回单送货单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadReceiptDeliverBillsByConditions(string strStartTime, string strEndTime, string strCustomerName, string strCarNo, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadReceiptDeliverBillsByConditions(strStartTime, strEndTime, strCustomerName, strCarNo, strDeliveryNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 修改送货单回单信息
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="dtReturnTime"></param>
        /// <param name="strDamageInfo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverBillReceipt(long nId, DateTime dtReturnTime, string strDamageInfo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        if (!dao.UpdateDeliverBillReceipt(nId, dtReturnTime, strDamageInfo, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 根据送货单号读取所有送货单号数据
        /// </summary>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadDeliverBillNosByNo(string strDeliverBillNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBillNosByNo(strDeliverBillNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定送货单号的送货单数据
        /// </summary>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBill LoadDeliverBillByNo(string strDeliverBillNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DeliverBill dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBillByNo(strDeliverBillNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据综合条件读取送货单回单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadDeliverBillReceiptsByConditions(string strStartTime, string strEndTime, string strCustomerName, string strDeliveryNo,
            string strCarNo, string strDestCountry, string strDestProvince, string strDestCity, string strOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBillReceiptsByConditions(strStartTime, strEndTime, strCustomerName, strDeliveryNo, strCarNo, strDestCountry,
                            strDestProvince, strDestCity, strOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据综合条件读取出仓单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strShipmentBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadShipmentBillsByConditions(string strStartTime, string strEndTime, string strShipmentBillNo, string strCustomerName, string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ShipmentBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadShipmentBillsByConditions(strStartTime, strEndTime, strShipmentBillNo, strCustomerName, strCarNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据综合条件读取送货单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strPayerName"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strOrganId"></param>
        /// <param name="strPrintState"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadDeliverBillsByConditions(string strStartTime, string strEndTime, string strDeliverBillNo, string strCustomerName, string strPayerName, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarNo, string strDeliveryNo, string strOrganId, string strPrintState, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DeliverBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBillsByConditions(strStartTime, strEndTime, strDeliverBillNo, strCustomerName, strPayerName, strStartCountry, strStartProvince, strStartCity, strDestCountry, strDestProvince, strDestCity, strCarNo, strDeliveryNo, strOrganId, strPrintState, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定时间段内发货的办事处数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Organization> LoadDeliverBillsOwnOrgansByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Organization> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBillsOwnOrgansByTimespan(strStartTime, strEndTime, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定时间段内发货的付款单位数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Customer> LoadDeliverBillsPayersByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Customer> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        dataResult = dao.LoadDeliverBillsPayersByTimespan(strStartTime, strEndTime, nOpStaffId, strOpStaffName, out strErrText);
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

    }
}
