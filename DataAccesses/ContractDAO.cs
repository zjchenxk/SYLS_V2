using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class ContractDAO : BaseDAO
    {
        /// <summary>
        /// 新增合同数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertContract(Contract data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.InputOutput, (object)data.Id),
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DispatchBillId),
                    MakeParam(ORIGINALCONTRACTNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.OriginalContractNo??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.CarType??string.Empty),
                    MakeParam(DRIVERNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverName),
                    MakeParam(DRIVERLICENSENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverLicenseNo),
                    MakeParam(DRIVERMOBILETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverMobileTel),
                    MakeParam(DRIVERHOMETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverHomeTel??string.Empty),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId??System.DBNull.Value),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CarrierName),
                    MakeParam(GOODSNAME_PARAM, SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)data.GoodsName),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Packing??System.DBNull.Value),
                    MakeParam(STARTPLACE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartPlace),
                    MakeParam(DESTPLACE_PARAM, SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)data.DestPlace),
                    MakeParam(SHIPMENTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.ShipmentTime),
                    MakeParam(ARRIVALTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.ArrivalTime),
                    MakeParam(TOTALPACKAGES_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.TotalPackages),
                    MakeParam(TOTALTUNNAGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTunnages),
                    MakeParam(TOTALPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalPiles),
                    MakeParam(TOTALTENTHOUSANDS_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTenThousands),
                    MakeParam(TOTALTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TotalTransportCharges),
                    MakeParam(PREPAYTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PrepayTransportCharges),
                    MakeParam(RESIDUALTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ResidualTransportCharges),
                    MakeParam(ISPRESTOWAGE_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsPrestowage),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertContract", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增合同发货数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertContractDeliverPlan(ContractDeliverPlan data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ContractId),
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

            if (Execute("InsertContractDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadSubmitContracts", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadContract", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 读取指定合同的发货数据
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ContractDeliverPlan> LoadContractDeliverPlans(long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ContractDeliverPlan> list = LoadData<ContractDeliverPlan>("LoadContractDeliverPlans", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(ORIGINALCONTRACTNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.OriginalContractNo??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.CarType??string.Empty),
                    MakeParam(DRIVERNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverName),
                    MakeParam(DRIVERLICENSENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverLicenseNo),
                    MakeParam(DRIVERMOBILETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverMobileTel),
                    MakeParam(DRIVERHOMETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DriverHomeTel??string.Empty),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId??System.DBNull.Value),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CarrierName),
                    MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Packing??System.DBNull.Value),
                    MakeParam(SHIPMENTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.ShipmentTime),
                    MakeParam(ARRIVALTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.ArrivalTime),
                    MakeParam(PREPAYTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.PrepayTransportCharges),
                    MakeParam(RESIDUALTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ResidualTransportCharges),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateContract", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改合同发货计划数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractDeliverPlan(ContractDeliverPlan data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ContractId),
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

            if (Execute("UpdateContractDeliverPlan", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改合同货物数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractGoods(ContractGoods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DISPATCHBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DispatchBillId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(GOODSID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.GoodsId),
                    MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GoodsNo),
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

            if (Execute("UpdateContractGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteContract", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除合同发货数据
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteContractDeliverPlans(long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteContractDeliverPlans", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("SubmitContract", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadPrintContracts", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 提交打印合同数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool SubmitPrintContract(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("SubmitPrintContract", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改合同审批人
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nApproveFlowStepNum"></param>
        /// <param name="strApproveFlowStepName"></param>
        /// <param name="nApproverId"></param>
        /// <param name="strApproverName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractApprover(long nId, int nApproveFlowStepNum, string strApproveFlowStepName, long nApproverId, string strApproverName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(APPROVEFLOWSTEPNUM_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)nApproveFlowStepNum),
                    MakeParam(APPROVEFLOWSTEPNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strApproveFlowStepName),
                    MakeParam(APPROVERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nApproverId),
                    MakeParam(APPROVERNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strApproverName),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateContractApprover", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strContractNo??System.DBNull.Value),
                    MakeParam(ORIGINALCONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOriginalContractNo??System.DBNull.Value),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCountry??System.DBNull.Value),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestProvince??System.DBNull.Value),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCity??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo??System.DBNull.Value),
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadApproveContractsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 修改合同审批状态数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractApproveState(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateContractApproveState", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改合同审批价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractDeliverPlanApprovedTransportPrice(ContractDeliverPlan data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ContractId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.PlanId),
                    MakeParam(APPROVEDTRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ApprovedTransportPrice),
                    MakeParam(APPROVEDTRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ApprovedTransportCharges),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateContractDeliverPlanApprovedTransportPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strContractNo??System.DBNull.Value),
                    MakeParam(ORIGINALCONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOriginalContractNo??System.DBNull.Value),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarrierName??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo??System.DBNull.Value),
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadReverseContractsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTIDS_PARAM, SqlDbType.NVarChar, -1, ParameterDirection.Input, (object)strContractIds??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadReverseContractsByContractIds", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ContractReverseDetail> list = LoadData<ContractReverseDetail>("LoadContractReverseDetails", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增冲帐记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertContractReverse(ContractReverse data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.InputOutput, (object)data.Id),
                    MakeParam(REVERSEAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ReverseAmount),
                    MakeParam(WITHHOLDAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.WithholdAmount),
                    MakeParam(FACTPAYMENTAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.FactpaymentAmount),
                    MakeParam(CREATORID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CreatorId),
                    MakeParam(CREATORNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CreatorName),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertContractReverse", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增冲帐记录明细数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertContractReverseDetail(ContractReverseDetail data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(REVERSEID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ReverseId),
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ContractId),
                    MakeParam(REVERSEAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.ReverseAmount),
                    MakeParam(WITHHOLDAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.WithholdAmount),
                    MakeParam(FACTPAYMENTAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.FactpaymentAmount),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertContractReverseDetail", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strContractNo??System.DBNull.Value),
                    MakeParam(ORIGINALCONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOriginalContractNo??System.DBNull.Value),
                    MakeParam(CREATORID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strReverserId??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ContractReverse> list = LoadData<ContractReverse>("LoadContractReversesByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(REVERSEID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nReverseId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ContractReverseDetail> list = LoadData<ContractReverseDetail>("LoadContractReverseDetailsByReverseId", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strContractNo??System.DBNull.Value),
                    MakeParam(ORIGINALCONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOriginalContractNo??System.DBNull.Value),
                    MakeParam(CREATORID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCreatorId??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadFineContractsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 修改合同罚款金额数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="decFineAmount"></param>
        /// <param name="strApproverName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateContractFineAmount(long nId, decimal decFineAmount, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(FINEAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)decFineAmount),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateContractFineAmount", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CREATORID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCreatorId??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadContractFinesByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定合同价格超出比例
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public decimal LoadContractPriceOverPercentage(long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            object objRet = ExecuteScalar("LoadContractPriceOverPercentage", Params, out strErrText);
            if (objRet == null)
            {
                throw new Exception(strErrText);
            }
            else
            {
                return (decimal)objRet;
            }
        }

        /// <summary>
        /// 读取指定合同价格超出金额
        /// </summary>
        /// <param name="nContractId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public decimal LoadContractPriceOverAmount(long nContractId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            object objRet = ExecuteScalar("LoadContractPriceOverAmount", Params, out strErrText);
            if (objRet == null)
            {
                throw new Exception(strErrText);
            }
            else
            {
                return (decimal)objRet;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("ReturnModifyContract", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteContractReverse", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除冲帐记录明细数据
        /// </summary>
        /// <param name="nReverseId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteContractReverseDetails(long nReverseId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(REVERSEID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nReverseId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteContractReverseDetails", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteContractFine", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CONTRACTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nContractId),
                    MakeParam(PLANID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nPlanId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ContractApproveComment> list = LoadData<ContractApproveComment>("LoadContractApproveComments", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Organization> list = LoadData<Organization>("LoadApproveContractsOwnOrgansByTimespan", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime??System.DBNull.Value),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime??System.DBNull.Value),
                    MakeParam(CONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strContractNo??System.DBNull.Value),
                    MakeParam(ORIGINALCONTRACTNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOriginalContractNo??System.DBNull.Value),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCountry??System.DBNull.Value),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartProvince??System.DBNull.Value),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCity??System.DBNull.Value),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCountry??System.DBNull.Value),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestProvince??System.DBNull.Value),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCity??System.DBNull.Value),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo??System.DBNull.Value),
                    MakeParam(ORGANID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOrganId??System.DBNull.Value),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Contract> list = LoadData<Contract>("LoadContractsByConditions", Params, out strErrText);
            return list;
        }

    }
}
