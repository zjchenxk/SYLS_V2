using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class DeliverDAO : BaseDAO
    {
        /// <summary>
        /// 读取待打印调度出仓单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadPrintDispatchedShipmentBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ShipmentBill> list = LoadData<ShipmentBill>("LoadPrintDispatchedShipmentBills", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 提交指定的待打印出仓单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOutWarehouseBillId"></param>
        /// <param name="nEnterWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitPrintShipmentBill(long nId, out long nOutWarehouseBillId, out long nEnterWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OUTWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)0),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)0),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("SubmitPrintShipmentBill", Params, out outParams, out strErrText) < 0)
            {
                nOutWarehouseBillId = 0;
                nEnterWarehouseBillId = 0;
                return false;
            }
            else
            {
                nOutWarehouseBillId = (long)outParams[OUTWAREHOUSEBILLID_PARAM].Value;
                nEnterWarehouseBillId = (long)outParams[ENTERWAREHOUSEBILLID_PARAM].Value;
                return true;
            }
        }

        /// <summary>
        /// 读取待打印划拨出仓单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadPrintAllocateShipmentBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ShipmentBill> list = LoadData<ShipmentBill>("LoadPrintAllocateShipmentBills", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取待打印划拨出仓单货物数据
        /// </summary>
        /// <param name="nShipmentBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBillGoods> LoadShipmentBillAllGoods(long nShipmentBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(SHIPMENTBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nShipmentBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ShipmentBillGoods> list = LoadData<ShipmentBillGoods>("LoadShipmentBillAllGoods", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定出仓单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public ShipmentBill LoadShipmentBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ShipmentBill> list = LoadData<ShipmentBill>("LoadShipmentBill", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 读取待提交出仓单数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadSubmitShipmentBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ShipmentBill> list = LoadData<ShipmentBill>("LoadSubmitShipmentBills", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 修改出仓单货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateShipmentBillGoods(ShipmentBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(SHIPMENTBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ShipmentBillId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GoodsNo),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(PIECEWEIGHT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PieceWeight),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ProductionDate),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.EnterWarehouseBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateShipmentBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除出仓单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteShipmentBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteShipmentBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除出仓单货物数据
        /// </summary>
        /// <param name="nShipmentBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteShipmentBillAllGoods(long nShipmentBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(SHIPMENTBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nShipmentBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteShipmentBillAllGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 提交出仓单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitShipmentBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("SubmitShipmentBill", Params, out outParams, out strErrText) < 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 读取待打印送货单
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadPrintDeliverBills(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadPrintDeliverBills", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取送货单所有货物数据
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBillGoods> LoadDeliverBillAllGoods(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDeliverBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBillGoods> list = LoadData<DeliverBillGoods>("LoadDeliverBillAllGoods", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取送货单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBill LoadDeliverBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadDeliverBill", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 修改送货单货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverBillGoods(DeliverBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DeliverBillId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GoodsNo),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(PIECEWEIGHT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PieceWeight),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ProductionDate),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.EnterWarehouseBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateDeliverBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除送货单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDeliverBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除送货单货物数据
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverBillAllGoods(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDeliverBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDeliverBillAllGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 提交打印送货单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitPrintDeliverBill(long nId, out long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            nContractId = 0;
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)nContractId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            SqlParameterCollection outParams;
            if (Execute("SubmitPrintDeliverBill", Params, out outParams, out strErrText) < 0)
            {
                nContractId = 0;
                return false;
            }
            else
            {
                nContractId = (long)outParams[CONTRACTID_PARAM].Value;
                return true;
            }
        }

        /// <summary>
        /// 根据条件读取待接收回单送货单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadReceiptDeliverBillsByConditions(string strStartTime, string strEndTime, string strCustomerName, string strCarNo, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadReceiptDeliverBillsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 修改送货单回单信息
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="dtReturnTime"></param>
        /// <param name="strDamageInfo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverBillReceipt(long nId, DateTime dtReturnTime, string strDamageInfo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(RETURNTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)dtReturnTime),
                    MakeParam(DAMAGEINFO_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)strDamageInfo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateDeliverBillReceipt", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据送货单号读取所有送货单号数据
        /// </summary>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadDeliverBillNosByNo(string strDeliverBillNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDeliverBillNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadDeliverBillNosByNo", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定送货单号的送货单数据
        /// </summary>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBill LoadDeliverBillByNo(string strDeliverBillNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDeliverBillNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadDeliverBillByNo", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 根据综合条件读取送货单回单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strOrganId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadDeliverBillReceiptsByConditions(string strStartTime, string strEndTime, string strCustomerName, string strDeliveryNo, string strCarNo,
            string strDestCountry, string strDestProvince, string strDestCity, string strOrganId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo??System.DBNull.Value),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCountry??System.DBNull.Value),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestProvince??System.DBNull.Value),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCity??System.DBNull.Value),
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadDeliverBillReceiptsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据综合条件读取出仓单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strShipmentBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadShipmentBillsByConditions(string strStartTime, string strEndTime, string strShipmentBillNo, string strCustomerName, string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(SHIPMENTBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strShipmentBillNo??System.DBNull.Value),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ShipmentBill> list = LoadData<ShipmentBill>("LoadShipmentBillsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据综合条件读取送货单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strPayerName"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strOrganId"></param>
        /// <param name="strPrintState"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadDeliverBillsByConditions(string strStartTime, string strEndTime, string strDeliverBillNo, string strCustomerName, string strPayerName, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarNo, string strDeliveryNo, string strOrganId, string strPrintState, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(DELIVERBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliverBillNo??System.DBNull.Value),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(PAYERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPayerName??System.DBNull.Value),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCountry??System.DBNull.Value),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartProvince??System.DBNull.Value),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCity??System.DBNull.Value),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCountry??System.DBNull.Value),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestProvince??System.DBNull.Value),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCity??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo??System.DBNull.Value),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo??System.DBNull.Value),
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId??System.DBNull.Value),
                    MakeParam(PRINTSTATE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPrintState??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadDeliverBillsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定时间段内发货的办事处数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Organization> LoadDeliverBillsOwnOrgansByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Organization> list = LoadData<Organization>("LoadDeliverBillsOwnOrgansByTimespan", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定时间段内发货的付款单位数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Customer> LoadDeliverBillsPayersByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Customer> list = LoadData<Customer>("LoadDeliverBillsPayersByTimespan", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 修改出仓单交货单号
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateShipmentBillDeliveryNo(long nId, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateShipmentBillDeliveryNo", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改送货单交货单号
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverBillDeliveryNo(long nId, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateDeliverBillDeliveryNo", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据计划编码读取出仓单数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ShipmentBill> LoadShipmentBillsByPlanId(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ShipmentBill> list = LoadData<ShipmentBill>("LoadShipmentBillsByPlanId", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据计划编码读取送货单数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBill> LoadDeliverBillsByPlanId(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBill> list = LoadData<DeliverBill>("LoadDeliverBillsByPlanId", Params, out strErrText);
            return list;
        }

    }
}
