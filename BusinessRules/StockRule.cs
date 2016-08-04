using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class StockRule
    {
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
            long nEnterWarehouseBillId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        //新增入库单数据
                        nEnterWarehouseBillId = dao.InsertEnterWarehouseBill(bill, nOpStaffId, strOpStaffName, out strErrText);
                        if (nEnterWarehouseBillId <= 0)
                            return 0;

                        //新增入库货物数据
                        foreach (EnterWarehouseBillGoods goods in listGoods)
                        {
                            goods.EnterWarehouseBillId = nEnterWarehouseBillId;

                            if (!dao.InsertEnterWarehouseBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }

                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        //修改下力支费价格数据
                        List<CustomerForceFeePrice> listForceFeePrice = dao.LoadCustomerForceFeePricesByCustomerId(bill.CustomerId, nOpStaffId, strOpStaffName, out strErrText);
                        if (listForceFeePrice.Count == 0)
                        {
                            //新增力支费价格数据
                            CustomerForceFeePrice data = new CustomerForceFeePrice();
                            data.CustomerId = bill.CustomerId;
                            data.StartTime = bill.CreateTime;
                            data.EndTime = DateTime.Parse("9999-12-31");
                            data.LoadingForceFeePrice = 0;
                            data.UnloadingForceFeePrice = bill.UnloadingForceFeePrice;

                            if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            int i = 0;
                            while (i < listForceFeePrice.Count)
                            {
                                if (bill.CreateTime.Date >= listForceFeePrice[i].StartTime.Date && bill.CreateTime.Date <= listForceFeePrice[i].EndTime.Date)
                                {
                                    break;
                                }
                                i++;
                            }
                            if (i < listForceFeePrice.Count)
                            {
                                //修改力支费价格数据
                                listForceFeePrice[i].UnloadingForceFeePrice = bill.UnloadingForceFeePrice;

                                if (!dao.UpdateCustomerForceFeePrice(listForceFeePrice[i], nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                //新增力支费价格数据
                                CustomerForceFeePrice data = new CustomerForceFeePrice();
                                data.CustomerId = bill.CustomerId;
                                data.StartTime = bill.CreateTime;
                                data.LoadingForceFeePrice = 0;
                                data.UnloadingForceFeePrice = bill.UnloadingForceFeePrice;

                                //计算截止时间
                                i = 0;
                                while (i < listForceFeePrice.Count)
                                {
                                    if (bill.CreateTime.Date < listForceFeePrice[i].StartTime.Date)
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                if (i < listForceFeePrice.Count)
                                {
                                    data.EndTime = listForceFeePrice[i].StartTime.Date.AddDays(-1);
                                }
                                else
                                {
                                    data.EndTime = DateTime.Parse("9999-12-31");
                                }

                                if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return 0;
                                }
                            }
                        }

                        //修改仓储费价格数据
                        List<CustomerStorageFeePrice> listStorageFeePrice = dao.LoadCustomerStorageFeePricesByCustomerId(bill.CustomerId, nOpStaffId, strOpStaffName, out strErrText);
                        if (listStorageFeePrice.Count == 0)
                        {
                            //新增仓储费价格数据
                            CustomerStorageFeePrice data = new CustomerStorageFeePrice();
                            data.CustomerId = bill.CustomerId;
                            data.StartTime = bill.CreateTime;
                            data.EndTime = DateTime.Parse("9999-12-31");
                            data.StorageFeePrice = bill.StorageFeePrice;

                            if (!dao.InsertCustomerStorageFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            int i = 0;
                            while (i < listStorageFeePrice.Count)
                            {
                                if (bill.CreateTime.Date >= listStorageFeePrice[i].StartTime.Date && bill.CreateTime.Date <= listStorageFeePrice[i].EndTime.Date)
                                {
                                    break;
                                }
                                i++;
                            }
                            if (i < listStorageFeePrice.Count)
                            {
                                //修改仓储费价格数据
                                listStorageFeePrice[i].StorageFeePrice = bill.StorageFeePrice;

                                if (!dao.UpdateCustomerStorageFeePrice(listStorageFeePrice[i], nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                //新增仓储费价格数据
                                CustomerStorageFeePrice data = new CustomerStorageFeePrice();
                                data.CustomerId = bill.CustomerId;
                                data.StartTime = bill.CreateTime;
                                data.StorageFeePrice = bill.StorageFeePrice;

                                //计算截止时间
                                i = 0;
                                while (i < listStorageFeePrice.Count)
                                {
                                    if (bill.CreateTime.Date < listStorageFeePrice[i].StartTime.Date)
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                if (i < listStorageFeePrice.Count)
                                {
                                    data.EndTime = listStorageFeePrice[i].StartTime.Date.AddDays(-1);
                                }
                                else
                                {
                                    data.EndTime = DateTime.Parse("9999-12-31");
                                }

                                if (!dao.InsertCustomerStorageFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return 0;
                                }
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nEnterWarehouseBillId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        //读取原入库单货物数据
                        List<EnterWarehouseBillGoods> listOldGoods = dao.LoadEnterWarehouseBillAllGoods(bill.Id, nOpStaffId, strOpStaffName, out strErrText);
                        if (listOldGoods == null)
                        {
                            return false;
                        }

                        //如果划拨计划所产生的入库单，则修改前必须检查新旧货物的数量
                        if (bill.PlanId > 0)
                        {
                            //检查每个品种数据
                            var grpOldGoods = listOldGoods.GroupBy(g => new { g.GoodsNo, g.BatchNo, g.Packing, g.ProductionDate, g.EnterWarehouseBillId });
                            foreach (var grpOld in grpOldGoods)
                            {
                                string strGoodsNo = grpOld.Key.GoodsNo;
                                string strBatchNo = grpOld.Key.BatchNo;
                                string strPacking = grpOld.Key.Packing;
                                string strProductionDate = grpOld.Key.ProductionDate;
                                long nEnterWarehouseBillId = grpOld.Key.EnterWarehouseBillId;
                                int nOldTotalPackages = grpOld.Sum(s => s.Packages);
                                decimal decOldTotalTunnages = grpOld.Sum(s => s.Tunnages);

                                List<EnterWarehouseBillGoods> listNew = listGoods.Where(g => g.GoodsNo == strGoodsNo && g.BatchNo == strBatchNo && (g.Packing ?? string.Empty) == strPacking && g.ProductionDate == strProductionDate && g.EnterWarehouseBillId == nEnterWarehouseBillId).ToList();
                                if (nOldTotalPackages != listNew.Sum(g => g.Packages) || decOldTotalTunnages != listNew.Sum(g => g.Tunnages))
                                {
                                    strErrText = string.Format(InnoSoft.LS.Resources.Strings.GoodsModifyBeforeAndAfterPackagesOrTunnagesNotEqual, strGoodsNo, strBatchNo, strPacking, strProductionDate);
                                    return false;
                                }
                            }

                            //检查总数量
                            if (listGoods.Sum(g => g.Packages) != listOldGoods.Sum(g => g.Packages) || listGoods.Sum(g => g.Tunnages) != listOldGoods.Sum(g => g.Tunnages))
                            {
                                strErrText = InnoSoft.LS.Resources.Strings.GoodsModifyBeforeAndAfterTotalPackagesOrTotalTunnagesNotEqual;
                                return false;
                            }
                        }

                        //新增入库货物数据
                        foreach (EnterWarehouseBillGoods goods in listGoods)
                        {
                            if (goods.Id == 0)
                            {
                                if (!dao.InsertEnterWarehouseBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }

                        //修改入库货物数据
                        foreach (EnterWarehouseBillGoods goods in listGoods)
                        {
                            if (goods.Id > 0)
                            {
                                if (!dao.UpdateEnterWarehouseBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }

                        //删除入库单货物数据
                        foreach (EnterWarehouseBillGoods o in listOldGoods)
                        {
                            if (listGoods.FindAll(delegate(EnterWarehouseBillGoods g) { return g.Id == o.Id; }).Count == 0)
                            {
                                if (!dao.DeleteEnterWarehouseBillGoods(o.Id, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }

                        //修改入库单数据
                        if (!dao.UpdateEnterWarehouseBill(bill, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        //修改下力支费价格数据
                        List<CustomerForceFeePrice> listForceFeePrice = dao.LoadCustomerForceFeePricesByCustomerId(bill.CustomerId, nOpStaffId, strOpStaffName, out strErrText);
                        if (listForceFeePrice.Count == 0)
                        {
                            //新增力支费价格数据
                            CustomerForceFeePrice data = new CustomerForceFeePrice();
                            data.CustomerId = bill.CustomerId;
                            data.StartTime = bill.CreateTime;
                            data.EndTime = DateTime.Parse("9999-12-31");
                            data.LoadingForceFeePrice = 0;
                            data.UnloadingForceFeePrice = bill.UnloadingForceFeePrice;

                            if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            int i = 0;
                            while (i < listForceFeePrice.Count)
                            {
                                if (bill.CreateTime.Date >= listForceFeePrice[i].StartTime.Date && bill.CreateTime.Date <= listForceFeePrice[i].EndTime.Date)
                                {
                                    break;
                                }
                                i++;
                            }
                            if (i < listForceFeePrice.Count)
                            {
                                //修改力支费价格数据
                                listForceFeePrice[i].UnloadingForceFeePrice = bill.UnloadingForceFeePrice;

                                if (!dao.UpdateCustomerForceFeePrice(listForceFeePrice[i], nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                //新增力支费价格数据
                                CustomerForceFeePrice data = new CustomerForceFeePrice();
                                data.CustomerId = bill.CustomerId;
                                data.StartTime = bill.CreateTime;
                                data.LoadingForceFeePrice = 0;
                                data.UnloadingForceFeePrice = bill.UnloadingForceFeePrice;

                                //计算截止时间
                                i = 0;
                                while (i < listForceFeePrice.Count)
                                {
                                    if (bill.CreateTime.Date < listForceFeePrice[i].StartTime.Date)
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                if (i < listForceFeePrice.Count)
                                {
                                    data.EndTime = listForceFeePrice[i].StartTime.Date.AddDays(-1);
                                }
                                else
                                {
                                    data.EndTime = DateTime.Parse("9999-12-31");
                                }

                                if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }

                        //修改仓储费价格数据
                        List<CustomerStorageFeePrice> listStorageFeePrice = dao.LoadCustomerStorageFeePricesByCustomerId(bill.CustomerId, nOpStaffId, strOpStaffName, out strErrText);
                        if (listStorageFeePrice.Count == 0)
                        {
                            //新增仓储费价格数据
                            CustomerStorageFeePrice data = new CustomerStorageFeePrice();
                            data.CustomerId = bill.CustomerId;
                            data.StartTime = bill.CreateTime;
                            data.EndTime = DateTime.Parse("9999-12-31");
                            data.StorageFeePrice = bill.StorageFeePrice;

                            if (!dao.InsertCustomerStorageFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            int i = 0;
                            while (i < listStorageFeePrice.Count)
                            {
                                if (bill.CreateTime.Date >= listStorageFeePrice[i].StartTime.Date && bill.CreateTime.Date <= listStorageFeePrice[i].EndTime.Date)
                                {
                                    break;
                                }
                                i++;
                            }
                            if (i < listStorageFeePrice.Count)
                            {
                                //修改仓储费价格数据
                                listStorageFeePrice[i].StorageFeePrice = bill.StorageFeePrice;

                                if (!dao.UpdateCustomerStorageFeePrice(listStorageFeePrice[i], nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                //新增仓储费价格数据
                                CustomerStorageFeePrice data = new CustomerStorageFeePrice();
                                data.CustomerId = bill.CustomerId;
                                data.StartTime = bill.CreateTime;
                                data.StorageFeePrice = bill.StorageFeePrice;

                                //计算截止时间
                                i = 0;
                                while (i < listStorageFeePrice.Count)
                                {
                                    if (bill.CreateTime.Date < listStorageFeePrice[i].StartTime.Date)
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                if (i < listStorageFeePrice.Count)
                                {
                                    data.EndTime = listStorageFeePrice[i].StartTime.Date.AddDays(-1);
                                }
                                else
                                {
                                    data.EndTime = DateTime.Parse("9999-12-31");
                                }

                                if (!dao.InsertCustomerStorageFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
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
            long nOutWarehouseBillId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        //新增出库单数据
                        nOutWarehouseBillId = dao.InsertOutWarehouseBill(bill, nOpStaffId, strOpStaffName, out strErrText);
                        if (nOutWarehouseBillId <= 0)
                            return 0;

                        //新增出库货物数据
                        foreach (OutWarehouseBillGoods goods in listGoods)
                        {
                            goods.OutWarehouseBillId = nOutWarehouseBillId;

                            if (!dao.InsertOutWarehouseBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }

                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        //修改上力支费价格数据
                        List<CustomerForceFeePrice> listForceFeePrice = dao.LoadCustomerForceFeePricesByCustomerId(bill.CustomerId, nOpStaffId, strOpStaffName, out strErrText);
                        if (listForceFeePrice.Count == 0)
                        {
                            //新增力支费价格数据
                            CustomerForceFeePrice data = new CustomerForceFeePrice();
                            data.CustomerId = bill.CustomerId;
                            data.StartTime = bill.CreateTime;
                            data.EndTime = DateTime.Parse("9999-12-31");
                            data.LoadingForceFeePrice = bill.LoadingForceFeePrice;
                            data.UnloadingForceFeePrice = 0;

                            if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            int i = 0;
                            while (i < listForceFeePrice.Count)
                            {
                                if (bill.CreateTime.Date >= listForceFeePrice[i].StartTime.Date && bill.CreateTime.Date <= listForceFeePrice[i].EndTime.Date)
                                {
                                    break;
                                }
                                i++;
                            }
                            if (i < listForceFeePrice.Count)
                            {
                                //修改力支费价格数据
                                listForceFeePrice[i].LoadingForceFeePrice = bill.LoadingForceFeePrice;

                                if (!dao.UpdateCustomerForceFeePrice(listForceFeePrice[i], nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                //新增力支费价格数据
                                CustomerForceFeePrice data = new CustomerForceFeePrice();
                                data.CustomerId = bill.CustomerId;
                                data.StartTime = bill.CreateTime;
                                data.LoadingForceFeePrice = bill.LoadingForceFeePrice;
                                data.UnloadingForceFeePrice = 0;

                                //计算截止时间
                                i = 0;
                                while (i < listForceFeePrice.Count)
                                {
                                    if (bill.CreateTime.Date < listForceFeePrice[i].StartTime.Date)
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                if (i < listForceFeePrice.Count)
                                {
                                    data.EndTime = listForceFeePrice[i].StartTime.Date.AddDays(-1);
                                }
                                else
                                {
                                    data.EndTime = DateTime.Parse("9999-12-31");
                                }

                                if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return 0;
                                }
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nOutWarehouseBillId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        //修改出库单数据
                        if (!dao.UpdateOutWarehouseBill(bill, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //修改出库货物数据
                        foreach (OutWarehouseBillGoods goods in listGoods)
                        {
                            if (!dao.UpdateOutWarehouseBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }

                    using (CustomerDAO dao = new CustomerDAO())
                    {
                        //修改上力支费价格数据
                        List<CustomerForceFeePrice> listForceFeePrice = dao.LoadCustomerForceFeePricesByCustomerId(bill.CustomerId, nOpStaffId, strOpStaffName, out strErrText);
                        if (listForceFeePrice.Count == 0)
                        {
                            //新增力支费价格数据
                            CustomerForceFeePrice data = new CustomerForceFeePrice();
                            data.CustomerId = bill.CustomerId;
                            data.StartTime = bill.CreateTime;
                            data.EndTime = DateTime.Parse("9999-12-31");
                            data.LoadingForceFeePrice = bill.LoadingForceFeePrice;
                            data.UnloadingForceFeePrice = 0;

                            if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            int i = 0;
                            while (i < listForceFeePrice.Count)
                            {
                                if (bill.CreateTime.Date >= listForceFeePrice[i].StartTime.Date && bill.CreateTime.Date <= listForceFeePrice[i].EndTime.Date)
                                {
                                    break;
                                }
                                i++;
                            }
                            if (i < listForceFeePrice.Count)
                            {
                                //修改力支费价格数据
                                listForceFeePrice[i].LoadingForceFeePrice = bill.LoadingForceFeePrice;

                                if (!dao.UpdateCustomerForceFeePrice(listForceFeePrice[i], nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                //新增力支费价格数据
                                CustomerForceFeePrice data = new CustomerForceFeePrice();
                                data.CustomerId = bill.CustomerId;
                                data.StartTime = bill.CreateTime;
                                data.LoadingForceFeePrice = bill.LoadingForceFeePrice;
                                data.UnloadingForceFeePrice = 0;

                                //计算截止时间
                                i = 0;
                                while (i < listForceFeePrice.Count)
                                {
                                    if (bill.CreateTime.Date < listForceFeePrice[i].StartTime.Date)
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                if (i < listForceFeePrice.Count)
                                {
                                    data.EndTime = listForceFeePrice[i].StartTime.Date.AddDays(-1);
                                }
                                else
                                {
                                    data.EndTime = DateTime.Parse("9999-12-31");
                                }

                                if (!dao.InsertCustomerForceFeePrice(data, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
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
            long nMoveWarehouseBillId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        //新增移库单数据
                        nMoveWarehouseBillId = dao.InsertMoveWarehouseBill(bill, nOpStaffId, strOpStaffName, out strErrText);
                        if (nMoveWarehouseBillId <= 0)
                            return 0;

                        //新增移库货物数据
                        foreach (MoveWarehouseBillGoods goods in listGoods)
                        {
                            goods.MoveWarehouseBillId = nMoveWarehouseBillId;

                            if (!dao.InsertMoveWarehouseBillGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nMoveWarehouseBillId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        //如果入库单是由划拨出库自动生成的，则不允许手工删除
                        EnterWarehouseBill bill = dao.LoadEnterWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }
                        if (bill.PlanId > 0)
                        {
                            strErrText = InnoSoft.LS.Resources.Strings.CanNotDeleteEnterWarehouseBillCreateByAllocateGoods;
                            return false;
                        }

                        //删除入库单货物数据
                        if (!dao.DeleteEnterWarehouseBillAllGoods(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除入库单数据
                        if (!dao.DeleteEnterWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText))
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
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (StockDAO dao = new StockDAO())
                    {
                        //如果出库单是由出仓单自动生成的，则不允许手工删除
                        OutWarehouseBill bill = dao.LoadOutWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (bill == null)
                        {
                            return false;
                        }
                        if (bill.ShipmentBillId > 0)
                        {
                            strErrText = InnoSoft.LS.Resources.Strings.CanNotDeleteOutWarehouseBillCreateByShipmentBill;
                            return false;
                        }

                        //删除出库单数据
                        if (!dao.DeleteOutWarehouseBill(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除出库单货物数据
                        if (!dao.DeleteOutWarehouseBillAllGoods(nId, nOpStaffId, strOpStaffName, out strErrText))
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
