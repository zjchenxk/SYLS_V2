using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class CustomerRule
    {
        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listTransportPrice"></param>
        /// <param name="listForceFeePrice"></param>
        /// <param name="listStorageFeePrice"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public long InsertCustomer(Customer data, List<CustomerTransportPrice> listTransportPrice, List<CustomerForceFeePrice> listForceFeePrice, List<CustomerStorageFeePrice> listStorageFeePrice, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nCustomerId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        //新增客户数据
                        nCustomerId = dao.InsertCustomer(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nCustomerId <= 0)
                            return 0;

                        //新增客户结算价格数据
                        foreach (CustomerTransportPrice price in listTransportPrice)
                        {
                            price.CustomerId = nCustomerId;

                            if (!dao.InsertCustomerTransportPrice(price, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }

                        //新增客户力支费价格数据
                        foreach (CustomerForceFeePrice price in listForceFeePrice)
                        {
                            price.CustomerId = nCustomerId;

                            if (!dao.InsertCustomerForceFeePrice(price, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }

                        //新增客户仓储费价格数据
                        foreach (CustomerStorageFeePrice price in listStorageFeePrice)
                        {
                            price.CustomerId = nCustomerId;

                            if (!dao.InsertCustomerStorageFeePrice(price, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nCustomerId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listTransportPrice"></param>
        /// <param name="listForceFeePrice"></param>
        /// <param name="listStorageFeePrice"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool UpdateCustomer(Customer data, List<CustomerTransportPrice> listTransportPrice, List<CustomerForceFeePrice> listForceFeePrice, List<CustomerStorageFeePrice> listStorageFeePrice, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        //修改客户数据
                        if (!dao.UpdateCustomer(data, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除原结算价格数据
                        if (!dao.DeleteCustomerTransportPrices(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //重新新增结算价格数据
                        foreach (CustomerTransportPrice price in listTransportPrice)
                        {
                            if (!dao.InsertCustomerTransportPrice(price, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }

                        //删除原力支费价格数据
                        if (!dao.DeleteCustomerForceFeePrices(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //重新新增力支费价格数据
                        foreach (CustomerForceFeePrice price in listForceFeePrice)
                        {
                            if (!dao.InsertCustomerForceFeePrice(price, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }

                        //删除原仓储费价格数据
                        if (!dao.DeleteCustomerStorageFeePrices(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //重新新增仓储费价格数据
                        foreach (CustomerStorageFeePrice price in listStorageFeePrice)
                        {
                            if (!dao.InsertCustomerStorageFeePrice(price, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除客户
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteCustomer(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        if (!dao.DeleteCustomer(nCustomerId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        if (!dao.DeleteCustomerTransportPrices(nCustomerId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        if (!dao.DeleteCustomerForceFeePrices(nCustomerId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        if (!dao.DeleteCustomerStorageFeePrices(nCustomerId, nOpStaffId, strOpStaffName, out strErrText))
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
