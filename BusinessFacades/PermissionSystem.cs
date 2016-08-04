using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class PermissionSystem : MarshalByRefObject
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
            try
            {
                List<SysGroup> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        dataResult = dao.LoadPermissionGroups(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定权限组记录
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public SysGroup LoadPermissionGroup(long nGroupId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                SysGroup dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        dataResult = dao.LoadPermissionGroup(nGroupId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增权限组
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strRemark"></param>
        /// <param name="listFunction"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertPermissionGroup(string strName, string strRemark, List<SysFunction> listFunction, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            PermissionRule rule = new PermissionRule();
            return rule.InsertPermissionGroup(strName, strRemark, listFunction, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 修改权限组
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="strName"></param>
        /// <param name="strRemark"></param>
        /// <param name="listFunction"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdatePermissionGroup(long nGroupId, string strName, string strRemark, List<SysFunction> listFunction, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            PermissionRule rule = new PermissionRule();
            return rule.UpdatePermissionGroup(nGroupId, strName, strRemark, listFunction, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除权限组
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeletePermissionGroup(long nGroupId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            PermissionRule rule = new PermissionRule();
            return rule.DeletePermissionGroup(nGroupId, nOpStaffId, strOpStaffName, out strErrText);
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
            try
            {
                List<SysGroupPermission> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        dataResult = dao.LoadGroupPermissions(nGroupId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定帐号的权限数据
        /// </summary>
        /// <param name="nAccountId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<AccountPermission> LoadAccountPermissions(long nAccountId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<AccountPermission> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        dataResult = dao.LoadAccountPermissions(nAccountId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 修改帐号权限
        /// </summary>
        /// <param name="nAccountId"></param>
        /// <param name="listGroup"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateAccountPermissions(long nAccountId, List<SysGroup> listGroup, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            PermissionRule rule = new PermissionRule();
            return rule.UpdateAccountPermissions(nAccountId, listGroup, nOpStaffId, strOpStaffName, out strErrText);
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
            try
            {
                List<SysFunction> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        dataResult = dao.LoadFunctions(nOpStaffId, strOpStaffName, out strErrText);
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
            try
            {
                int dataResult;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        dataResult = dao.LoadFunctionPermission(nFunctionId, strPermission, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return -1;
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
            try
            {
                bool dataResult;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        dataResult = dao.LoadAccountPermission(nFunctionId, strPermission, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

    }
}
