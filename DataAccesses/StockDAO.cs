using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class StockDAO : BaseDAO
    {
        /// <summary>
        /// 新增入库单数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertEnterWarehouseBill(EnterWarehouseBill data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??System.DBNull.Value),
                    MakeParam(ENTERTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.EnterType),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsConsigning),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse),
                    MakeParam(FORCEFEE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ForceFee),
                    MakeParam(HASDRAYAGE_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.HasDrayage),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertEnterWarehouseBill", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 修改入库单数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateEnterWarehouseBill(EnterWarehouseBill data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(BILLNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BillNo),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CustomerName),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??System.DBNull.Value),
                    MakeParam(ENTERTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.EnterType),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsConsigning),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse),
                    MakeParam(FORCEFEE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ForceFee),
                    MakeParam(HASDRAYAGE_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.HasDrayage),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateEnterWarehouseBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增入库货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertEnterWarehouseBillGoods(EnterWarehouseBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CustomerName),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GoodsNo),
                    MakeParam(GOODSNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.GoodsName),
                    MakeParam(BRAND_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Brand??string.Empty),
                    MakeParam(SPECMODEL_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.SpecModel),
                    MakeParam(GWEIGHT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GWeight??string.Empty),
                    MakeParam(GRADE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Grade??string.Empty),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location??string.Empty),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(PIECEWEIGHT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PieceWeight),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ProductionDate),
                    MakeParam(SHIPMENTBILLGOODSIDS_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.ShipmentBillGoodsIds??string.Empty),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.EnterWarehouseBillId),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??string.Empty),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertEnterWarehouseBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改入库单货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateEnterWarehouseBillGoods(EnterWarehouseBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CustomerName),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GoodsNo),
                    MakeParam(GOODSNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.GoodsName),
                    MakeParam(BRAND_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Brand??string.Empty),
                    MakeParam(SPECMODEL_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.SpecModel),
                    MakeParam(GWEIGHT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GWeight??string.Empty),
                    MakeParam(GRADE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Grade??string.Empty),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location??string.Empty),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(PIECEWEIGHT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PieceWeight),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ProductionDate),
                    MakeParam(SHIPMENTBILLGOODSIDS_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.ShipmentBillGoodsIds??string.Empty),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.EnterWarehouseBillId),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??string.Empty),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateEnterWarehouseBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除入库单货物数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteEnterWarehouseBillGoods(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteEnterWarehouseBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<OutWarehouseBill> list = LoadData<OutWarehouseBill>("LoadOutWarehouseBill", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OUTWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOutWarehouseBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<OutWarehouseBillGoods> list = LoadData<OutWarehouseBillGoods>("LoadOutWarehouseBillAllGoods", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增出库单数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertOutWarehouseBill(OutWarehouseBill data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CustomerName),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??System.DBNull.Value),
                    MakeParam(OUTTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.OutType),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverName),
                    MakeParam(RECEIVERCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCountry),
                    MakeParam(RECEIVERPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverProvince),
                    MakeParam(RECEIVERCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCity),
                    MakeParam(RECEIVERADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverAddress),
                    MakeParam(RECEIVERCONTACT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContact??System.DBNull.Value),
                    MakeParam(RECEIVERCONTACTTEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContactTel??System.DBNull.Value),
                    MakeParam(RECEIVETYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ReceiveType),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo??System.DBNull.Value),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CarrierName??System.DBNull.Value),
                    MakeParam(PAYERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PayerId),
                    MakeParam(PAYERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.PayerName),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsConsigning??System.DBNull.Value),
                    MakeParam(CONSIGNEDDELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ConsignedDeliveryNo??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse??string.Empty),
                    MakeParam(FORCEFEE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ForceFee),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertOutWarehouseBill", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增出库单货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertOutWarehouseBillGoods(OutWarehouseBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OUTWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OutWarehouseBillId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo??string.Empty),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location??string.Empty),
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

            if (Execute("InsertOutWarehouseBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改出库单数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateOutWarehouseBill(OutWarehouseBill data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(BILLNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BillNo),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CustomerName),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??System.DBNull.Value),
                    MakeParam(OUTTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.OutType),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverName),
                    MakeParam(RECEIVERCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCountry),
                    MakeParam(RECEIVERPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverProvince),
                    MakeParam(RECEIVERCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCity),
                    MakeParam(RECEIVERADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverAddress),
                    MakeParam(RECEIVERCONTACT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContact??System.DBNull.Value),
                    MakeParam(RECEIVERCONTACTTEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContactTel??System.DBNull.Value),
                    MakeParam(RECEIVETYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ReceiveType),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo??System.DBNull.Value),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CarrierName??System.DBNull.Value),
                    MakeParam(PAYERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PayerId),
                    MakeParam(PAYERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.PayerName),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsConsigning??System.DBNull.Value),
                    MakeParam(CONSIGNEDDELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ConsignedDeliveryNo??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse??string.Empty),
                    MakeParam(FORCEFEE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ForceFee),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateOutWarehouseBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改出库单货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateOutWarehouseBillGoods(OutWarehouseBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(OUTWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.OutWarehouseBillId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo??string.Empty),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location??string.Empty),
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

            if (Execute("UpdateOutWarehouseBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<EnterWarehouseBill> list = LoadData<EnterWarehouseBill>("LoadEnterWarehouseBill", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 根据发货计划编码读取入库单数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public EnterWarehouseBill LoadEnterWarehouseBillByPlanId(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<EnterWarehouseBill> list = LoadData<EnterWarehouseBill>("LoadEnterWarehouseBillByPlanId", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nEnterWarehouseBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<EnterWarehouseBillGoods> list = LoadData<EnterWarehouseBillGoods>("LoadEnterWarehouseBillAllGoods", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo??System.DBNull.Value),
                    MakeParam(ENTERWAREHOUSEBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEnterWarehouseBillNo??System.DBNull.Value),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsNo??System.DBNull.Value),
                    MakeParam(GOODSNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsName??System.DBNull.Value),
                    MakeParam(SPECMODEL_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)strSpecModel??System.DBNull.Value),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strBatchNo??System.DBNull.Value),
                    MakeParam(ENTERTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEnterType??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse??System.DBNull.Value),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strIsConsigning??System.DBNull.Value),
                    MakeParam(HASDRAYAGE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strHasDrayage??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<EnterWarehouseBillGoods> list = LoadData<EnterWarehouseBillGoods>("LoadEnterWarehouseBillGoodsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo??System.DBNull.Value),
                    MakeParam(OUTWAREHOUSEBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOutWarehouseBillNo??System.DBNull.Value),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsNo??System.DBNull.Value),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strBatchNo??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo??System.DBNull.Value),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)strReceiverName??System.DBNull.Value),
                    MakeParam(OUTTYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOutType??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse??System.DBNull.Value),
                    MakeParam(RECEIVETYPE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strReceiveType??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<OutWarehouseBillGoods> list = LoadData<OutWarehouseBillGoods>("LoadOutWarehouseBillGoodsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增移库记录
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertMoveWarehouseBill(MoveWarehouseBill bill, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)bill.Id),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)bill.CustomerId),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)bill.Warehouse),
                    MakeParam(CONSIGNEDDELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)bill.ConsignedDeliveryNo??System.DBNull.Value),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)bill.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertMoveWarehouseBill", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增入库货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertMoveWarehouseBillGoods(MoveWarehouseBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(MOVEWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.MoveWarehouseBillId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(PIECEWEIGHT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PieceWeight),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ProductionDate),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.EnterWarehouseBillId),
                    MakeParam(NEWLOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.NewLocation),
                    MakeParam(NEWPACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.NewPackages),
                    MakeParam(NEWTUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.NewTunnages),
                    MakeParam(NEWPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.NewPiles),
                    MakeParam(NEWTENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.NewTenThousands),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertMoveWarehouseBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(MOVEWAREHOUSEBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strMoveWarehouseBillNo??System.DBNull.Value),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsNo??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<MoveWarehouseBillGoods> list = LoadData<MoveWarehouseBillGoods>("LoadMoveWarehouseBillGoodsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo??System.DBNull.Value),
                    MakeParam(ENTERWAREHOUSEBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEnterWarehouseBillNo??System.DBNull.Value),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsNo??System.DBNull.Value),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strBatchNo??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse??System.DBNull.Value),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strIsConsigning??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<EnterOutBalanceSummary> list = LoadData<EnterOutBalanceSummary>("LoadEnterOutBalanceSummariesByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse??System.DBNull.Value),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strIsConsigning??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<StatStorageAndForceFee> list = LoadData<StatStorageAndForceFee>("LoadStatStorageAndForceFeeByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONSIGNEDDELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strConsigningDeliveryNo??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ConsigningDeliverPlanDeliverGoods> list = LoadData<ConsigningDeliverPlanDeliverGoods>("LoadConsigningDeliverPlanDeliverGoodsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse??System.DBNull.Value),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strLocation??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Stock> list = LoadData<Stock>("LoadStocktakingByConditions", Params, out strErrText);
            return list;
        }

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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerId),
                    MakeParam(GOODSID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsId),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strBatchNo),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPacking),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strLocation),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strProductionDate),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEnterWarehouseBillId),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Stock> list = LoadData<Stock>("LoadGoodsStocksByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据出仓单编码读取出库单数据
        /// </summary>
        /// <param name="nShipmentBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public OutWarehouseBill LoadOutWarehouseBillByShipmentBillId(long nShipmentBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(SHIPMENTBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nShipmentBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<OutWarehouseBill> list = LoadData<OutWarehouseBill>("LoadOutWarehouseBillByShipmentBillId", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 删除出库单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteOutWarehouseBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteOutWarehouseBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除出库单货物数据
        /// </summary>
        /// <param name="nOutWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteOutWarehouseBillAllGoods(long nOutWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OUTWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOutWarehouseBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteOutWarehouseBillAllGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(INVOICENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.InvoiceNo),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CustomerName),
                    MakeParam(INVOICETYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.InvoiceType),
                    MakeParam(INVOICEAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.InvoiceAmount),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertCustomerStorageAndForceFeeSettlement", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(INVOICENO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strInvoiceNo),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerStorageAndForceFeeSettlement> list = LoadData<CustomerStorageAndForceFeeSettlement>("LoadCustomerStorageAndForceFeeSettlementsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCustomerStorageAndForceFeeSettlement", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除入库单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteEnterWarehouseBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteEnterWarehouseBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除入库单货物数据
        /// </summary>
        /// <param name="nEnterWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteEnterWarehouseBillAllGoods(long nEnterWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nEnterWarehouseBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteEnterWarehouseBillAllGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteMoveWarehouseBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(GOODSID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsId),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strWarehouse),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strIsConsigning),
                    MakeParam(CONSIGNEDDELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strConsignedDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Stock> list = LoadData<Stock>("LoadStockEndDifferencesByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据入库单编码读取库存数据
        /// </summary>
        /// <param name="nEnterWarehouseBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Stock> LoadStocksByEnterWarehouseBillId(long nEnterWarehouseBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nEnterWarehouseBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Stock> list = LoadData<Stock>("LoadStocksByEnterWarehouseBillId", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 修改库存交货单号
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateStockDeliveryNo(long nId, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateStockDeliveryNo", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据计划编码读取出库单数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<OutWarehouseBill> LoadOutWarehouseBillsByPlanId(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<OutWarehouseBill> list = LoadData<OutWarehouseBill>("LoadOutWarehouseBillsByPlanId", Params, out strErrText);
            return list;
        }

    }
}
