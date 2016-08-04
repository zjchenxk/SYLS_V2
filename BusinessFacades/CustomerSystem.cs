using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class CustomerSystem : MarshalByRefObject
    {
        /// <summary>
        /// 读取所有客户记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Customer> LoadCustomers(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Customer> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomers(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据名称读取所有客户名称数据
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Customer> LoadCustomerNamesByName(string strName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Customer> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerNamesByName(strName, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定客户记录
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Customer LoadCustomer(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Customer dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomer(nCustomerId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据名称读取指定客户数据
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Customer LoadCustomerByName(string strName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Customer dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerByName(strName, nOpStaffId, strOpStaffName, out strErrText);
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
            CustomerRule rule = new CustomerRule();
            return rule.InsertCustomer(data, listTransportPrice, listForceFeePrice, listStorageFeePrice, nOpStaffId, strOpStaffName, out strErrText);
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
            CustomerRule rule = new CustomerRule();
            return rule.UpdateCustomer(data, listTransportPrice, listForceFeePrice, listStorageFeePrice, nOpStaffId, strOpStaffName, out strErrText);
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
            CustomerRule rule = new CustomerRule();
            return rule.DeleteCustomer(nCustomerId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取指定客户的结算价格数据
        /// </summary>
        /// <param name="nCustomerId">客户编码</param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerTransportPrice> LoadCustomerTransportPricesByCustomerId(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerTransportPrice> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerTransportPricesByCustomerId(nCustomerId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定客户的力支费价格数据
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerForceFeePrice> LoadCustomerForceFeePricesByCustomerId(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerForceFeePrice> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerForceFeePricesByCustomerId(nCustomerId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定客户的仓储费价格数据
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerStorageFeePrice> LoadCustomerStorageFeePricesByCustomerId(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerStorageFeePrice> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerStorageFeePricesByCustomerId(nCustomerId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定时间段内发生业务的付款单位数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Customer> LoadGenerateBusinessPayersByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Customer> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadGenerateBusinessPayersByTimespan(strStartTime, strEndTime, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定发货计划的客户结算价格数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="strCarType"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public CustomerTransportPrice LoadCustomerTransportPriceByPlanId(long nPlanId, string strCarType, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                CustomerTransportPrice dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerTransportPriceByPlanId(nPlanId, strCarType, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定时间段内发生仓储力支费的客户数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Customer> LoadGenerateStorageAndForceFeeCustomersByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Customer> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadGenerateStorageAndForceFeeCustomersByTimespan(strStartTime, strEndTime, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据综合条件读取客户数据
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Customer> LoadCustomersByConditions(string strName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Customer> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomersByConditions(strName, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定客户和时间的力支费价格数据
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="dtStartTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public CustomerForceFeePrice LoadCustomerForceFeePrice(long nCustomerId, DateTime dtStartTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                CustomerForceFeePrice dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerForceFeePrice(nCustomerId, dtStartTime, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定客户和时间的仓储费价格数据
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="dtStartTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public CustomerStorageFeePrice LoadCustomerStorageFeePrice(long nCustomerId, DateTime dtStartTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                CustomerStorageFeePrice dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        dataResult = dao.LoadCustomerStorageFeePrice(nCustomerId, dtStartTime, nOpStaffId, strOpStaffName, out strErrText);
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
