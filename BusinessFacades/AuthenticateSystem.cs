using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class AuthenticateSystem : MarshalByRefObject
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
            try
            {
                List<Account> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        dataResult = dao.LoadAccounts(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取活动帐号记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Account> LoadActiveAccounts(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Account> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        dataResult = dao.LoadActiveAccounts(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定帐号数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Account LoadAccount(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Account dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        dataResult = dao.LoadAccount(nId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增帐号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertAccount(Account data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            AuthenticateRule rule = new AuthenticateRule();
            return rule.InsertAccount(data, nOpStaffId, strOpStaffName, out strErrText);
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        if (!dao.UpdateAccount(data, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除帐号
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteAccount(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        if (!dao.DeleteAccount(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 注销帐号
        /// </summary>
        /// <param name="nAccountId"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool CancelAccount(long nAccountId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            AuthenticateRule rule = new AuthenticateRule();
            return rule.CancelAccount(nAccountId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 员工登录认证方法
        /// </summary>
        /// <param name="strAccountName">登录帐号</param>
        /// <param name="strPassword">登录密码</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>登录成功返回员工实体对象，否则返回null</returns>
        public Account StaffLogin(string strAccountName, string strPassword, out string strErrText)
        {
            AuthenticateRule rule = new AuthenticateRule();
            return rule.StaffLogin(strAccountName, strPassword, out strErrText);
        }

        /// <summary>
        /// 修改帐号密码
        /// </summary>
        /// <param name="strOldPassword">原密码</param>
        /// <param name="strNewPassword">新密码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool UpdatePassword(string strOldPassword, string strNewPassword, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            AuthenticateRule rule = new AuthenticateRule();
            return rule.UpdatePassword(strOldPassword, strNewPassword, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 初始化帐号密码
        /// </summary>
        /// <param name="nAccountId">帐号编码</param>
        /// <param name="strNewPassword">新密码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool ResetPassword(long nAccountId, string strNewPassword, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            AuthenticateRule rule = new AuthenticateRule();
            return rule.ResetPassword(nAccountId, strNewPassword, nOpStaffId, strOpStaffName, out strErrText);
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
            try
            {
                List<Account> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        dataResult = dao.LoadStaffAccounts(nOpStaffId, strOpStaffName, out strErrText);
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
