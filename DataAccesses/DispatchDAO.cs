using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class DispatchDAO : BaseDAO
    {
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillDeliverPlan> list = LoadData<DispatchBillDeliverPlan>("LoadDispatchBillDeliverPlansByCarNo", Params, out strErrText);
            return list;
        }

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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPlanId),
                    MakeParam(GOODSID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsId),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strBatchNo),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPacking),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strLocation),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strProductionDate),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEnterWarehouseBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadAllDispatchBillGoodsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchPaperPlanAllGoods", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchCanPlanAllGoods", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchDeliverPlanAllGoods", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增调度单数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertDispatchBill(DispatchBill data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.InputOutput, (object)data.Id),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.CarType??string.Empty),
                    MakeParam(DRIVERNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverName),
                    MakeParam(DRIVERLICENSENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverLicenseNo),
                    MakeParam(DRIVERMOBILETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverMobileTel),
                    MakeParam(DRIVERHOMETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverHomeTel??string.Empty),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId??System.DBNull.Value),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CarrierName),
                    MakeParam(CARRYINGCAPACITY_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.CarryingCapacity),
                    MakeParam(BUSINESSTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.BusinessType),
                    MakeParam(PAYMENTTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PaymentType),
                    MakeParam(TOTALPACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.TotalPackages),
                    MakeParam(TOTALTUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTunnages),
                    MakeParam(TOTALPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalPiles),
                    MakeParam(TOTALTENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTenThousands),
                    MakeParam(TOTALTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTransportCharges),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertDispatchBill", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增调度计划数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertDispatchBillDeliverPlan(DispatchBillDeliverPlan data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(TRANSPORTCHARGEEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.TransportChargeExpression??System.DBNull.Value),
                    MakeParam(TRANSPORTPRICEEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.TransportPriceExpression??System.DBNull.Value),
                    MakeParam(KM_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.KM),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
                    MakeParam(RECEIVETYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ReceiveType??System.DBNull.Value),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertDispatchBillDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增调度单货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertDispatchBillGoods(DispatchBillGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo??string.Empty),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location??string.Empty),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(PIECEWEIGHT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PieceWeight),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ProductionDate??string.Empty),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.EnterWarehouseBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertDispatchBillGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查调度单数据
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CheckDispatchBill(long Id, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)Id),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("CheckDispatchBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBill> list = LoadData<DispatchBill>("LoadSubmitDispatchBillByCarNo", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBill> list = LoadData<DispatchBill>("LoadSubmitDispatchBills", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillDeliverPlan> list = LoadData<DispatchBillDeliverPlan>("LoadDispatchBillDeliverPlan", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillDeliverPlan> list = LoadData<DispatchBillDeliverPlan>("LoadDispatchBillDeliverPlans", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchBillAllGoods", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchBillAllGoodsByPlanId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchBillAllGoodsByCarNo", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchBillAllGoodsByCarNoAndPlanId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDispatchBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定调度单的指定调度计划数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchBillDeliverPlan(long nDispatchBillId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDispatchBillDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定的调度单的所有计划数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchBillDeliverPlans(long nDispatchBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDispatchBillDeliverPlans", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定的调度单的所有货物数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchBillAllGoods(long nDispatchBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDispatchBillAllGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchedDeliverPlanAllGoods", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 修改调度计划数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDispatchBillDeliverPlan(DispatchBillDeliverPlan data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(TRANSPORTCHARGEEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.TransportChargeExpression??System.DBNull.Value),
                    MakeParam(TRANSPORTPRICEEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.TransportPriceExpression??System.DBNull.Value),
                    MakeParam(KM_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.KM),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateDispatchBillDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定调度单编码和计划编码的所有货物数据
        /// </summary>
        /// <param name="nDispatchBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDispatchBillDeliverPlanAllGoods(long nDispatchBillId, long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDispatchBillDeliverPlanAllGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBill> list = LoadData<DispatchBill>("LoadDispatchBill", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 修改调度单数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDispatchBill(DispatchBill data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.CarType??string.Empty),
                    MakeParam(DRIVERNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverName),
                    MakeParam(DRIVERLICENSENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverLicenseNo),
                    MakeParam(DRIVERMOBILETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverMobileTel),
                    MakeParam(DRIVERHOMETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverHomeTel??string.Empty),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId??System.DBNull.Value),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CarrierName),
                    MakeParam(CARRYINGCAPACITY_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.CarryingCapacity),
                    MakeParam(BUSINESSTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.BusinessType),
                    MakeParam(PAYMENTTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PaymentType),
                    MakeParam(TOTALPACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.TotalPackages),
                    MakeParam(TOTALTUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTunnages),
                    MakeParam(TOTALPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalPiles),
                    MakeParam(TOTALTENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTenThousands),
                    MakeParam(TOTALTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTransportCharges),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateDispatchBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 提交指定调度单数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitDispatchBill(long nId, out long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            nContractId = 0;
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)nContractId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("SubmitDispatchBill", Params, out outParams, out strErrText) < 0)
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
        /// 取消调度单
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CancelDispatchBill(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("CancelDispatchBill", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBill> list = LoadData<DispatchBill>("LoadContractDispatchBills", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DispatchBillGoods> list = LoadData<DispatchBillGoods>("LoadDispatchBillAllGoodsByContractIdAndPlanId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(IDS_PARAM, SqlDbType.NVarChar, 2000, ParameterDirection.Input, (object)strIds),
                    MakeParam(NEWID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)0),
                    MakeParam(SHIPMENTBILLMERGED_PARAM, SqlDbType.Bit, 1, ParameterDirection.Output, (object)0),
                    MakeParam(DELIVERBILLMERGED_PARAM, SqlDbType.Bit, 1, ParameterDirection.Output, (object)0),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("MergeDispatchBills", Params, out outParams, out strErrText) < 0)
            {
                bShipmentBillMerged = false;
                bDeliverBillMerged = false;

                return 0;
            }
            else
            {
                bShipmentBillMerged = (bool)outParams[SHIPMENTBILLMERGED_PARAM].Value;
                bDeliverBillMerged = (bool)outParams[DELIVERBILLMERGED_PARAM].Value; ;

                return (long)outParams[NEWID_PARAM].Value;
            }
        }

    }
}
