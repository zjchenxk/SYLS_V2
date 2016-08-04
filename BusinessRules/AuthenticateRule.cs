using System;
using System.Transactions;
using InnoSoft.LS.Models;
using InnoSoft.LS.Data.Access;

namespace InnoSoft.LS.Business.Rules
{
    public class AuthenticateRule
    {

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
            long nId = 0;

            try
            {
                //生成登录密码MD5码，密码默认为123456
                data.Password = Utils.GetMD5Hash(data.Name + "@" + "123456");

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        nId = dao.InsertAccount(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nId <= 0)
                            return 0;
                    }
                    transScope.Complete();
                }
                return nId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        Account data = dao.LoadAccount(nAccountId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return false;
                        }

                        data.IsCancel = true;
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
        /// 员工登录认证方法
        /// </summary>
        /// <param name="strAccountName">登录帐号</param>
        /// <param name="strPassword">登录密码</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>登录成功返回员工实体对象，否则返回null</returns>
        public Account StaffLogin(string strAccountName, string strPassword, out string strErrText)
        {
            try
            {
                Account dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        //读取登录帐号数据
                        dataResult = dao.LoadAccountByName(strAccountName, out strErrText);
                        if (dataResult == null)
                        {
                            return null;
                        }

                        //生成登录密码MD5码
                        string strHash = Utils.GetMD5Hash(strAccountName + "@" + strPassword);
                        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                        if (comparer.Compare(strHash, dataResult.Password) == 0)
                        {
                            //保存登录日志
                            if (!dao.InsertLoginLog(dataResult, dataResult.Id, dataResult.StaffName, out strErrText))
                            {
                                return null;
                            }
                        }
                        else
                        {
                            strErrText = InnoSoft.LS.Resources.Strings.PasswordIsIncorrect;
                            return null;
                        }
                    }
                    transScope.Complete();
                }
                strErrText = String.Empty;
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        //读取登录帐号数据
                        Account data = dao.LoadAccount(nOpStaffId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return false;
                        }

                        //生成登录密码MD5码
                        string strHash = Utils.GetMD5Hash(data.Name + "@" + strOldPassword);
                        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                        if (comparer.Compare(strHash, data.Password) == 0)
                        {
                            data.Password = Utils.GetMD5Hash(data.Name + "@" + strNewPassword);

                            if (!dao.UpdateAccount(data, nOpStaffId, strOpStaffName, out strErrText))
                                return false;
                        }
                        else
                        {
                            strErrText = InnoSoft.LS.Resources.Strings.OldPasswordIsIncorrect;
                            return false;
                        }
                    }
                    transScope.Complete();
                }
                strErrText = String.Empty;
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (AuthenticateDAO dao = new AuthenticateDAO())
                    {
                        //读取登录帐号数据
                        Account data = dao.LoadAccount(nAccountId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return false;
                        }

                        //生成登录密码MD5码
                        data.Password = Utils.GetMD5Hash(data.Name + "@" + strNewPassword);

                        if (!dao.UpdateAccount(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
                    }
                    transScope.Complete();
                }
                strErrText = String.Empty;
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
