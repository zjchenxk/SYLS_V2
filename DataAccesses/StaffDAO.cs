using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class StaffDAO : BaseDAO
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Staff> list = LoadData<Staff>("LoadStaffs", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nStaffId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Staff> list = LoadData<Staff>("LoadStaffsExcludeSelfAndSubordinates", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOrganId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Staff> list = LoadData<Staff>("LoadStaffsByOrganId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOrganId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Staff> list = LoadData<Staff>("LoadAllStaffsByOrganId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nStaffId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Staff> list = LoadData<Staff>("LoadStaff", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
					MakeParam(FAMILYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.FamilyName),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(SEX_PARAM, SqlDbType.NChar, 1, ParameterDirection.Input, (object)data.Sex),
					MakeParam(ORGANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OrganId),
					MakeParam(POSITIONID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PositionId),
					MakeParam(OFFICETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.OfficeTel),
					MakeParam(TELEXT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.TelExt),
					MakeParam(FAX_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Fax),
					MakeParam(MOBILETEL1_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.MobileTel1),
					MakeParam(MOBILETEL2_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.MobileTel2),
					MakeParam(MOBILETEL3_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.MobileTel3),
					MakeParam(EMAIL_PARAM, SqlDbType.NVarChar, 255, ParameterDirection.Input, (object)data.EMail),
                    MakeParam(QQ_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.QQ),
					MakeParam(ISORGANMANAGER_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsOrganManager),
					MakeParam(ISORGANLEADER_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsOrganLeader),
                    MakeParam(BOSSSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.BossStaffId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertStaff", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(FAMILYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.FamilyName),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(SEX_PARAM, SqlDbType.NChar, 1, ParameterDirection.Input, (object)data.Sex),
					MakeParam(ORGANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OrganId),
					MakeParam(POSITIONID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PositionId),
					MakeParam(OFFICETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.OfficeTel),
					MakeParam(TELEXT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.TelExt),
					MakeParam(FAX_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Fax),
					MakeParam(MOBILETEL1_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.MobileTel1),
					MakeParam(MOBILETEL2_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.MobileTel2),
					MakeParam(MOBILETEL3_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.MobileTel3),
					MakeParam(EMAIL_PARAM, SqlDbType.NVarChar, 255, ParameterDirection.Input, (object)data.EMail),
                    MakeParam(QQ_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.QQ),
					MakeParam(ISORGANMANAGER_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsOrganManager),
					MakeParam(ISORGANLEADER_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsOrganLeader),
                    MakeParam(BOSSSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.BossStaffId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateStaff", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nStaffId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteStaff", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

    }
}
