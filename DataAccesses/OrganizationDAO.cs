using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class OrganizationDAO : BaseDAO
    {

        /// <summary>
        /// 读取所有组织部门记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Organization> LoadOrganizations(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Organization> list = LoadData<Organization>("LoadOrganizations", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定组织部门记录
        /// </summary>
        /// <param name="nOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Organization LoadOrganization(long nOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOrganId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Organization> list = LoadData<Organization>("LoadOrganization", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增组织部门
        /// </summary>
        /// <param name="data">组织结构实体数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool InsertOrganization(Organization data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(PARENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ParentId),
					MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CountryName),
					MakeParam(PROVINCENAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ProvinceName),
					MakeParam(CITYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CityName),
					MakeParam(ADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Address),
					MakeParam(POSTALCODE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PostalCode),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertOrganization", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改组织部门
        /// </summary>
        /// <param name="data">组织结构实体数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool UpdateOrganization(Organization data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(PARENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ParentId),
					MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CountryName),
					MakeParam(PROVINCENAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ProvinceName),
					MakeParam(CITYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CityName),
					MakeParam(ADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Address),
					MakeParam(POSTALCODE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PostalCode),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateOrganization", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除组织部门
        /// </summary>
        /// <param name="nOrganId"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteOrganization(long nOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOrganId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteOrganization", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

    }
}
