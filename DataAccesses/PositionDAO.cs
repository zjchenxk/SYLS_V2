using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class PositionDAO : BaseDAO
    {

        /// <summary>
        /// 读取所有岗位记录
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Position> LoadPositions(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Position> list = LoadData<Position>("LoadPositions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定岗位记录
        /// </summary>
        /// <param name="nPositionId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Position LoadPosition(long nPositionId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPositionId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Position> list = LoadData<Position>("LoadPosition", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增岗位
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool InsertPosition(Position data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertPosition", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改岗位
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool UpdatePosition(Position data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdatePosition", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="nPositionId"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeletePosition(long nPositionId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPositionId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeletePosition", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

    }
}
