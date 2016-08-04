using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class ContractSystem : MarshalByRefObject
    {
        /// <summary>
        /// 新增合同数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listPlan"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertContract(Contract data, List<ContractDeliverPlan> listPlan, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            ContractRule rule = new ContractRule();
            return rule.InsertContract(data, listPlan, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取待提交合同数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadSubmitContracts(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadSubmitContracts(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取合同数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Contract LoadContract(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Contract dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContract(nId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取合同发货数据
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ContractDeliverPlan> LoadContractDeliverPlans(long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ContractDeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContractDeliverPlans(nContractId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 修改合同数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContract(Contract data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        if (!dao.UpdateContract(data, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 修改合同发货数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractDeliverPlan(ContractDeliverPlan data, List<ContractGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            ContractRule rule = new ContractRule();
            return rule.UpdateContractDeliverPlan(data, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除合同数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteContract(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            ContractRule rule = new ContractRule();
            return rule.DeleteContract(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 提交合同数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitContract(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        if (!dao.SubmitContract(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 读取待打印合同数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadPrintContracts(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadPrintContracts(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 提交打印合同数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool SubmitPrintContract(long nId, long nOpStaffId, string strOpStaffName, out string strMessage)
        {
            ContractRule rule = new ContractRule();
            return rule.SubmitPrintContract(nId, nOpStaffId, strOpStaffName, out strMessage);
        }

        /// <summary>
        /// 读取待审批价格合同数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strContractNo"></param>
        /// <param name="strOriginalContractNo"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadApproveContractsByConditions(string strStartTime, string strEndTime, string strContractNo, string strOriginalContractNo, string strDestCountry, string strDestProvince, string strDestCity, string strCarNo, string strOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadApproveContractsByConditions(strStartTime, strEndTime, strContractNo, strOriginalContractNo, strDestCountry, strDestProvince, strDestCity, strCarNo, strOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 审批合同价格数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="listPlan"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool ApproveContract(long nId, List<ContractDeliverPlan> listPlan, long nOpStaffId, string strOpStaffName, out string strMessage)
        {
            ContractRule rule = new ContractRule();
            return rule.ApproveContract(nId, listPlan, nOpStaffId, strOpStaffName, out strMessage);
        }

        /// <summary>
        /// 根据条件读取待冲帐合同数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strContractNo"></param>
        /// <param name="strOriginalContractNo"></param>
        /// <param name="strCarrierName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadReverseContractsByConditions(string strStartTime, string strEndTime, string strContractNo, string strOriginalContractNo, string strCarrierName, string strCarNo, string strOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadReverseContractsByConditions(strStartTime, strEndTime, strContractNo, strOriginalContractNo, strCarrierName, strCarNo, strOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据合同编码读取待冲帐合同数据
        /// </summary>
        /// <param name="strContractIds"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadReverseContractsByContractIds(string strContractIds, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadReverseContractsByContractIds(strContractIds, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取合同冲帐记录数据
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ContractReverseDetail> LoadContractReverseDetails(long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ContractReverseDetail> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContractReverseDetails(nContractId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增冲帐记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listDetail"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertContractReverse(ContractReverse data, List<ContractReverseDetail> listDetail, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            ContractRule rule = new ContractRule();
            return rule.InsertContractReverse(data, listDetail, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 根据条件读取冲帐记录数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strContractNo"></param>
        /// <param name="strOriginalContractNo"></param>
        /// <param name="strReverserId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ContractReverse> LoadContractReversesByConditions(string strStartTime, string strEndTime, string strContractNo, string strOriginalContractNo, string strReverserId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ContractReverse> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContractReversesByConditions(strStartTime, strEndTime, strContractNo, strOriginalContractNo, strReverserId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定冲帐记录编码的冲帐记录明细数据
        /// </summary>
        /// <param name="nReverseId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ContractReverseDetail> LoadContractReverseDetailsByReverseId(long nReverseId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ContractReverseDetail> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContractReverseDetailsByReverseId(nReverseId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取待罚款的合同数据
        /// </summary>
        /// <param name="strContractNo"></param>
        /// <param name="strOriginalContractNo"></param>
        /// <param name="strCreatorId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadFineContractsByConditions(string strContractNo, string strOriginalContractNo, string strCreatorId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadFineContractsByConditions(strContractNo, strOriginalContractNo, strCreatorId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 合同罚款处理
        /// </summary>
        /// <param name="listContract"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool FineContracts(List<Contract> listContract, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            ContractRule rule = new ContractRule();
            return rule.FineContracts(listContract, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 根据综合条件查询合同罚款记录
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCreatorId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadContractFinesByConditions(string strStartTime, string strEndTime, string strCreatorId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContractFinesByConditions(strStartTime, strEndTime, strCreatorId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 合同退回修改
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool ReturnModifyContract(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            ContractRule rule = new ContractRule();
            return rule.ReturnModifyContract(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除冲帐记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteContractReverse(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            ContractRule rule = new ContractRule();
            return rule.DeleteContractReverse(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除罚款记录数据
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteContractFine(long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        if (!dao.DeleteContractFine(nContractId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 读取合同审批意见记录
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ContractApproveComment> LoadContractApproveComments(long nContractId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ContractApproveComment> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContractApproveComments(nContractId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定时间段内审批合同的所属办事处数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Organization> LoadApproveContractsOwnOrgansByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Organization> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadApproveContractsOwnOrgansByTimespan(strStartTime, strEndTime, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据条件读取合同数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strContractNo"></param>
        /// <param name="strOriginalContractNo"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Contract> LoadContractsByConditions(string strStartTime, string strEndTime, string strContractNo, string strOriginalContractNo, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarNo, string strOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Contract> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (ContractDAO dao = new ContractDAO())
                    {
                        dataResult = dao.LoadContractsByConditions(strStartTime, strEndTime, strContractNo, strOriginalContractNo, strStartCountry, strStartProvince, strStartCity, strDestCountry, strDestProvince, strDestCity, strCarNo, strOrganId, nOpStaffId, strOpStaffName, out strErrText);
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
