using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace InnoSoft.LS.Business.Rules
{
    public class StatisticsRule
    {
        /// <summary>
        /// 修改综合查询数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="strShipmentNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nPayerId"></param>
        /// <param name="strPayerName"></param>
        /// <param name="nContractId"></param>
        /// <param name="strOriginalContractNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SyntheticalSearchModifyData(long nPlanId, string strShipmentNo, string strDeliveryNo, long nPayerId, string strPayerName, long nContractId, string strOriginalContractNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    //修改发货计划
                    using (PlanDAO dao = new PlanDAO())
                    {
                        DeliverPlan data = dao.LoadDeliverPlan(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                        {
                            return false;
                        }
                        data.ShipmentNo = strShipmentNo;
                        data.DeliveryNo = strDeliveryNo;
                        data.PayerId = nPayerId;
                        data.PayerName = strPayerName;
                        if (!dao.UpdateDeliverPlan(data, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }

                    //修改出仓单和送货单数据
                    using (DeliverDAO dao = new DeliverDAO())
                    {
                        List<ShipmentBill> listShipmentBill = dao.LoadShipmentBillsByPlanId(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                        foreach (ShipmentBill data in listShipmentBill)
                        {
                            if (!dao.UpdateShipmentBillDeliveryNo(data.Id, strDeliveryNo, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }

                        List<DeliverBill> listDeliverBill = dao.LoadDeliverBillsByPlanId(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                        foreach (DeliverBill data in listDeliverBill)
                        {
                            if (!dao.UpdateDeliverBillDeliveryNo(data.Id, strDeliveryNo, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }

                    //修改出库单、入库单和库存数据
                    using (StockDAO dao = new StockDAO())
                    {
                        List<OutWarehouseBill> listOutWarehouseBill = dao.LoadOutWarehouseBillsByPlanId(nPlanId, nOpStaffId, strOpStaffName, out strErrText);
                        foreach (OutWarehouseBill data in listOutWarehouseBill)
                        {
                            data.DeliveryNo = strDeliveryNo;
                            data.PayerId = nPayerId;
                            data.PayerName = strPayerName;
                            if (!dao.UpdateOutWarehouseBill(data, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }

                    //修改合同数据
                    using (ContractDAO dao = new ContractDAO())
                    {
                        if (nContractId > 0)
                        {
                            Contract data = dao.LoadContract(nContractId, nOpStaffId, strOpStaffName, out strErrText);
                            if (data == null)
                            {
                                return false;
                            }
                            data.OriginalContractNo = strOriginalContractNo;
                            if (!dao.UpdateContract(data, nOpStaffId, strOpStaffName, out strErrText))
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
    }
}
