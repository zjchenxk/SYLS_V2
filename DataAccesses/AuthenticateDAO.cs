using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class AuthenticateDAO : BaseDAO
    {
        /// <summary>
        /// 读取所有帐号记录（包括注销的帐号）
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Account> LoadAccounts(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Account> list = LoadData<Account>("LoadAccounts", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取活动帐号记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Account> LoadActiveAccounts(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Account> list = LoadData<Account>("LoadActiveAccounts", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增帐号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertAccount(Account data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
                    MakeParam(PASSWORD_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Password),
					MakeParam(ACCOUNTTYPE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.AccountType),
					MakeParam(ORGANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OrganId),
					MakeParam(STAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.StaffId),
					MakeParam(STAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.StaffName),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertAccount", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 修改帐号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateAccount(Account data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(PASSWORD_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Password),
					MakeParam(ACCOUNTTYPE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.AccountType),
					MakeParam(ORGANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OrganId),
					MakeParam(STAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.StaffId),
					MakeParam(STAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.StaffName),
					MakeParam(ISCANCEL_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsCancel),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateAccount", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除帐号
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteAccount(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteAccount", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据名称读取帐号数据
        /// </summary>
        /// <param name="strAccountName">帐号名称</param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Account LoadAccountByName(string strAccountName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strAccountName)
				};

            List<Account> list = LoadData<Account>("LoadAccountByName", Params, out strErrText);
            if (list != null && list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 读取指定帐号数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Account LoadAccount(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            List<Account> list = LoadData<Account>("LoadAccount", Params, out strErrText);
            if (list != null && list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增登录日志记录
        /// </summary>
        /// <param name="data">登录帐号数据集</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool InsertLoginLog(Account data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ORGANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OrganId),
					MakeParam(ORGANNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.OrganFullName),
					MakeParam(STAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.StaffId),
					MakeParam(STAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.StaffName),
					MakeParam(HOSTIP_PARAM, SqlDbType.NVarChar, 30, ParameterDirection.Input, (object)string.Empty),
					MakeParam(HOSTNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)string.Empty),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertLoginLog", Params, out strErrText) < 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 读取员工帐号记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Account> LoadStaffAccounts(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Account> list = LoadData<Account>("LoadStaffAccounts", Params, out strErrText);
            return list;
        }

    }
}
