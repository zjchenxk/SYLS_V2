using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class DispatchSystem : MarshalByRefObject
    {
        /// <summary>
        /// 根据发货计划编码和货物编码读取货物调度数据
        /// </summary>
        /// <param name="strPlanId"></param>
        /// <param name="strGoodsId"></param>
        /// <param name="strBatchNo"></param>
        /// <param name="strPacking"></param>
        /// <param name="strLocation"></param>
        /// <param name="strProductionDate"></param>
        /// <param name="strEnterWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadAllDispatchBillGoodsByConditions(string strPlanId, string strGoodsId, string strBatchNo, string strPacking, string strLocation, string strProductionDate, string strEnterWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadAllDispatchBillGoodsByConditions(strPlanId, strGoodsId, strBatchNo, strPacking, strLocation, strProductionDate, strEnterWarehouseBillId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定车号的已调度计划数据
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillDeliverPlan> LoadDispatchBillDeliverPlansByCarNo(string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillDeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillDeliverPlansByCarNo(strCarNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定纸发货计划的待调度货物数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchPaperPlanAllGoods(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchPaperPlanAllGoods(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定罐发货计划的待调度货物数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchCanPlanAllGoods(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchCanPlanAllGoods(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定非纸发货计划的待调度货物数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchDeliverPlanAllGoods(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchDeliverPlanAllGoods(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定车号的待提交调度单数据
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DispatchBill LoadSubmitDispatchBillByCarNo(string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DispatchBill dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadSubmitDispatchBillByCarNo(strCarNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 新增调度单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listDeliverPlan"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertDispatchBill(DispatchBill bill, List<DispatchBillDeliverPlan> listDeliverPlan, List<DispatchBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            DispatchRule rule = new DispatchRule();
            return rule.InsertDispatchBill(bill, listDeliverPlan, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取待提交的调度单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBill> LoadSubmitDispatchBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadSubmitDispatchBills(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定调度单编码和计划编码的已调度计划数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DispatchBillDeliverPlan LoadDispatchBillDeliverPlan(long nDispatchBillId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DispatchBillDeliverPlan dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillDeliverPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定调度单编码的已调度计划数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillDeliverPlan> LoadDispatchBillDeliverPlans(long nDispatchBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillDeliverPlan> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillDeliverPlans(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定调度单的货物数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchBillAllGoods(long nDispatchBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillAllGoods(nDispatchBillId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定计划编码的调度单货物数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchBillAllGoodsByPlanId(long nDispatchBillId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillAllGoodsByPlanId(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定车号的调度单货物数据
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchBillAllGoodsByCarNo(string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillAllGoodsByCarNo(strCarNo, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定车号和计划编码的调度单货物数据
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchBillAllGoodsByCarNoAndPlanId(string strCarNo, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillAllGoodsByCarNoAndPlanId(strCarNo, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 删除指定的调度单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            DispatchRule rule = new DispatchRule();
            return rule.DeleteDispatchBill(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取指定调度单编码和计划编码的非纸计划已调度货物数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchedDeliverPlanAllGoods(long nDispatchBillId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchedDeliverPlanAllGoods(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 修改调度单
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listDeliverPlan"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDispatchBill(DispatchBill bill, List<DispatchBillDeliverPlan> listDeliverPlan, List<DispatchBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            DispatchRule rule = new DispatchRule();
            return rule.UpdateDispatchBill(bill, listDeliverPlan, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 修改调度单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listPlan"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDispatchBill(DispatchBill data, List<DispatchBillDeliverPlan> listPlan, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            DispatchRule rule = new DispatchRule();
            return rule.UpdateDispatchBill(data, listPlan, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除指定调度单编码和计划编码的已调度计划数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchedPlan(long nDispatchBillId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            DispatchRule rule = new DispatchRule();
            return rule.DeleteDispatchedPlan(nDispatchBillId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取指定调度单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DispatchBill LoadDispatchBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                DispatchBill dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBill(nId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 提交指定调度单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitDispatchBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            DispatchRule rule = new DispatchRule();
            return rule.SubmitDispatchBill(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 取消调度单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CancelDispatchBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        if (!dao.CancelDispatchBill(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 读取可以签订合同的所有调度单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBill> LoadContractDispatchBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBill> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadContractDispatchBills(nOpStaffId, strOpStaffName, out strErrText);
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
        /// 读取指定合同编码和计划编码的调度单货物数据
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DispatchBillGoods> LoadDispatchBillAllGoodsByContractIdAndPlanId(long nContractId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<DispatchBillGoods> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        dataResult = dao.LoadDispatchBillAllGoodsByContractIdAndPlanId(nContractId, nPlanId, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 合并调度单
        /// </summary>
        /// <param name="strIds"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="bShipmentBillMerged"></param>
        /// <param name="bDeliverBillMerged"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long MergeDispatchBills(string strIds, long nOpStaffId, string strOpStaffName, out bool bShipmentBillMerged, out bool bDeliverBillMerged, out string strErrText)
        {
            long nNewId = 0;
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DispatchDAO dao = new DispatchDAO())
                    {
                        nNewId = dao.MergeDispatchBills(strIds, nOpStaffId, strOpStaffName, out bShipmentBillMerged, out bDeliverBillMerged, out strErrText);
                        if (nNewId <= 0)
                        {
                            return 0;
                        }
                    }
                    transScope.Complete();
                }
                return nNewId;
            }
            catch (Exception e)
            {
                bShipmentBillMerged = false;
                bDeliverBillMerged = false;
                strErrText = e.Message;
                return 0;
            }
        }

    }
}
