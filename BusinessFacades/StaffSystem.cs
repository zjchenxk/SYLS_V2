using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class StaffSystem : MarshalByRefObject
    {
        /// <summary>
        /// 读取所有员工记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Staff> LoadStaffs(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Staff> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        dataResult = dao.LoadStaffs(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取除指定员工及其所有下属之外的员工记录
        /// </summary>
        /// <param name="nStaffId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Staff> LoadStaffsExcludeSelfAndSubordinates(long nStaffId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Staff> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        dataResult = dao.LoadStaffsExcludeSelfAndSubordinates(nStaffId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定组织部门的员工记录
        /// </summary>
        /// <param name="nOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Staff> LoadStaffsByOrganId(long nOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Staff> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        dataResult = dao.LoadStaffsByOrganId(nOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定组织部门的所有员工记录
        /// </summary>
        /// <param name="nOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Staff> LoadAllStaffsByOrganId(long nOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Staff> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        dataResult = dao.LoadAllStaffsByOrganId(nOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定员工记录
        /// </summary>
        /// <param name="nStaffId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Staff LoadStaff(long nStaffId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Staff dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        dataResult = dao.LoadStaff(nStaffId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增员工
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public long InsertStaff(Staff data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nStaffId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        nStaffId = dao.InsertStaff(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nStaffId <= 0)
                            return 0;
                    }
                    transScope.Complete();
                }
                return nStaffId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool UpdateStaff(Staff data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        if (!dao.UpdateStaff(data, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除员工
        /// </summary>
        /// <param name="nStaffId"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteStaff(long nStaffId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StaffDAO dao = new StaffDAO())
                    {
                        if (!dao.DeleteStaff(nStaffId, nOpStaffId, strOpStaffName, out strErrText))
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
