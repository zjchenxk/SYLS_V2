using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class PermissionRule
    {
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
            long nGroupId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        //新增权限组
                        nGroupId = dao.InsertPermissionGroup(strName, strRemark, nOpStaffId, strOpStaffName, out strErrText);
                        if (nGroupId <= 0)
                            return 0;

                        //新增组权限
                        foreach (SysFunction f in listFunction)
                        {
                            SysGroupPermission p = new SysGroupPermission();
                            p.GroupId = nGroupId;
                            p.FuncId = f.Id;
                            p.FuncName = f.Name;
                            p.AllowOpen = f.AllowOpen;
                            p.AllowNew = f.AllowNew;
                            p.AllowModify = f.AllowModify;
                            p.AllowDelete = f.AllowDelete;
                            p.AllowCancel = f.AllowCancel;
                            p.AllowDetail = f.AllowDetail;
                            p.AllowSearch = f.AllowSearch;
                            p.AllowSubmit = f.AllowSubmit;
                            p.AllowApprove = f.AllowApprove;
                            p.AllowDispatch = f.AllowDispatch;
                            p.AllowExport = f.AllowExport;
                            p.AllowImport = f.AllowImport;
                            p.AllowPrint = f.AllowPrint;

                            if (!dao.InsertGroupPermission(p, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nGroupId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        //修改权限组
                        if (!dao.UpdatePermissionGroup(nGroupId, strName, strRemark, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        //删除组权限
                        if (!dao.DeleteGroupPermissions(nGroupId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        //新增组权限
                        foreach (SysFunction f in listFunction)
                        {
                            SysGroupPermission p = new SysGroupPermission();
                            p.GroupId = nGroupId;
                            p.FuncId = f.Id;
                            p.FuncName = f.Name;
                            p.AllowOpen = f.AllowOpen;
                            p.AllowNew = f.AllowNew;
                            p.AllowModify = f.AllowModify;
                            p.AllowDelete = f.AllowDelete;
                            p.AllowCancel = f.AllowCancel;
                            p.AllowDetail = f.AllowDetail;
                            p.AllowSearch = f.AllowSearch;
                            p.AllowSubmit = f.AllowSubmit;
                            p.AllowApprove = f.AllowApprove;
                            p.AllowDispatch = f.AllowDispatch;
                            p.AllowExport = f.AllowExport;
                            p.AllowImport = f.AllowImport;
                            p.AllowPrint = f.AllowPrint;

                            if (!dao.InsertGroupPermission(p, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除权限组
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeletePermissionGroup(long nGroupId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        //删除权限组
                        if (!dao.DeletePermissionGroup(nGroupId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        //删除组权限
                        if (!dao.DeleteGroupPermissions(nGroupId, nOpStaffId, strOpStaffName, out strErrText))
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PermissionDAO dao = new PermissionDAO())
                    {
                        //删除原帐号权限
                        if (!dao.DeleteAccountPermissions(nAccountId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        //新增岗位权限
                        if (listGroup != null)
                        {
                            foreach (SysGroup g in listGroup)
                            {
                                AccountPermission p = new AccountPermission();
                                p.AccountId = nAccountId;
                                p.GroupId = g.Id;

                                if (!dao.InsertAccountPermission(p, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
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

    }
}
