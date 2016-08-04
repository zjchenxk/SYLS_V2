using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class FlowRule
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
            List<ApproveFlowStep> listStep;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        //读取流程步骤数据
                        listStep = dao.LoadApproveFlowStepsByFlowType(strFlowType, nOpStaffId, strOpStaffName, out strErrText);
                        if (listStep == null)
                        {
                            return null;
                        }

                        //读取流程所有步骤的条件数据
                        List<ApproveFlowStepCondition> listCondition = dao.LoadApproveFlowStepConditionsByFlowType(strFlowType, nOpStaffId, strOpStaffName, out strErrText);
                        if (listCondition == null)
                        {
                            return null;
                        }

                        //将条件存入流程步骤数据集中
                        foreach (ApproveFlowStep step in listStep)
                        {
                            long nStepId = step.Id;
                            string strConditionExpression = step.ConditionExpression;

                            //读取当前步骤条件数据
                            List<ApproveFlowStepCondition> list = listCondition.FindAll(delegate(ApproveFlowStepCondition c) { return c.StepId == nStepId; });
                            if (list.Count > 1)
                            {
                                string[] strConditions = new string[list.Count + 1];//为什么加1？因为条件序号是从1开始的
                                for (int i = 0; i < list.Count; i++)
                                {
                                    string strFieldName = list[i].FieldName;
                                    string strCompareOperator = list[i].CompareOperator;
                                    string strFieldValue = list[i].FieldValue;

                                    strConditions[i + 1] = strFieldName + strCompareOperator + strFieldValue;
                                }
                                step.Conditions = string.Format(strConditionExpression, strConditions);
                            }
                            else if (list.Count == 1)
                            {
                                string strFieldName = list[0].FieldName;
                                string strCompareOperator = list[0].CompareOperator;
                                string strFieldValue = list[0].FieldValue;

                                step.Conditions = strFieldName + strCompareOperator + strFieldValue;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return listStep;
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
        /// <param name="listConditions">步骤执行条件数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public long InsertApproveFlowStep(ApproveFlowStep data, List<ApproveFlowStepCondition> listConditions, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nId = 0;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        //保存步骤数据
                        nId = dao.InsertApproveFlowStep(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nId <= 0)
                        {
                            return 0;
                        }

                        //保存条件数据
                        foreach (ApproveFlowStepCondition condition in listConditions)
                        {
                            condition.StepId = nId;

                            if (!dao.InsertApproveFlowStepCondition(condition, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 修改审批流程步骤数据
        /// </summary>
        /// <param name="data">流程步骤数据集</param>
        /// <param name="listConditions">步骤执行条件数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool UpdateApproveFlowStep(ApproveFlowStep data, List<ApproveFlowStepCondition> listConditions, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        //修改步骤数据
                        if (!dao.UpdateApproveFlowStep(data, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除原条件数据
                        if (!dao.DeleteApproveFlowStepConditions(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //保存新条件数据
                        foreach (ApproveFlowStepCondition condition in listConditions)
                        {
                            if (!dao.InsertApproveFlowStepCondition(condition, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除指定流程步骤数据
        /// </summary>
        /// <param name="nId">步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool DeleteApproveFlowStep(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        //删除步骤数据
                        if (!dao.DeleteApproveFlowStep(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除原条件数据
                        if (!dao.DeleteApproveFlowStepConditions(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
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
        /// 上移指定流程步骤数据
        /// </summary>
        /// <param name="nId">步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool MoveUpApproveStep(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        //读取步骤数据
                        ApproveFlowStep data = dao.LoadApproveFlowStep(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return false;
                        }

                        //调整当前步骤序号
                        int nStepNum = data.StepNum;
                        if (nStepNum > 1) nStepNum--;
                        data.StepNum = nStepNum;

                        //修改步骤数据
                        if (!dao.UpdateApproveFlowStep(data, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
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
        /// 下移指定流程步骤数据
        /// </summary>
        /// <param name="nId">步骤编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool MoveDownApproveStep(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (FlowDAO dao = new FlowDAO())
                    {
                        //读取步骤数据
                        ApproveFlowStep data = dao.LoadApproveFlowStep(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return false;
                        }

                        //读取当前流程的所有步骤数据
                        List<ApproveFlowStep> listStep = dao.LoadApproveFlowStepsByFlowType(data.FlowType, nOpStaffId, strOpStaffName, out strErrText);
                        if (listStep.Count == 0)
                        {
                            return false;
                        }

                        //调整当前步骤序号
                        int nStepNum = data.StepNum;
                        if (nStepNum < listStep.Count) nStepNum++;
                        data.StepNum = nStepNum;

                        //修改步骤数据
                        if (!dao.UpdateApproveFlowStep(data, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
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
