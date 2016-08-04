using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class FlowDAO : BaseDAO
    {
        /// <summary>
        /// 读取指定审批流程步骤数据
        /// </summary>
        /// <param name="nId">步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public ApproveFlowStep LoadApproveFlowStep(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ApproveFlowStep> list = LoadData<ApproveFlowStep>("LoadApproveFlowStep", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增审批流程步骤数据
        /// </summary>
        /// <param name="data">流程步骤数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public long InsertApproveFlowStep(ApproveFlowStep data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建参数数组
            SqlParameter[] Params = 
                {
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(STEPNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.StepName),
                    MakeParam(STEPNUM_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.StepNum),
                    MakeParam(FLOWTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.FlowType),
                    MakeParam(DISPOSERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DisposerId),
                    MakeParam(CONDITIONEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.ConditionExpression??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
                };

            SqlParameterCollection outParams;
            if (Execute("InsertApproveFlowStep", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 修改审批流程步骤数据
        /// </summary>
        /// <param name="data">流程步骤数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool UpdateApproveFlowStep(ApproveFlowStep data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建参数数组
            SqlParameter[] Params = 
                {
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(STEPNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.StepName),
                    MakeParam(STEPNUM_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.StepNum),
                    MakeParam(FLOWTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.FlowType),
                    MakeParam(DISPOSERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DisposerId),
                    MakeParam(CONDITIONEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.ConditionExpression??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
                };

            if (Execute("UpdateApproveFlowStep", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定流程步骤数据
        /// </summary>
        /// <param name="nId">步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool DeleteApproveFlowStep(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建参数数组
            SqlParameter[] Params = 
                {
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
                };

            if (Execute("DeleteApproveFlowStep", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 读取计划审批流程的所有步骤的条件数据
        /// </summary>
        /// <param name="strFlowType">流程类别</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<ApproveFlowStepCondition> LoadApproveFlowStepConditionsByFlowType(string strFlowType, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(FLOWTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strFlowType),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ApproveFlowStepCondition> list = LoadData<ApproveFlowStepCondition>("LoadApproveFlowStepConditionsByFlowType", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定审批流程步骤的条件数据
        /// </summary>
        /// <param name="nStepId">流程步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<ApproveFlowStepCondition> LoadApproveFlowStepConditionsByStepId(long nStepId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STEPID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nStepId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ApproveFlowStepCondition> list = LoadData<ApproveFlowStepCondition>("LoadApproveFlowStepConditionsByStepId", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增审批流程步骤执行条件数据
        /// </summary>
        /// <param name="data">步骤条件数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool InsertApproveFlowStepCondition(ApproveFlowStepCondition data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建参数数组
            SqlParameter[] Params = 
                {
                    MakeParam(STEPID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.StepId),
                    MakeParam(FLOWTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.FlowType),
                    MakeParam(CONDITIONNUM_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.ConditionNum),
                    MakeParam(FIELDNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.FieldName),
                    MakeParam(COMPAREOPERATOR_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CompareOperator),
                    MakeParam(FIELDVALUE_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.FieldValue),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
                };

            if (Execute("InsertApproveFlowStepCondition", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定审批流程步骤的条件数据
        /// </summary>
        /// <param name="nStepId">流程编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool DeleteApproveFlowStepConditions(long nStepId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建参数数组
            SqlParameter[] Params = 
                {
                    MakeParam(STEPID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nStepId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
                };

            if (Execute("DeleteApproveFlowStepConditions", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据流程类别读取指定审批流程步骤数据
        /// </summary>
        /// <param name="strFlowType">流程类别</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<ApproveFlowStep> LoadApproveFlowStepsByFlowType(string strFlowType, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(FLOWTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strFlowType),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ApproveFlowStep> list = LoadData<ApproveFlowStep>("LoadApproveFlowStepsByFlowType", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据流程类别和当前步骤序号读取指定审批流程后续步骤数据
        /// </summary>
        /// <param name="strFlowType"></param>
        /// <param name="nCurrentStepNum"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ApproveFlowStep> LoadApproveFlowNextStepsByFlowTypeAndStepNum(string strFlowType, int nCurrentStepNum, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(FLOWTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strFlowType),
                    MakeParam(STEPNUM_PARAM , SqlDbType.Int, 4, ParameterDirection.Input, (object)nCurrentStepNum),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ApproveFlowStep> list = LoadData<ApproveFlowStep>("LoadApproveFlowNextStepsByFlowTypeAndStepNum", Params, out strErrText);
            return list;
        }

    }
}
