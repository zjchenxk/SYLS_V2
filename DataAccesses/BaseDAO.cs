using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.Emit;
using System.Web.Configuration;

namespace InnoSoft.LS.Data.Access
{
    public class BaseDAO : IDisposable
    {
        private bool m_bDisposed;
        private SqlConnection m_conn = null;
        private string m_strInfoMessage = string.Empty;

        #region 存储过程参数名称

        /// <summary>
        /// 记录编码
        /// </summary>
        protected const string ID_PARAM = "@Id";
        /// <summary>
        /// 员工编码
        /// </summary>
        protected const string STAFFID_PARAM = "@StaffId";
        /// <summary>
        /// 员工姓名
        /// </summary>
        protected const string STAFFNAME_PARAM = "@StaffName";
        /// <summary>
        /// 组织部门编码
        /// </summary>
        protected const string ORGANID_PARAM = "@OrganId";
        /// <summary>
        /// 组织部门名称
        /// </summary>
        protected const string ORGANNAME_PARAM = "@OrganName";
        /// <summary>
        /// 组织部门全名称
        /// </summary>
        protected const string FULLORGANNAME_PARAM = "@FullOrganName";
        /// <summary>
        /// 上级编码
        /// </summary>
        protected const string PARENTID_PARAM = "@ParentId";
        /// <summary>
        /// 职位编码
        /// </summary>
        protected const string POSITIONID_PARAM = "@PositionId";
        /// <summary>
        /// 职位名称
        /// </summary>
        protected const string POSITIONNAME_PARAM = "@PositionName";
        /// <summary>
        /// 机器IP地址
        /// </summary>
        protected const string HOSTIP_PARAM = "@HostIP";
        /// <summary>
        /// 机器名称
        /// </summary>
        protected const string HOSTNAME_PARAM = "@HostName";
        /// <summary>
        /// 会话标识
        /// </summary>
        protected const string SESSIONID_PARAM = "@SessionId";
        /// <summary>
        /// 操作员工编码
        /// </summary>
        protected const string OPSTAFFID_PARAM = "@OpStaffId";
        /// <summary>
        /// 操作员工姓名
        /// </summary>
        protected const string OPSTAFFNAME_PARAM = "@OpStaffName";
        /// <summary>
        /// 国家名称
        /// </summary>
        protected const string COUNTRYNAME_PARAM = "@CountryName";
        /// <summary>
        /// 省份名称
        /// </summary>
        protected const string PROVINCENAME_PARAM = "@ProvinceName";
        /// <summary>
        /// 城市名称
        /// </summary>
        protected const string CITYNAME_PARAM = "@CityName";
        /// <summary>
        /// 街道门牌号码
        /// </summary>
        protected const string ADDRESS_PARAM = "@Address";
        /// <summary>
        /// 邮政编码
        /// </summary>
        protected const string POSTALCODE_PARAM = "@PostalCode";
        /// <summary>
        /// 名称
        /// </summary>
        protected const string NAME_PARAM = "@Name";
        /// <summary>
        /// 备注
        /// </summary>
        protected const string REMARK_PARAM = "@Remark";
        /// <summary>
        /// 姓氏
        /// </summary>
        protected const string FAMILYNAME_PARAM = "@FamilyName";
        /// <summary>
        /// 性别
        /// </summary>
        protected const string SEX_PARAM = "@Sex";
        /// <summary>
        /// 办公电话
        /// </summary>
        protected const string OFFICETEL_PARAM = "@OfficeTel";
        /// <summary>
        /// 分机
        /// </summary>
        protected const string TELEXT_PARAM = "@TelExt";
        /// <summary>
        /// 传真
        /// </summary>
        protected const string FAX_PARAM = "@Fax";
        /// <summary>
        /// 手机1
        /// </summary>
        protected const string MOBILETEL1_PARAM = "@MobileTel1";
        /// <summary>
        /// 手机2
        /// </summary>
        protected const string MOBILETEL2_PARAM = "@MobileTel2";
        /// <summary>
        /// 手机3
        /// </summary>
        protected const string MOBILETEL3_PARAM = "@MobileTel3";
        /// <summary>
        /// 电子邮件
        /// </summary>
        protected const string EMAIL_PARAM = "@EMail";
        /// <summary>
        /// QQ
        /// </summary>
        protected const string QQ_PARAM = "@QQ";
        /// <summary>
        /// 帐号密码
        /// </summary>
        protected const string PASSWORD_PARAM = "@Password";
        /// <summary>
        /// 帐号类别
        /// </summary>
        protected const string ACCOUNTTYPE_PARAM = "@AccountType";
        /// <summary>
        /// 是否为组织部门管理人员标志
        /// </summary>
        protected const string ISORGANMANAGER_PARAM = "@IsOrganManager";
        /// <summary>
        /// 是否为组织部门负责人标志
        /// </summary>
        protected const string ISORGANLEADER_PARAM = "@IsOrganLeader";
        /// <summary>
        /// 上司员工编码
        /// </summary>
        protected const string BOSSSTAFFID_PARAM = "@BossStaffId";
        /// <summary>
        /// 是否注销标志
        /// </summary>
        protected const string ISCANCEL_PARAM = "@IsCancel";
        /// <summary>
        /// 组编码
        /// </summary>
        protected const string GROUPID_PARAM = "@GroupId";
        /// <summary>
        /// 功能编码
        /// </summary>
        protected const string FUNCID_PARAM = "@FuncId";
        /// <summary>
        /// 功能权限
        /// </summary>
        protected const string FUNCPERMISSION_PARAM = "@FuncPermission";
        /// <summary>
        /// 允许打开标志
        /// </summary>
        protected const string ALLOWOPEN_PARAM = "@AllowOpen";
        /// <summary>
        /// 允许新增标志
        /// </summary>
        protected const string ALLOWNEW_PARAM = "@AllowNew";
        /// <summary>
        /// 允许修改标志
        /// </summary>
        protected const string ALLOWMODIFY_PARAM = "@AllowModify";
        /// <summary>
        /// 允许删除标志
        /// </summary>
        protected const string ALLOWDELETE_PARAM = "@AllowDelete";
        /// <summary>
        /// 允许注销、取消标志
        /// </summary>
        protected const string ALLOWCANCEL_PARAM = "@AllowCancel";
        /// <summary>
        /// 允许查看详细标志
        /// </summary>
        protected const string ALLOWDETAIL_PARAM = "@AllowDetail";
        /// <summary>
        /// 允许查询标志
        /// </summary>
        protected const string ALLOWSEARCH_PARAM = "@AllowSearch";
        /// <summary>
        /// 允许提交标志
        /// </summary>
        protected const string ALLOWSUBMIT_PARAM = "@AllowSubmit";
        /// <summary>
        /// 允许审批标志
        /// </summary>
        protected const string ALLOWAPPROVE_PARAM = "@AllowApprove";
        /// <summary>
        /// 允许调度标志
        /// </summary>
        protected const string ALLOWDISPATCH_PARAM = "@AllowDispatch";
        /// <summary>
        /// 允许导出标志
        /// </summary>
        protected const string ALLOWEXPORT_PARAM = "@AllowExport";
        /// <summary>
        /// 允许导入标志
        /// </summary>
        protected const string ALLOWIMPORT_PARAM = "@AllowImport";
        /// <summary>
        /// 允许打印标志
        /// </summary>
        protected const string ALLOWPRINT_PARAM = "@AllowPrint";
        /// <summary>
        /// 客户编码
        /// </summary>
        protected const string CUSTOMERID_PARAM = "@CustomerId";
        /// <summary>
        /// 客户名称
        /// </summary>
        protected const string CUSTOMERNAME_PARAM = "CustomerName";
        /// <summary>
        /// 帐号编码
        /// </summary>
        protected const string ACCOUNTID_PARAM = "@AccountId";
        /// <summary>
        /// 类别编码
        /// </summary>
        protected const string TYPEID_PARAM = "@TypeId";
        /// <summary>
        /// 上力支费价格
        /// </summary>
        protected const string LOADINGFORCEFEEPRICE_PARAM = "@LoadingForceFeePrice";
        /// <summary>
        /// 下力支费价格
        /// </summary>
        protected const string UNLOADINGFORCEFEEPRICE_PARAM = "@UnloadingForceFeePrice";
        /// <summary>
        /// 仓储费价格
        /// </summary>
        protected const string STORAGEFEEPRICE_PARAM = "@StorageFeePrice";
        /// <summary>
        /// 起点国家
        /// </summary>
        protected const string STARTCOUNTRY_PARAM = "@StartCountry";
        /// <summary>
        /// 起点省份
        /// </summary>
        protected const string STARTPROVINCE_PARAM = "@StartProvince";
        /// <summary>
        /// 起点城市
        /// </summary>
        protected const string STARTCITY_PARAM = "@StartCity";
        /// <summary>
        /// 讫点国家
        /// </summary>
        protected const string DESTCOUNTRY_PARAM = "@DestCountry";
        /// <summary>
        /// 讫点省份
        /// </summary>
        protected const string DESTPROVINCE_PARAM = "@DestProvince";
        /// <summary>
        /// 讫点城市
        /// </summary>
        protected const string DESTCITY_PARAM = "@DestCity";
        /// <summary>
        /// 公里数
        /// </summary>
        protected const string KM_PARAM = "@KM";
        /// <summary>
        /// 运输价格
        /// </summary>
        protected const string TRANSPORTPRICE_PARAM = "@TransportPrice";
        /// <summary>
        /// 货物编号
        /// </summary>
        protected const string GOODSNO_PARAM = "@GoodsNo";
        /// <summary>
        /// 规格型号
        /// </summary>
        protected const string SPECMODEL_PARAM = "@SpecModel";
        /// <summary>
        /// 克重
        /// </summary>
        protected const string GWEIGHT_PARAM = "@GWeight";
        /// <summary>
        /// 等级
        /// </summary>
        protected const string GRADE_PARAM = "@Grade";
        /// <summary>
        /// 品牌
        /// </summary>
        protected const string BRAND_PARAM = "@Brand";
        /// <summary>
        /// 件重
        /// </summary>
        protected const string PIECEWEIGHT_PARAM = "@PieceWeight";
        /// <summary>
        /// 包装
        /// </summary>
        protected const string PACKING_PARAM = "@Packing";
        /// <summary>
        /// 是否租借
        /// </summary>
        protected const string ISLEASE_PARAM = "@IsLease";
        /// <summary>
        /// 承运单位编码
        /// </summary>
        protected const string CARRIERID_PARAM = "@CarrierId";
        /// <summary>
        /// 承运单位名称
        /// </summary>
        protected const string CARRIERNAME_PARAM = "@CarrierName";
        /// <summary>
        /// 经营性质
        /// </summary>
        protected const string BUSINESSTYPE_PARAM = "@BusinessType";
        /// <summary>
        /// 结算方式
        /// </summary>
        protected const string PAYMENTTYPE_PARAM = "@PaymentType";
        /// <summary>
        /// 车号
        /// </summary>
        protected const string CARNO_PARAM = "@CarNo";
        /// <summary>
        /// 挂号
        /// </summary>
        protected const string TRAILERNO_PARAM = "@TrailerNo";
        /// <summary>
        /// 载重
        /// </summary>
        protected const string CARRYINGCAPACITY_PARAM = "@CarryingCapacity";
        /// <summary>
        /// 驾驶证号
        /// </summary>
        protected const string LICENSENO_PARAM = "@LicenseNo";
        /// <summary>
        /// 手机
        /// </summary>
        protected const string MOBILETEL_PARAM = "@MobileTel";
        /// <summary>
        /// 住宅电话
        /// </summary>
        protected const string HOMETEL_PARAM = "@HomeTel";
        /// <summary>
        /// 吨位下限
        /// </summary>
        protected const string MINTUNNAGES_PARAM = "@MinTunnages";
        /// <summary>
        /// 吨位上限
        /// </summary>
        protected const string MAXTUNNAGES_PARAM = "@MaxTunnages";
        /// <summary>
        /// 所属组织部门编码
        /// </summary>
        protected const string OWNORGANID_PARAM = "@OwnOrganId";
        /// <summary>
        /// 货物编码
        /// </summary>
        protected const string GOODSID_PARAM = "@GoodsId";
        /// <summary>
        /// 计划类别
        /// </summary>
        protected const string PLANTYPE_PARAM = "@PlanType";
        /// <summary>
        /// 装运单号
        /// </summary>
        protected const string SHIPMENTNO_PARAM = "@ShipmentNo";
        /// <summary>
        /// 交货单号
        /// </summary>
        protected const string DELIVERYNO_PARAM = "@DeliveryNo";
        /// <summary>
        /// 发货类别
        /// </summary>
        protected const string DELIVERTYPE_PARAM = "@DeliverType";
        /// <summary>
        /// 提货单位名称
        /// </summary>
        protected const string RECEIVERNAME_PARAM = "@ReceiverName";
        /// <summary>
        /// 提货单位所在国家
        /// </summary>
        protected const string RECEIVERCOUNTRY_PARAM = "@ReceiverCountry";
        /// <summary>
        /// 提货单位所在省份
        /// </summary>
        protected const string RECEIVERPROVINCE_PARAM = "@ReceiverProvince";
        /// <summary>
        /// 提货单位所在城市
        /// </summary>
        protected const string RECEIVERCITY_PARAM = "@ReceiverCity";
        /// <summary>
        /// 提货单位详细地址
        /// </summary>
        protected const string RECEIVERADDRESS_PARAM = "@ReceiverAddress";
        /// <summary>
        /// 提货单位联系人
        /// </summary>
        protected const string RECEIVERCONTACT_PARAM = "@ReceiverContact";
        /// <summary>
        /// 提货单位联系电话
        /// </summary>
        protected const string RECEIVERCONTACTTEL_PARAM = "@ReceiverContactTel";
        /// <summary>
        /// 提货方式
        /// </summary>
        protected const string RECEIVETYPE_PARAM = "@ReceiveType";
        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        protected const string DRIVERNAME_PARAM = "@DriverName";
        /// <summary>
        /// 驾驶员证号
        /// </summary>
        protected const string DRIVERLICENSENO_PARAM = "@DriverLicenseNo";
        /// <summary>
        /// 驾驶员手机
        /// </summary>
        protected const string DRIVERMOBILETEL_PARAM = "@DriverMobileTel";
        /// <summary>
        /// 驾驶员住宅电话
        /// </summary>
        protected const string DRIVERHOMETEL_PARAM = "@DriverHomeTel";
        /// <summary>
        /// 仓库
        /// </summary>
        protected const string WAREHOUSE_PARAM = "@Warehouse";
        /// <summary>
        /// 到货时间
        /// </summary>
        protected const string ARRIVALTIME_PARAM = "@ArrivalTime";
        /// <summary>
        /// 付款单位编码
        /// </summary>
        protected const string PAYERID_PARAM = "@PayerId";
        /// <summary>
        /// 付款单位名称
        /// </summary>
        protected const string PAYERNAME_PARAM = "@PayerName";
        /// <summary>
        /// 是否寄库
        /// </summary>
        protected const string ISCONSIGNING_PARAM = "@IsConsigning";
        /// <summary>
        /// 寄库交货单号
        /// </summary>
        protected const string CONSIGNEDDELIVERYNO_PARAM = "@ConsignedDeliveryNo";
        /// <summary>
        /// 计划编码
        /// </summary>
        protected const string PLANID_PARAM = "@PlanId";
        /// <summary>
        /// 批次号
        /// </summary>
        protected const string BATCHNO_PARAM = "@BatchNo";
        /// <summary>
        /// 件数
        /// </summary>
        protected const string PACKAGES_PARAM = "@Packages";
        /// <summary>
        /// 吨数
        /// </summary>
        protected const string TUNNAGES_PARAM = "@Tunnages";
        /// <summary>
        /// 垛数
        /// </summary>
        protected const string PILES_PARAM = "@Piles";
        /// <summary>
        /// 预警库存
        /// </summary>
        protected const string WARNINGSTOCK_PARAM = "@WarningStock";
        /// <summary>
        /// 停止库存
        /// </summary>
        protected const string STOPSTOCK_PARAM = "@StopStock";
        /// <summary>
        /// 结算公式
        /// </summary>
        protected const string SETTLEMENTEXPRESSION_PARAM = "@SettlementExpression";
        /// <summary>
        /// 入库类别
        /// </summary>
        protected const string ENTERTYPE_PARAM = "@EnterType";
        /// <summary>
        /// 力支费
        /// </summary>
        protected const string FORCEFEE_PARAM = "@ForceFee";
        /// <summary>
        /// 是否有短驳费
        /// </summary>
        protected const string HASDRAYAGE_PARAM = "@HasDrayage";
        /// <summary>
        /// 入库单编码
        /// </summary>
        protected const string ENTERWAREHOUSEBILLID_PARAM = "@EnterWarehouseBillId";
        /// <summary>
        /// 货位
        /// </summary>
        protected const string LOCATION_PARAM = "@Location";
        /// <summary>
        /// 生产日期
        /// </summary>
        protected const string PRODUCTIONDATE_PARAM = "@ProductionDate";
        /// <summary>
        /// 对应划拨出仓单编码
        /// </summary>
        protected const string SHIPMENTBILLGOODSIDS_PARAM = "@ShipmentBillGoodsIds";
        /// <summary>
        /// 万只
        /// </summary>
        protected const string TENTHOUSANDS_PARAM = "@TenThousands";
        /// <summary>
        /// 流程编码
        /// </summary>
        protected const string FLOWID_PARAM = "@FlowId";
        /// <summary>
        /// 流程名称
        /// </summary>
        protected const string FLOWNAME_PARAM = "@FlowName";
        /// <summary>
        /// 流程类别
        /// </summary>
        protected const string FLOWTYPE_PARAM = "@FlowType";
        /// <summary>
        /// 步骤编码
        /// </summary>
        protected const string STEPID_PARAM = "@StepId";
        /// <summary>
        /// 步骤名称
        /// </summary>
        protected const string STEPNAME_PARAM = "@StepName";
        /// <summary>
        /// 步骤编号
        /// </summary>
        protected const string STEPNUM_PARAM = "@StepNum";
        /// <summary>
        /// 处理人编码
        /// </summary>
        protected const string DISPOSERID_PARAM = "@DisposerId";
        /// <summary>
        /// 处理人姓名
        /// </summary>
        protected const string DISPOSERNAME_PARAM = "@DisposerName";
        /// <summary>
        /// 条件表达式
        /// </summary>
        protected const string CONDITIONEXPRESSION_PARAM = "@ConditionExpression";
        /// <summary>
        /// 字段名称
        /// </summary>
        protected const string FIELDNAME_PARAM = "@FieldName";
        /// <summary>
        /// 比较运算符
        /// </summary>
        protected const string COMPAREOPERATOR_PARAM = "@CompareOperator";
        /// <summary>
        /// 字段值
        /// </summary>
        protected const string FIELDVALUE_PARAM = "@FieldValue";
        /// <summary>
        /// 条件序号
        /// </summary>
        protected const string CONDITIONNUM_PARAM = "@ConditionNum";
        /// <summary>
        /// 是否同意标志
        /// </summary>
        protected const string ISAGREED_PARAM = "@IsAgreed";
        /// <summary>
        /// 审批意见
        /// </summary>
        protected const string APPROVECOMMENT_PARAM = "@ApproveComment";
        /// <summary>
        /// 起始时间
        /// </summary>
        protected const string STARTTIME_PARAM = "@StartTime";
        /// <summary>
        /// 截止时间
        /// </summary>
        protected const string ENDTIME_PARAM = "@EndTime";
        /// <summary>
        /// 累计件数
        /// </summary>
        protected const string TOTALPACKAGES_PARAM = "@TotalPackages";
        /// <summary>
        /// 累计吨数
        /// </summary>
        protected const string TOTALTUNNAGES_PARAM = "@TotalTunnages";
        /// <summary>
        /// 累计垛数
        /// </summary>
        protected const string TOTALPILES_PARAM = "@TotalPiles";
        /// <summary>
        /// 累计万只
        /// </summary>
        protected const string TOTALTENTHOUSANDS_PARAM = "@TotalTenThousands";
        /// <summary>
        /// 运费
        /// </summary>
        protected const string TRANSPORTCHARGES_PARAM = "@TransportCharges";
        /// <summary>
        /// 累计运费
        /// </summary>
        protected const string TOTALTRANSPORTCHARGES_PARAM = "@TotalTransportCharges";
        /// <summary>
        /// 调度单编码
        /// </summary>
        protected const string DISPATCHBILLID_PARAM = "@DispatchBillId";
        /// <summary>
        /// 运费公式
        /// </summary>
        protected const string TRANSPORTCHARGEEXPRESSION_PARAM = "@TransportChargeExpression";
        /// <summary>
        /// 单价公式
        /// </summary>
        protected const string TRANSPORTPRICEEXPRESSION_PARAM = "@TransportPriceExpression";
        /// <summary>
        /// 出仓单编码
        /// </summary>
        protected const string SHIPMENTBILLID_PARAM = "@ShipmentBillId";
        /// <summary>
        /// 出库单编码
        /// </summary>
        protected const string OUTWAREHOUSEBILLID_PARAM = "@OutWarehouseBillId";
        /// <summary>
        /// 单据编号
        /// </summary>
        protected const string BILLNO_PARAM = "@BillNo";
        /// <summary>
        /// 出库类别
        /// </summary>
        protected const string OUTTYPE_PARAM = "@OutType";
        /// <summary>
        /// 送货单编码
        /// </summary>
        protected const string DELIVERBILLID_PARAM = "@DeliverBillId";
        /// <summary>
        /// 回单时间
        /// </summary>
        protected const string RETURNTIME_PARAM = "@ReturnTime";
        /// <summary>
        /// 破损情况
        /// </summary>
        protected const string DAMAGEINFO_PARAM = "@DamageInfo";
        /// <summary>
        /// 货物名称
        /// </summary>
        protected const string GOODSNAME_PARAM = "@GoodsName";
        /// <summary>
        /// 起点
        /// </summary>
        protected const string STARTPLACE_PARAM = "@StartPlace";
        /// <summary>
        /// 讫点
        /// </summary>
        protected const string DESTPLACE_PARAM = "@DestPlace";
        /// <summary>
        /// 装运时间
        /// </summary>
        protected const string SHIPMENTTIME_PARAM = "@ShipmentTime";
        /// <summary>
        /// 预付运费
        /// </summary>
        protected const string PREPAYTRANSPORTCHARGES_PARAM = "@PrepayTransportCharges";
        /// <summary>
        /// 剩余运费
        /// </summary>
        protected const string RESIDUALTRANSPORTCHARGES_PARAM = "@ResidualTransportCharges";
        /// <summary>
        /// 合同编码
        /// </summary>
        protected const string CONTRACTID_PARAM = "@ContractId";
        /// <summary>
        /// 多个合同编码字符串
        /// </summary>
        protected const string CONTRACTIDS_PARAM = "@ContractIds";
        /// <summary>
        /// 合同编号
        /// </summary>
        protected const string CONTRACTNO_PARAM = "@ContractNo";
        /// <summary>
        /// 审批人编码
        /// </summary>
        protected const string APPROVERID_PARAM = "@ApproverId";
        /// <summary>
        /// 审批人姓名
        /// </summary>
        protected const string APPROVERNAME_PARAM = "@ApproverName";
        /// <summary>
        /// 审批单价
        /// </summary>
        protected const string APPROVEDTRANSPORTPRICE_PARAM = "@ApprovedTransportPrice";
        /// <summary>
        /// 审批运费
        /// </summary>
        protected const string APPROVEDTRANSPORTCHARGES_PARAM = "@ApprovedTransportCharges";
        /// <summary>
        /// 冲帐金额
        /// </summary>
        protected const string REVERSEAMOUNT_PARAM = "@ReverseAmount";
        /// <summary>
        /// 冲帐记录编码
        /// </summary>
        protected const string REVERSEID_PARAM = "@ReverseId";
        /// <summary>
        /// 创建时间
        /// </summary>
        protected const string CREATETIME_PARAM = "@CreateTime";
        /// <summary>
        /// 创建人编码
        /// </summary>
        protected const string CREATORID_PARAM = "@CreatorId";
        /// <summary>
        /// 创建人姓名
        /// </summary>
        protected const string CREATORNAME_PARAM = "@CreatorName";
        /// <summary>
        /// 罚款金额
        /// </summary>
        protected const string FINEAMOUNT_PARAM = "@FineAmount";
        /// <summary>
        /// 入库单号
        /// </summary>
        protected const string ENTERWAREHOUSEBILLNO_PARAM = "@EnterWarehouseBillNo";
        /// <summary>
        /// 出库单号
        /// </summary>
        protected const string OUTWAREHOUSEBILLNO_PARAM = "@OutWarehouseBillNo";
        /// <summary>
        /// 移库单编码
        /// </summary>
        protected const string MOVEWAREHOUSEBILLID_PARAM = "@MoveWarehouseBillId";
        /// <summary>
        /// 移入货位
        /// </summary>
        protected const string NEWLOCATION_PARAM = "@NewLocation";
        /// <summary>
        /// 移入件数
        /// </summary>
        protected const string NEWPACKAGES_PARAM = "@NewPackages";
        /// <summary>
        /// 移入吨数
        /// </summary>
        protected const string NEWTUNNAGES_PARAM = "@NewTunnages";
        /// <summary>
        /// 移入垛数
        /// </summary>
        protected const string NEWPILES_PARAM = "@NewPiles";
        /// <summary>
        /// 移入万只
        /// </summary>
        protected const string NEWTENTHOUSANDS_PARAM = "@NewTenThousands";
        /// <summary>
        /// 移库单号
        /// </summary>
        protected const string MOVEWAREHOUSEBILLNO_PARAM = "@MoveWarehouseBillNo";
        /// <summary>
        /// 发票号
        /// </summary>
        protected const string INVOICENO_PARAM = "@InvoiceNo";
        /// <summary>
        /// 寄库计划未发完是否结算标志
        /// </summary>
        protected const string ALLOWSTATEMENTWHENCONSIGNEDDELIVERPLANNOTCOMPLETED_PARAM = "@AllowStatementWhenConsignedDeliverPlanNotCompleted";
        /// <summary>
        /// 垛位下限
        /// </summary>
        protected const string MINPILES_PARAM = "@MinPiles";
        /// <summary>
        /// 垛位上限
        /// </summary>
        protected const string MAXPILES_PARAM = "@MaxPiles";
        /// <summary>
        /// 吨数(垛数)下限
        /// </summary>
        protected const string MINTUNNAGESORPILES_PARAM = "@MinTunnagesOrPiles";
        /// <summary>
        /// 吨数(垛数)上限
        /// </summary>
        protected const string MAXTUNNAGESORPILES_PARAM = "@MaxTunnagesOrPiles";
        /// <summary>
        /// 发票编码
        /// </summary>
        protected const string CUSTOMERTRANSPORTCHARGESSETTLEMENTID_PARAM = "@CustomerTransportChargesSettlementId";
        /// <summary>
        /// 发票种类
        /// </summary>
        protected const string INVOICETYPE_PARAM = "@InvoiceType";
        /// <summary>
        /// 发票金额
        /// </summary>
        protected const string INVOICEAMOUNT_PARAM = "@InvoiceAmount";
        /// <summary>
        /// 拼车费
        /// </summary>
        protected const string CARPOOLFEE_PARAM = "@CarpoolFee";
        /// <summary>
        /// 送货单号
        /// </summary>
        protected const string DELIVERBILLNO_PARAM = "@DeliverBillNo";
        /// <summary>
        /// 送货单回单已收标志
        /// </summary>
        protected const string DELIVERBILLRECEIPTRECEIVED_PARAM = "@DeliverBillReceiptReceived";
        /// <summary>
        /// 结算金额
        /// </summary>
        protected const string SETTLEMENTAMOUNT_PARAM = "@SettlementAmount";
        /// <summary>
        /// 承运单位结算记录编码
        /// </summary>
        protected const string CARRIERTRANSPORTCHARGESSETTLEMENTID_PARAM = "@CarrierTransportChargesSettlementId";
        /// <summary>
        /// 吨数或垛数
        /// </summary>
        protected const string TUNNAGESORPILES_PARAM = "@TunnagesOrPiles";
        /// <summary>
        /// 扣款金额
        /// </summary>
        protected const string WITHHOLDAMOUNT_PARAM = "@WithholdAmount";
        /// <summary>
        /// 实付金额
        /// </summary>
        protected const string FACTPAYMENTAMOUNT_PARAM = "@FactpaymentAmount";
        /// <summary>
        /// 罚款时间
        /// </summary>
        protected const string FINETIME_PARAM = "@FineTime";
        /// <summary>
        /// 全称
        /// </summary>
        protected const string FULLNAME_PARAM = "@FullName";
        /// <summary>
        /// 毛重率
        /// </summary>
        protected const string GROSSWEIGHTRATE_PARAM = "@GrossWeightRate";
        /// <summary>
        /// 车型
        /// </summary>
        protected const string CARTYPE_PARAM = "@CarType";
        /// <summary>
        /// 计价模式
        /// </summary>
        protected const string VALUATIONMODE_PARAM = "@ValuationMode";
        /// <summary>
        /// 是否分期发货
        /// </summary>
        protected const string ISINSTALMENT_PARAM = "@IsInstalment";
        /// <summary>
        /// 审批步骤序号
        /// </summary>
        protected const string APPROVEFLOWSTEPNUM_PARAM = "@ApproveFlowStepNum";
        /// <summary>
        /// 审批步骤名称
        /// </summary>
        protected const string APPROVEFLOWSTEPNAME_PARAM = "@ApproveFlowStepName";
        /// <summary>
        /// 原始合同号
        /// </summary>
        protected const string ORIGINALCONTRACTNO_PARAM = "@OriginalContractNo";
        /// <summary>
        /// 出仓单号
        /// </summary>
        protected const string SHIPMENTBILLNO_PARAM = "@ShipmentBillNo";
        /// <summary>
        /// 计划单号
        /// </summary>
        protected const string PLANNO_PARAM = "@PlanNo";
        /// <summary>
        /// 新计划编码
        /// </summary>
        protected const string NEWPLANID_PARAM = "@NewPlanId";
        /// <summary>
        /// 收货单位编码
        /// </summary>
        protected const string RECEIVERID_PARAM = "@ReceiverId";
        /// <summary>
        /// 过江费
        /// </summary>
        protected const string RIVERCROSSINGCHARGES_PARAM = "@RiverCrossingCharges";
        /// <summary>
        /// 订单号
        /// </summary>
        protected const string ORDERNO_PARAM = "@OrderNo";
        /// <summary>
        /// 多个编码字符串
        /// </summary>
        protected const string IDS_PARAM = "@Ids";
        /// <summary>
        /// 编码字符串
        /// </summary>
        protected const string NEWID_PARAM = "@NewId";
        /// <summary>
        /// 出仓单发生合并标志
        /// </summary>
        protected const string SHIPMENTBILLMERGED_PARAM = "@ShipmentBillMerged";
        /// <summary>
        /// 送货单发生合并标志
        /// </summary>
        protected const string DELIVERBILLMERGED_PARAM = "@DeliverBillMerged";
        /// <summary>
        /// 打印状态
        /// </summary>
        protected const string PRINTSTATE_PARAM = "@PrintState";
        /// <summary>
        /// 是否配载合同标志
        /// </summary>
        protected const string ISPRESTOWAGE_PARAM = "@IsPrestowage";

        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseDAO()
        {
            //创建数据库操作引擎实例
            try
            {
                string strConnection = WebConfigurationManager.AppSettings["DatabaseConnectionString"];
                if (strConnection != null && strConnection != string.Empty)
                {
                    //解密数据库密码
                    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(strConnection);
                    string str = Utils.DecryptDES(scsb.Password);
                    scsb.Password = str;
                    strConnection = scsb.ToString();

                    //创建数据库连接
                    m_conn = new SqlConnection(strConnection);
                    m_conn.InfoMessage += new SqlInfoMessageEventHandler(SqlConnection_InfoMessage);
                    m_conn.Open();
                }
                else
                {
                    throw new Exception(InnoSoft.LS.Resources.Strings.LoadConnectionStringFailed);
                }
            }
            catch (Exception e)
            {
                m_conn = null;

                throw e;
            }
        }

