using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class CustomerDAO : BaseDAO
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadCustomers", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadCustomerNamesByName", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadCustomer", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadCustomerByName", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public long InsertCustomer(Customer data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
                    MakeParam(FULLNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.FullName),
                    MakeParam(WARNINGSTOCK_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.WarningStock),
                    MakeParam(STOPSTOCK_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.StopStock),
                    MakeParam(SETTLEMENTEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.SettlementExpression),
                    MakeParam(VALUATIONMODE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ValuationMode),
                    MakeParam(GROSSWEIGHTRATE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.GrossWeightRate),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.Remark??System.String.Empty),
                    MakeParam(OWNORGANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OwnOrganId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertCustomer", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增客户结算价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCustomerTransportPrice(CustomerTransportPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCity),
                    MakeParam(MINTUNNAGESORPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.MinTunnagesOrPiles),
                    MakeParam(MAXTUNNAGESORPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.MaxTunnagesOrPiles),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.CarType??string.Empty),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(RIVERCROSSINGCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.RiverCrossingCharges),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCustomerTransportPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增客户力支费价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCustomerForceFeePrice(CustomerForceFeePrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(LOADINGFORCEFEEPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.LoadingForceFeePrice),
                    MakeParam(UNLOADINGFORCEFEEPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.UnloadingForceFeePrice),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCustomerForceFeePrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改客户力支费价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateCustomerForceFeePrice(CustomerForceFeePrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(LOADINGFORCEFEEPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.LoadingForceFeePrice),
                    MakeParam(UNLOADINGFORCEFEEPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.UnloadingForceFeePrice),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateCustomerForceFeePrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增客户仓储费价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCustomerStorageFeePrice(CustomerStorageFeePrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(STORAGEFEEPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.StorageFeePrice),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCustomerStorageFeePrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改客户仓储费价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateCustomerStorageFeePrice(CustomerStorageFeePrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(STORAGEFEEPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.StorageFeePrice),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateCustomerStorageFeePrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool UpdateCustomer(Customer data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
                    MakeParam(FULLNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.FullName),
                    MakeParam(WARNINGSTOCK_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.WarningStock),
                    MakeParam(STOPSTOCK_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.StopStock),
                    MakeParam(SETTLEMENTEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.SettlementExpression),
                    MakeParam(VALUATIONMODE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ValuationMode),
                    MakeParam(GROSSWEIGHTRATE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.GrossWeightRate),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.Remark??System.String.Empty),
                    MakeParam(OWNORGANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OwnOrganId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateCustomer", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除客户所有结算价格数据
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCustomerTransportPrices(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCustomerTransportPrices", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除客户所有力支费价格数据
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCustomerForceFeePrices(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCustomerForceFeePrices", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除客户所有仓储费价格数据
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCustomerStorageFeePrices(long nCustomerId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCustomerStorageFeePrices", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCustomer", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerTransportPrice> list = LoadData<CustomerTransportPrice>("LoadCustomerTransportPricesByCustomerId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerForceFeePrice> list = LoadData<CustomerForceFeePrice>("LoadCustomerForceFeePricesByCustomerId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerStorageFeePrice> list = LoadData<CustomerStorageFeePrice>("LoadCustomerStorageFeePricesByCustomerId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadGenerateBusinessPayersByTimespan", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strCarType),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerTransportPrice> list = LoadData<CustomerTransportPrice>("LoadCustomerTransportPriceByPlanId", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadGenerateStorageAndForceFeeCustomersByTimespan", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadCustomersByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)dtStartTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerForceFeePrice> list = LoadData<CustomerForceFeePrice>("LoadCustomerForceFeePrice", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerId),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)dtStartTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerStorageFeePrice> list = LoadData<CustomerStorageFeePrice>("LoadCustomerStorageFeePrice", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

    }
}
