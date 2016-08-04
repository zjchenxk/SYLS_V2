using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class SettlementDAO : BaseDAO
    {
        /// <summary>
        /// 根据条件读取客户对帐单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strPayerName"></param>
        /// <param name="strReceiverName"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarrierName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strGoodsName"></param>
        /// <param name="strAllowStatementWhenConsignedDeliverPlanNotCompleted"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerStatement> LoadCustomerStatementByConditions(string strStartTime, string strEndTime, string strPayerName, string strReceiverName, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarrierName, string strCarNo, string strGoodsName, string strAllowStatementWhenConsignedDeliverPlanNotCompleted, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(PAYERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPayerName),
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strReceiverName),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCity),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarrierName),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(GOODSNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsName),
                    MakeParam(ALLOWSTATEMENTWHENCONSIGNEDDELIVERPLANNOTCOMPLETED_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strAllowStatementWhenConsignedDeliverPlanNotCompleted),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerStatement> list = LoadData<CustomerStatement>("LoadCustomerStatementByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增发票数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertCustomerTransportChargesSettlement(CustomerTransportChargesSettlement data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
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
            if (Execute("InsertCustomerTransportChargesSettlement", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增发票明细数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCustomerTransportChargesSettlementDetail(CustomerTransportChargesSettlementDetail data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERTRANSPORTCHARGESSETTLEMENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CustomerTransportChargesSettlementId),
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DeliverBillId),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
                    MakeParam(CARPOOLFEE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.CarpoolFee),
                    MakeParam(RIVERCROSSINGCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.RiverCrossingCharges),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCustomerTransportChargesSettlementDetail", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据综合条件读取发票数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strInvoiceNo"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerTransportChargesSettlement> LoadCustomerTransportChargesSettlementsByConditions(string strStartTime, string strEndTime, string strInvoiceNo, string strDeliverBillNo, string strCustomerName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(INVOICENO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strInvoiceNo),
                    MakeParam(DELIVERBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliverBillNo),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerTransportChargesSettlement> list = LoadData<CustomerTransportChargesSettlement>("LoadCustomerTransportChargesSettlementsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定发票的明细数据
        /// </summary>
        /// <param name="nCustomerTransportChargesSettlementId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CustomerTransportChargesSettlementDetail> LoadCustomerTransportChargesSettlementDetails(long nCustomerTransportChargesSettlementId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERTRANSPORTCHARGESSETTLEMENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerTransportChargesSettlementId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CustomerTransportChargesSettlementDetail> list = LoadData<CustomerTransportChargesSettlementDetail>("LoadCustomerTransportChargesSettlementDetails", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 根据条件读取承运单位对帐单数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strCarrierName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliverBillReceiptReceived"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierStatement> LoadCarrierStatementByConditions(string strStartTime, string strEndTime, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strCarrierName, string strCarNo, string strDeliverBillReceiptReceived, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDestCity),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarrierName),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(DELIVERBILLRECEIPTRECEIVED_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliverBillReceiptReceived),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierStatement> list = LoadData<CarrierStatement>("LoadCarrierStatementByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增承运单位结算记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertCarrierTransportChargesSettlement(CarrierTransportChargesSettlement data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.CarrierName),
                    MakeParam(SETTLEMENTAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.SettlementAmount),
                    MakeParam(WITHHOLDAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.WithholdAmount),
                    MakeParam(FACTPAYMENTAMOUNT_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.FactpaymentAmount),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertCarrierTransportChargesSettlement", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增承运单位结算明细数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCarrierTransportChargesSettlementDetail(CarrierTransportChargesSettlementDetail data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERTRANSPORTCHARGESSETTLEMENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierTransportChargesSettlementId),
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DeliverBillId),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCarrierTransportChargesSettlementDetail", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据综合条件读取承运单位结算记录
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strCarrierName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierTransportChargesSettlement> LoadCarrierTransportChargesSettlementsByConditions(string strStartTime, string strEndTime, string strCarrierName, string strCarNo, string strDeliverBillNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarrierName),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(DELIVERBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliverBillNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierTransportChargesSettlement> list = LoadData<CarrierTransportChargesSettlement>("LoadCarrierTransportChargesSettlementsByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定承运单位结算记录明细数据
        /// </summary>
        /// <param name="nCarrierTransportChargesSettlementId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierTransportChargesSettlementDetail> LoadCarrierTransportChargesSettlementDetails(long nCarrierTransportChargesSettlementId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERTRANSPORTCHARGESSETTLEMENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierTransportChargesSettlementId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierTransportChargesSettlementDetail> list = LoadData<CarrierTransportChargesSettlementDetail>("LoadCarrierTransportChargesSettlementDetails", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 读取指定送货单编码的特殊结算价格记录
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBillCustomerTransportPrice LoadDeliverBillCustomerTransportPriceByDeliverBillId(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDeliverBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBillCustomerTransportPrice> list = LoadData<DeliverBillCustomerTransportPrice>("LoadDeliverBillCustomerTransportPriceByDeliverBillId", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增特殊结算价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertDeliverBillCustomerTransportPrice(DeliverBillCustomerTransportPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DeliverBillId),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertDeliverBillCustomerTransportPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据综合条件读取特殊结算价格数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCustomerName"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBillCustomerTransportPrice> LoadDeliverBillCustomerTransportPricesByConditions(string strStartTime, string strEndTime, string strDeliverBillNo, string strCustomerName, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(DELIVERBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliverBillNo),
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBillCustomerTransportPrice> list = LoadData<DeliverBillCustomerTransportPrice>("LoadDeliverBillCustomerTransportPricesByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 删除特殊结算价格记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverBillCustomerTransportPrice(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDeliverBillCustomerTransportPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除开票记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCustomerTransportChargesSettlement(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCustomerTransportChargesSettlement", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除开票记录明细数据
        /// </summary>
        /// <param name="nCustomerTransportChargesSettlementId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCustomerTransportChargesSettlementDetails(long nCustomerTransportChargesSettlementId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERTRANSPORTCHARGESSETTLEMENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCustomerTransportChargesSettlementId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCustomerTransportChargesSettlementDetails", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除承运单位结算记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierTransportChargesSettlement(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCarrierTransportChargesSettlement", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除承运单位结算记录明细数据
        /// </summary>
        /// <param name="nCarrierTransportChargesSettlementId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierTransportChargesSettlementDetails(long nCarrierTransportChargesSettlementId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERTRANSPORTCHARGESSETTLEMENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierTransportChargesSettlementId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteCarrierTransportChargesSettlementDetails", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 读取指定送货单编码的特殊承运价格记录
        /// </summary>
        /// <param name="nDeliverBillId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public DeliverBillCarrierTransportPrice LoadDeliverBillCarrierTransportPriceByDeliverBillId(long nDeliverBillId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nDeliverBillId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBillCarrierTransportPrice> list = LoadData<DeliverBillCarrierTransportPrice>("LoadDeliverBillCarrierTransportPriceByDeliverBillId", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增特殊承运价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertDeliverBillCarrierTransportPrice(DeliverBillCarrierTransportPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(DELIVERBILLID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.DeliverBillId),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
                    MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertDeliverBillCarrierTransportPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据综合条件读取特殊承运价格数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strDeliverBillNo"></param>
        /// <param name="strCarNo"></param>
        /// <param name="strDeliveryNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<DeliverBillCarrierTransportPrice> LoadDeliverBillCarrierTransportPricesByConditions(string strStartTime, string strEndTime, string strDeliverBillNo, string strCarNo, string strDeliveryNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(DELIVERBILLNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliverBillNo),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(DELIVERYNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strDeliveryNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<DeliverBillCarrierTransportPrice> list = LoadData<DeliverBillCarrierTransportPrice>("LoadDeliverBillCarrierTransportPricesByConditions", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 删除特殊承运价格记录数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteDeliverBillCarrierTransportPrice(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteDeliverBillCarrierTransportPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

    }
}
