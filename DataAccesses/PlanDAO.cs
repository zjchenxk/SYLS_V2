using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class PlanDAO : BaseDAO
    {
        /// <summary>
        /// 读取待提交的计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadSubmitDeliverPlans(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadSubmitDeliverPlans", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取待客户审批的纸发货计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadCustomerApproveDeliverPlans(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadCustomerApproveDeliverPlans", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定计划数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverPlan LoadDeliverPlan(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadDeliverPlan", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 读取指定计划的所有货物数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlanGoods> LoadDeliverPlanAllGoods(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlanGoods> list = LoadData<DeliverPlanGoods>("LoadDeliverPlanAllGoods", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增计划
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public long InsertDeliverPlan(DeliverPlan data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PlanType),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(SHIPMENTNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ShipmentNo??System.DBNull.Value),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??System.DBNull.Value),
                    MakeParam(DELIVERTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.DeliverType),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverName),
                    MakeParam(RECEIVERCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCountry),
                    MakeParam(RECEIVERPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverProvince),
                    MakeParam(RECEIVERCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCity),
                    MakeParam(RECEIVERADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverAddress),
                    MakeParam(RECEIVERCONTACT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContact??System.DBNull.Value),
                    MakeParam(RECEIVERCONTACTTEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContactTel??System.DBNull.Value),
                    MakeParam(ORDERNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.OrderNo??System.DBNull.Value),
                    MakeParam(RECEIVETYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ReceiveType),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo??System.DBNull.Value),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(DRIVERNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverName??System.DBNull.Value),
                    MakeParam(DRIVERLICENSENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverLicenseNo??System.DBNull.Value),
                    MakeParam(DRIVERMOBILETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverMobileTel??System.DBNull.Value),
                    MakeParam(DRIVERHOMETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverHomeTel??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse??string.Empty),
                    MakeParam(ARRIVALTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ArrivalTime??System.DBNull.Value),
                    MakeParam(PAYERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PayerId),
                    MakeParam(PAYERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.PayerName),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsConsigning??System.DBNull.Value),
                    MakeParam(CONSIGNEDDELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ConsignedDeliveryNo??System.DBNull.Value),
                    MakeParam(ISINSTALMENT_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsInstalment??System.DBNull.Value),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCity),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertDeliverPlan", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增计划货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertDeliverPlanGoods(DeliverPlanGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(BATCHNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.BatchNo??string.Empty),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??string.Empty),
                    MakeParam(LOCATION_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Location??string.Empty),
                    MakeParam(PACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.Packages),
                    MakeParam(PIECEWEIGHT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PieceWeight??System.DBNull.Value),
                    MakeParam(TUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Tunnages),
                    MakeParam(PILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.Piles),
                    MakeParam(TENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TenThousands),
                    MakeParam(PRODUCTIONDATE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ProductionDate??string.Empty),
                    MakeParam(ENTERWAREHOUSEBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.EnterWarehouseBillId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertDeliverPlanGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改计划
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool UpdateDeliverPlan(DeliverPlan data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PlanType),
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerId),
                    MakeParam(SHIPMENTNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ShipmentNo??System.DBNull.Value),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DeliveryNo??System.DBNull.Value),
                    MakeParam(DELIVERTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.DeliverType),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverName),
                    MakeParam(RECEIVERCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCountry),
                    MakeParam(RECEIVERPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverProvince),
                    MakeParam(RECEIVERCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverCity),
                    MakeParam(RECEIVERADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverAddress),
                    MakeParam(RECEIVERCONTACT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContact??System.DBNull.Value),
                    MakeParam(RECEIVERCONTACTTEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ReceiverContactTel??System.DBNull.Value),
                    MakeParam(ORDERNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.OrderNo??System.DBNull.Value),
                    MakeParam(RECEIVETYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ReceiveType),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo??System.DBNull.Value),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(DRIVERNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverName??System.DBNull.Value),
                    MakeParam(DRIVERLICENSENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverLicenseNo??System.DBNull.Value),
                    MakeParam(DRIVERMOBILETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverMobileTel??System.DBNull.Value),
                    MakeParam(DRIVERHOMETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverHomeTel??System.DBNull.Value),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Warehouse??string.Empty),
                    MakeParam(ARRIVALTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.ArrivalTime??System.DBNull.Value),
                    MakeParam(PAYERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PayerId),
                    MakeParam(PAYERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.PayerName),
                    MakeParam(ISCONSIGNING_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsConsigning??System.DBNull.Value),
                    MakeParam(CONSIGNEDDELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ConsignedDeliveryNo??System.DBNull.Value),
                    MakeParam(ISINSTALMENT_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsInstalment??System.DBNull.Value),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCity),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.CreateTime),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定计划的所有货物数据
        /// </summary>
        /// <param name="nPlanId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverPlanAllGoods(long nPlanId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDeliverPlanAllGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 提交发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="bIsAgreed"></param>
        /// <param name="strApproveComment"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool SubmitDeliverPlan(long nId, bool bIsAgreed, string strApproveComment, long nOpStaffId, string strOpStaffName, out string strMessage)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(ISAGREED_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)bIsAgreed),
                    MakeParam(APPROVECOMMENT_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)strApproveComment),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("SubmitDeliverPlan", Params, out strMessage) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 客户同意计划
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CustomerAgreeDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("CustomerAgreeDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 客户不同意计划
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="strDisagreeOpinion"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CustomerDisagreeDeliverPlan(long nId, string strDisagreeOpinion, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(APPROVECOMMENT_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)strDisagreeOpinion),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("CustomerDisagreeDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 读取待审批的纸发货计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadApproveDeliverPlans(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadApproveDeliverPlans", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据综合条件读取发货计划数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strShipmentNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strDeliverType"></param>
        /// <param name="strReceiverName"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strGoodsNo"></param>
        /// <param name="strPlanNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadDeliverPlansByConditions(string strStartTime, string strEndTime, string strCustomerName, string strShipmentNo, string strDeliveryNo, string strDeliverType, string strReceiverName, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarNo, string strGoodsNo, string strPlanNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(SHIPMENTNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strShipmentNo),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(DELIVERTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strDeliverType),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strReceiverName),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCity),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strGoodsNo),
                    MakeParam(PLANNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strPlanNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadDeliverPlansByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取全部待调度发货计划数据
        /// </summary>
        /// <param name="strOrganId"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strShipmentNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="strReceiverName"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strArrivalTime"></param>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadDispatchDeliverPlans(string strOrganId, string strCustomerName, string strShipmentNo, string strDeliveryNo, string strReceiverName, string strDestCountry, string strDestProvince, string strDestCity, string strWarehouse, string strArrivalTime, string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(SHIPMENTNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strShipmentNo),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strReceiverName),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCity),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strWarehouse),
                    MakeParam(ARRIVALTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strArrivalTime),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadDispatchDeliverPlans", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取外地来货计划数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadForeignDeliverPlans(int nPageIndex, int nRowCount, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam("@PageIndex", SqlDbType.Int, 4, ParameterDirection.Input, (object)nPageIndex),
                    MakeParam("@RowCount", SqlDbType.Int, 4, ParameterDirection.Input, (object)nRowCount),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadForeignDeliverPlans", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 取消发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool CancelDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("CancelDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 读取指定货物编码、客户编码、寄库交货单号、仓库和批次号的所有计划货物结存数据
        /// </summary>
        /// <param name="strCustomerId"></param>
        /// <param name="strGoodsId"></param>
        /// <param name="strBatchNo"></param>
        /// <param name="strPacking"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="strLocation"></param>
        /// <param name="strProductionDate"></param>
        /// <param name="strEnterWarehouseBillId"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlanGoods> LoadDeliverPlanGoodsBalancesByConditions(string strCustomerId, string strGoodsId, string strBatchNo, string strPacking, string strWarehouse, string strLocation, string strProductionDate, string strEnterWarehouseBillId, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
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

            List<DeliverPlanGoods> list = LoadData<DeliverPlanGoods>("LoadDeliverPlanGoodsBalancesByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定客户编码和仓库的待调度计划
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <param name="strWarehouse"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverPlan> LoadDispatchDeliverPlansByCustomerIdAndWarehouse(long nCustomerId, string strWarehouse, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERID_PARAM, SqlDbType.BigInt, 50, ParameterDirection.Input, (object)nCustomerId),
                    MakeParam(WAREHOUSE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strWarehouse),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverPlan> list = LoadData<DeliverPlan>("LoadDispatchDeliverPlansByCustomerIdAndWarehouse", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 复制发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long CopyDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nNewPlanId = 0;

            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(NEWPLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)nNewPlanId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("CopyDeliverPlan", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[NEWPLANID_PARAM].Value;
            }
        }

        /// <summary>
        /// 退回修改发货计划数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool ReturnDeliverPlan(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("ReturnDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }



    }
}
