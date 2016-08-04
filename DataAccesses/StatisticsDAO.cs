using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class StatisticsDAO : BaseDAO
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<OrganTotalOutputDetail> list = LoadData<OrganTotalOutputDetail>("LoadOrganTotalOutputDetailsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<OrganGrossProfitRateDetail> list = LoadData<OrganGrossProfitRateDetail>("LoadOrganTotalOutputDetailsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerTotalOutputDetail> list = LoadData<CustomerTotalOutputDetail>("LoadCustomerTotalOutputDetailsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDeliverBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("CheckForReturnDispatch", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDeliverBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("ReturnDispatchDeliverBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

    }
}
