using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class PermissionDAO : BaseDAO
    {
        /// <summary>
        /// 读取所有权限组记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<SysGroup> LoadPermissionGroups(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<SysGroup> list = LoadData<SysGroup>("LoadPermissionGroups", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定权限组记录
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public SysGroup LoadPermissionGroup(long nGroupId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nGroupId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<SysGroup> list = LoadData<SysGroup>("LoadPermissionGroup", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增权限组
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strRemark"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertPermissionGroup(string strName, string strRemark, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nGroupId = 0;

            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)nGroupId),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strName),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)strRemark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertPermissionGroup", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增组权限数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertGroupPermission(SysGroupPermission data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(GROUPID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GroupId),
                    MakeParam(FUNCID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.FuncId),
                    MakeParam(ALLOWOPEN_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowOpen),
                    MakeParam(ALLOWNEW_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowNew),
                    MakeParam(ALLOWMODIFY_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowModify),
                    MakeParam(ALLOWDELETE_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowDelete),
                    MakeParam(ALLOWCANCEL_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowCancel),
                    MakeParam(ALLOWDETAIL_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowDetail),
                    MakeParam(ALLOWSEARCH_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowSearch),
                    MakeParam(ALLOWSUBMIT_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowSubmit),
                    MakeParam(ALLOWAPPROVE_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowApprove),
                    MakeParam(ALLOWDISPATCH_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowDispatch),
                    MakeParam(ALLOWEXPORT_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowExport),
                    MakeParam(ALLOWIMPORT_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowImport),
                    MakeParam(ALLOWPRINT_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.AllowPrint),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertGroupPermission", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改权限组
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="strName"></param>
        /// <param name="strRemark"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdatePermissionGroup(long nGroupId, string strName, string strRemark, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nGroupId),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strName),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)strRemark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdatePermissionGroup", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除组权限数据
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteGroupPermissions(long nGroupId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(GROUPID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nGroupId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteGroupPermissions", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除权限组数据
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeletePermissionGroup(long nGroupId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nGroupId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeletePermissionGroup", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 读取指定组的权限数据
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<SysGroupPermission> LoadGroupPermissions(long nGroupId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(GROUPID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nGroupId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<SysGroupPermission> list = LoadData<SysGroupPermission>("LoadGroupPermissions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定帐号的权限数据
        /// </summary>
        /// <param name="nAccountId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<AccountPermission> LoadAccountPermissions(long nAccountId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ACCOUNTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nAccountId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<AccountPermission> list = LoadData<AccountPermission>("LoadAccountPermissions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 删除帐号权限数据
        /// </summary>
        /// <param name="nAccountId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteAccountPermissions(long nAccountId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ACCOUNTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nAccountId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteAccountPermissions", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增帐号权限数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertAccountPermission(AccountPermission data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ACCOUNTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.AccountId),
                    MakeParam(GROUPID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GroupId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertAccountPermission", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 读取所有系统功能记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<SysFunction> LoadFunctions(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<SysFunction> list = LoadData<SysFunction>("LoadFunctions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定功能的某个权限状态
        /// </summary>
        /// <param name="nFunctionId"></param>
        /// <param name="strPermission"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public int LoadFunctionPermission(long nFunctionId, string strPermission, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nFunctionId),
                    MakeParam(FUNCPERMISSION_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPermission),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            object objRet = ExecuteScalar("LoadFunctionPermission", Params, out strErrText);
            if (objRet == null)
            {
                throw new Exception(strErrText);
            }
            else
            {
                return (bool)objRet ? 1 : 0;
            }
        }

        /// <summary>
        /// 读取指定帐号的某个权限状态
        /// </summary>
        /// <param name="nFunctionId"></param>
        /// <param name="strPermission"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool LoadAccountPermission(long nFunctionId, string strPermission, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(FUNCID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nFunctionId),
                    MakeParam(FUNCPERMISSION_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPermission),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Permission> list = LoadData<Permission>("LoadAccountPermission", Params, out strErrText);
            if (list.Count == 0)
            {
                return false;
            }
            else
            {
                if (list.Count > 1)
                {
                    foreach (Permission p in list)
                    {
                        if (p.IsAllow) return true;
                    }
                    return false;
                }
                else
                {
                    return list[0].IsAllow;
                }
            }
        }

    }
}
