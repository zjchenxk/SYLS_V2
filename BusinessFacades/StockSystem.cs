using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using InnoSoft.LS.Business.Rules;

namespace InnoSoft.LS.Business.Facades
{
    public class StockSystem : MarshalByRefObject
    {
        /// <summary>
        /// 读取指定客户编码、货物编码、批次号和仓库的货物库存数据
        /// </summary>
        /// <param name="strCustomerId"></param>
        /// <param name="strGoodsId"></param>
        /// <param name="strBatchNo"></param>
        /// <param name="strPacking"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strLocation"></param>
        /// <param name="strProductionDate"></param>
        /// <param name="strEnterWarehouseBillId"></param>
        /// <param name="strDeliveryNo">寄库交货单号</param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Stock> LoadGoodsStocksByConditions(string strCustomerId, string strGoodsId, string strBatchNo, string strPacking, string strWarehouse, string strLocation, string strProductionDate, string strEnterWarehouseBillId, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Stock> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadGoodsStocksByConditions(strCustomerId, strGoodsId, strBatchNo, strPacking, strWarehouse, strLocation, strProductionDate, strEnterWarehouseBillId, strDeliveryNo, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增入库单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertEnterWarehouseBill(EnterWarehouseBill bill, List<EnterWarehouseBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StockRule rule = new StockRule();
            return rule.InsertEnterWarehouseBill(bill, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取出库单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public OutWarehouseBill LoadOutWarehouseBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                OutWarehouseBill ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadOutWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取出库单所有货物数据
        /// </summary>
        /// <param name="nOutWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<OutWarehouseBillGoods> LoadOutWarehouseBillAllGoods(long nOutWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<OutWarehouseBillGoods> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadOutWarehouseBillAllGoods(nOutWarehouseBillId, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增出库单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertOutWarehouseBill(OutWarehouseBill bill, List<OutWarehouseBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StockRule rule = new StockRule();
            return rule.InsertOutWarehouseBill(bill, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 修改出库单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateOutWarehouseBill(OutWarehouseBill bill, List<OutWarehouseBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StockRule rule = new StockRule();
            return rule.UpdateOutWarehouseBill(bill, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取入库单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public EnterWarehouseBill LoadEnterWarehouseBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                EnterWarehouseBill ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadEnterWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取入库单所有货物数据
        /// </summary>
        /// <param name="nEnterWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<EnterWarehouseBillGoods> LoadEnterWarehouseBillAllGoods(long nEnterWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<EnterWarehouseBillGoods> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadEnterWarehouseBillAllGoods(nEnterWarehouseBillId, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改入库单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateEnterWarehouseBill(EnterWarehouseBill bill, List<EnterWarehouseBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StockRule rule = new StockRule();
            return rule.UpdateEnterWarehouseBill(bill, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 根据条件读取入库货物数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strEnterWarehouseBillNo"></param>
        /// <param name="strGoodsNo"></param>
        /// <param name="strGoodsName"></param>
        /// <param name="strSpecModel"></param>
        /// <param name="strBatchNo"></param>
        /// <param name="strEnterType"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strIsConsigning"></param>
        /// <param name="strHasDrayage"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<EnterWarehouseBillGoods> LoadEnterWarehouseBillGoodsByConditions(string strStartTime, string strEndTime, string strCustomerName, string strDeliveryNo, string strEnterWarehouseBillNo, string strGoodsNo, string strGoodsName, string strSpecModel, string strBatchNo, string strEnterType, string strWarehouse, string strIsConsigning, string strHasDrayage, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<EnterWarehouseBillGoods> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadEnterWarehouseBillGoodsByConditions(strStartTime, strEndTime, strCustomerName, strDeliveryNo, strEnterWarehouseBillNo, strGoodsNo, strGoodsName, strSpecModel, strBatchNo, strEnterType, strWarehouse, strIsConsigning, strHasDrayage, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据条件读取出库货物数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strOutWarehouseBillNo"></param>
        /// <param name="strGoodsNo"></param>
        /// <param name="strBatchNo"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strReceiverName"></param>
        /// <param name="strOutType"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strReceiveType"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<OutWarehouseBillGoods> LoadOutWarehouseBillGoodsByConditions(string strStartTime, string strEndTime, string strCustomerName, string strDeliveryNo, string strOutWarehouseBillNo, string strGoodsNo, string strBatchNo, string strCarNo, string strReceiverName, string strOutType, string strWarehouse, string strReceiveType, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<OutWarehouseBillGoods> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadOutWarehouseBillGoodsByConditions(strStartTime, strEndTime, strCustomerName, strDeliveryNo, strOutWarehouseBillNo, strGoodsNo, strBatchNo, strCarNo, strReceiverName, strOutType, strWarehouse, strReceiveType, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增移库记录
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertMoveWarehouseBill(MoveWarehouseBill bill, List<MoveWarehouseBillGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StockRule rule = new StockRule();
            return rule.InsertMoveWarehouseBill(bill, listGoods, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 根据条件查询移库记录
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strMoveWarehouseBillNo"></param>
        /// <param name="strGoodsNo"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<MoveWarehouseBillGoods> LoadMoveWarehouseBillGoodsByConditions(string strStartTime, string strEndTime, string strCustomerName, string strMoveWarehouseBillNo, string strGoodsNo, string strWarehouse, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<MoveWarehouseBillGoods> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadMoveWarehouseBillGoodsByConditions(strStartTime, strEndTime, strCustomerName, strMoveWarehouseBillNo, strGoodsNo, strWarehouse, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据条件汇总收发存
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strEnterWarehouseBillNo"></param>
        /// <param name="strGoodsNo"></param>
        /// <param name="strBatchNo"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strIsConsigning"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<EnterOutBalanceSummary> LoadEnterOutBalanceSummariesByConditions(string strStartTime, string strEndTime, string strCustomerName, string strDeliveryNo, string strEnterWarehouseBillNo, string strGoodsNo, string strBatchNo, string strWarehouse, string strIsConsigning, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<EnterOutBalanceSummary> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadEnterOutBalanceSummariesByConditions(strStartTime, strEndTime, strCustomerName, strDeliveryNo, strEnterWarehouseBillNo, strGoodsNo, strBatchNo, strWarehouse, strIsConsigning, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据条件统计仓储力支费
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strIsConsigning"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<StatStorageAndForceFee> LoadStatStorageAndForceFeeByConditions(string strStartTime, string strEndTime, string strCustomerName, string strWarehouse, string strIsConsigning, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<StatStorageAndForceFee> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadStatStorageAndForceFeeByConditions(strStartTime, strEndTime, strCustomerName, strWarehouse, strIsConsigning, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据条件读取寄库计划发货数据
        /// </summary>
        /// <param name="strConsigningDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ConsigningDeliverPlanDeliverGoods> LoadConsigningDeliverPlanDeliverGoodsByConditions(string strConsigningDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ConsigningDeliverPlanDeliverGoods> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadConsigningDeliverPlanDeliverGoodsByConditions(strConsigningDeliveryNo, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取库存盘点数据
        /// </summary>
        /// <param name="strWarehouse"></param>
        /// <param name="strLocation"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Stock> LoadStocktakingByConditions(string strWarehouse, string strLocation, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Stock> ret = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        ret = dao.LoadStocktakingByConditions(strWarehouse, strLocation, nOpStaffId, strOpStaffName, out strErrText);
                        if (ret == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return ret;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增仓储力支费结算数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertCustomerStorageAndForceFeeSettlement(CustomerStorageAndForceFeeSettlement data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        nId = dao.InsertCustomerStorageAndForceFeeSettlement(data, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 根据综合条件读取仓储力支费结算数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strInvoiceNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerStorageAndForceFeeSettlement> LoadCustomerStorageAndForceFeeSettlementsByConditions(string strStartTime, string strEndTime, string strInvoiceNo, string strCustomerName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CustomerStorageAndForceFeeSettlement> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        dataResult = dao.LoadCustomerStorageAndForceFeeSettlementsByConditions(strStartTime, strEndTime, strInvoiceNo, strCustomerName, nOpStaffId, strOpStaffName, out strErrText);
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
        /// 删除仓储力支费结算数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCustomerStorageAndForceFeeSettlement(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        if (!dao.DeleteCustomerStorageAndForceFeeSettlement(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除入库单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteEnterWarehouseBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StockRule rule = new StockRule();
            return rule.DeleteEnterWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除出库单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteOutWarehouseBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            StockRule rule = new StockRule();
            return rule.DeleteOutWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 删除移库单数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteMoveWarehouseBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        if (!dao.DeleteMoveWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 读取库存尾差数据
        /// </summary>
        /// <param name="strCustomerName"></param>
        /// <param name="strGoodsId"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strIsConsigning"></param>
        /// <param name="strConsignedDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Stock> LoadStockEndDifferencesByConditions(string strCustomerName, string strGoodsId, string strWarehouse, string strIsConsigning, string strConsignedDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Stock> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        dataResult = dao.LoadStockEndDifferencesByConditions(strCustomerName, strGoodsId, strWarehouse, strIsConsigning, strConsignedDeliveryNo, nOpStaffId, strOpStaffName, out strErrText);
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