        /// <summary>
        /// 析构方法
        /// </summary>
        ~BaseDAO()
        {
            Dispose(false);
        }

        /// <summary>
        /// 释放内存
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 虚拟释放内存
        /// </summary>
        /// <param name="disposing">释放标志</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_bDisposed)
            {
                if (disposing)
                {
                    // Release managed resources
                    if (m_conn != null)
                    {
                        if (m_conn.State == ConnectionState.Open) m_conn.Close();
                        m_conn.Dispose();
                        m_conn = null;
                    }
                }

                // Release unmanaged resources

                m_bDisposed = true;
            }
        }

        /// <summary>
        /// 执行简单存储过程
        /// </summary>
        /// <param name="strProcedure">存储过程名称</param>
        /// <param name="Params">存储过程参数</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>返回存储过程的返回值</returns>
        protected int Execute(string strProcedure, SqlParameter[] Params, out string strErrText)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = m_conn;
                command.CommandTimeout = 7200;
                command.CommandText = strProcedure;
                command.CommandType = CommandType.StoredProcedure;

                if (Params != null)
                {
                    foreach (SqlParameter Param in Params)
                    {
                        command.Parameters.Add(Param);
                    }
                }
                command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));

                m_strInfoMessage = string.Empty;

                int nRows = command.ExecuteNonQuery();
                int nRet = int.Parse(command.Parameters["ReturnValue"].Value.ToString());

                strErrText = m_strInfoMessage;
                return nRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 执行简单存储过程
        /// </summary>
        /// <param name="strProcedure">存储过程名称</param>
        /// <param name="Params">存储过程参数</param>
        /// <param name="outParams"></param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>返回存储过程的返回值</returns>
        protected int Execute(string strProcedure, SqlParameter[] Params, out SqlParameterCollection outParams, out string strErrText)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = m_conn;
                command.CommandTimeout = 7200;
                command.CommandText = strProcedure;
                command.CommandType = CommandType.StoredProcedure;

                if (Params != null)
                {
                    foreach (SqlParameter Param in Params)
                    {
                        command.Parameters.Add(Param);
                    }
                }
                command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));

                m_strInfoMessage = string.Empty;

                int nRows = command.ExecuteNonQuery();
                int nRet = int.Parse(command.Parameters["ReturnValue"].Value.ToString());
                outParams = command.Parameters;

                strErrText = String.Empty;
                return nRet;
            }
            catch (Exception e)
            {
                outParams = null;
                strErrText = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 执行存储过程获取某个值
        /// </summary>
        /// <param name="strProcedure"></param>
        /// <param name="Params"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        protected object ExecuteScalar(string strProcedure, SqlParameter[] Params, out string strErrText)
        {
            strErrText = String.Empty;

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = m_conn;
                command.CommandTimeout = 7200;
                command.CommandText = strProcedure;
                command.CommandType = CommandType.StoredProcedure;

                if (Params != null)
                {
                    foreach (SqlParameter Param in Params)
                    {
                        command.Parameters.Add(Param);
                    }
                }
                command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));

                m_strInfoMessage = string.Empty;

                object objRet = command.ExecuteScalar();
                int nRet = int.Parse(command.Parameters["ReturnValue"].Value.ToString());
                if (nRet < 0)
                {
                    return null;
                }
                else
                {
                    return objRet;
                }
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行存储过程读取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strProcedure"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        protected List<T> LoadData<T>(string strProcedure, out string strErrText)
        {
            List<T> models = new List<T>();
            SqlDataReader dr = null;

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = m_conn;
                command.CommandTimeout = 7200;
                command.CommandText = strProcedure;
                command.CommandType = CommandType.StoredProcedure;

                m_strInfoMessage = string.Empty;

                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    T model = default(T);
                    model = DynamicBuilder<T>.CreateBuilder(dr).Build(dr);
                    models.Add(model);
                }

                //用于获取存储过程RaiseError命令发出的错误消息。
                //如果存储过程中执行了RaiseError命令，则调用NextResult时就会引发异常
                dr.NextResult();

                dr.Close();
                dr.Dispose();

                strErrText = string.Empty;
                return models;
            }
            catch (Exception e)
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }

                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行存储过程读取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strProcedure"></param>
        /// <param name="Params"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        protected List<T> LoadData<T>(string strProcedure, SqlParameter[] Params, out string strErrText)
        {
            List<T> models = new List<T>();
            SqlDataReader dr = null;

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = m_conn;
                command.CommandTimeout = 7200;
                command.CommandText = strProcedure;
                command.CommandType = CommandType.StoredProcedure;

                if (Params != null)
                {
                    foreach (SqlParameter Param in Params)
                    {
                        command.Parameters.Add(Param);
                    }
                }

                m_strInfoMessage = string.Empty;

                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    T model = default(T);
                    model = DynamicBuilder<T>.CreateBuilder(dr).Build(dr);
                    models.Add(model);
                }

                //用于获取存储过程RaiseError命令发出的错误消息。
                //如果存储过程中执行了RaiseError命令，则调用NextResult时就会引发异常
                dr.NextResult();

                dr.Close();
                dr.Dispose();

                strErrText = string.Empty;
                return models;
            }
            catch (SqlException ex)
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }

                strErrText = ex.Message;
                return null;
            }
            catch (Exception e)
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }

                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">数据类型</param>
        /// <param name="nSize">数据大小</param>
        /// <param name="Direction">数据方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的SqlParameter对象</returns>
        protected static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 nSize, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (nSize > 0)
                param = new SqlParameter(ParamName, DbType, nSize);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">数据类型</param>
        /// <param name="nSize">数据大小</param>
        /// <param name="Direction">数据方向</param>
        /// <param name="SourceColumn">对于DataSet中源列名称</param>
        /// <returns>新的SqlParameter对象</returns>
        protected static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 nSize, ParameterDirection Direction, string SourceColumn)
        {
            SqlParameter param;

            if (nSize > 0)
                param = new SqlParameter(ParamName, DbType, nSize);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            param.SourceColumn = SourceColumn;

            return param;
        }

        /// <summary>
        /// 解析存储过程中的Print消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SqlConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError r in e.Errors)
            {
                m_strInfoMessage += r.Message.Trim();
            }
        }
    }

    /// <summary>
    /// Use DynamicMethod and ILGenerator create entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DynamicBuilder<T>
    {
        private static readonly MethodInfo getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new Type[] { typeof(int) });

        private static readonly MethodInfo isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new Type[] { typeof(int) });

        private delegate T Load(IDataRecord dataRecord);

        private Load handler;//最终执行动态方法的一个委托 参数是IDataRecord接口

        //私有构造函数
        private DynamicBuilder()
        {
        }

        public T Build(IDataRecord dataRecord)
        {
            return handler(dataRecord);//执行CreateBuilder里创建的DynamicCreate动态方法的委托
        }

        public static DynamicBuilder<T> CreateBuilder(IDataRecord dataRecord)
        {
            DynamicBuilder<T> dynamicBuilder = new DynamicBuilder<T>();

            //定义一个名为DynamicCreate的动态方法，返回值typof(T)，参数typeof(IDataRecord)
            DynamicMethod method = new DynamicMethod("DynamicCreate", typeof(T), new Type[] { typeof(IDataRecord) }, typeof(T), true);

            ILGenerator generator = method.GetILGenerator();//创建一个MSIL生成器，为动态方法生成代码

            LocalBuilder result = generator.DeclareLocal(typeof(T));//声明指定类型的局部变量 可以T t;这么理解

            //The next piece of code instantiates the requested type of object and stores it in the local variable. 可以t=new T();这么理解
            generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
            generator.Emit(OpCodes.Stloc, result);

            for (int i = 0; i < dataRecord.FieldCount; i++)//数据集合，熟悉的for循环 要干什么你懂的 
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(dataRecord.GetName(i));//根据列名取属性  原则上属性和列是一一对应的关系
                Label endIfLabel = generator.DefineLabel();

                if (propertyInfo != null && propertyInfo.GetSetMethod() != null)//实体存在该属性 且该属性有SetMethod方法
                {
                    /*The code then loops through the fields in the data reader, finding matching properties on the type passed in. 
                     * When a match is found, the code checks to see if the value from the data reader is null.
                     */
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, isDBNullMethod);//就知道这里要调用IsDBNull方法 如果IsDBNull==true contine
                    generator.Emit(OpCodes.Brtrue, endIfLabel);

                    /*If the value in the data reader is not null, the code sets the value on the object.*/
                    generator.Emit(OpCodes.Ldloc, result);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, getValueMethod);//调用get_Item方法
                    generator.Emit(OpCodes.Unbox_Any, dataRecord.GetFieldType(i));
                    generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());//给该属性设置对应值

                    generator.MarkLabel(endIfLabel);
                }
            }

            /*The last part of the code returns the value of the local variable*/
            generator.Emit(OpCodes.Ldloc, result);
            generator.Emit(OpCodes.Ret);//方法结束，返回

            //完成动态方法的创建，并且创建执行该动态方法的委托，赋值到全局变量handler,handler在Build方法里Invoke
            dynamicBuilder.handler = (Load)method.CreateDelegate(typeof(Load));

            return dynamicBuilder;
        }
    }

}
