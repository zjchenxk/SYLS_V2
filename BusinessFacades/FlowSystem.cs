using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class FlowSystem : MarshalByRefObject
    {
        /// <summary>
        /// 根据流程类别读取指定审批流程的步骤数据
        /// </summary>
        /// <param name="strFlowType">流程类别</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<ApproveFlowStep> LoadApproveFlowStepsByFlowType(string strFlowType, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            FlowRule rule = new FlowRule();
            return rule.LoadApproveFlowStepsByFlowType(strFlowType, nOpStaffId, strOpStaffName, out strErrText);
        }

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
            ApproveFlowStep data;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        data = dao.LoadApproveFlowStep(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return null;
                        }
                    }
                    transScope.Complete();
                }
                return data;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增审批流程步骤数据
        /// </summary>
        /// <param name="data">流程步骤数据集</param>
        /// <param name="listCondition">步骤执行条件数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public long InsertApproveFlowStep(ApproveFlowStep data, List<ApproveFlowStepCondition> listCondition, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            FlowRule rule = new FlowRule();
            return rule.InsertApproveFlowStep(data, listCondition, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 修改审批流程步骤数据
        /// </summary>
        /// <param name="data">流程步骤数据集</param>
        /// <param name="listCondition">步骤执行条件数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool UpdateApproveFlowStep(ApproveFlowStep data, List<ApproveFlowStepCondition> listCondition, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            FlowRule rule = new FlowRule();
            return rule.UpdateApproveFlowStep(data, listCondition, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 上移指定流程步骤数据
        /// </summary>
        /// <param name="nId">步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool MoveUpApproveStep(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            FlowRule rule = new FlowRule();
            return rule.MoveUpApproveStep(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 下移指定流程步骤数据
        /// </summary>
        /// <param name="nId">步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool MoveDownApproveStep(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            FlowRule rule = new FlowRule();
            return rule.MoveDownApproveStep(nId, nOpStaffId, strOpStaffName, out strErrText);
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
            FlowRule rule = new FlowRule();
            return rule.DeleteApproveFlowStep(nId, nOpStaffId, strOpStaffName, out strErrText);
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
            List<ApproveFlowStepCondition> data;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        data = dao.LoadApproveFlowStepConditionsByStepId(nStepId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return data;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

    }
}
