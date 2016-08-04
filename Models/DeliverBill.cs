using System;

namespace InnoSoft.LS.Models
{
    public class DeliverBill
    {
        /// <summary>
        /// 送货单编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 送货单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 出仓单编码
        /// </summary>
        public long ShipmentBillId { get; set; }

        /// <summary>
        /// 调度单编码
        /// </summary>
        public long DispatchBillId { get; set; }

        /// <summary>
        /// 计划编码
        /// </summary>
        public long PlanId { get; set; }

        /// <summary>
        /// 计划单号
        /// </summary>
        public string PlanNo { get; set; }

        /// <summary>
        /// 计划类别
        /// </summary>
        public string PlanType { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 结算付款单位编码
        /// </summary>
        public long PayerId { get; set; }

        /// <summary>
        /// 结算付款单位名称
        /// </summary>
        public string PayerName { get; set; }

        /// <summary>
        /// 装运单号
        /// </summary>
        public string ShipmentNo { get; set; }

        /// <summary>
        /// 交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

        /// <summary>
        /// 提货单位名称
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 提货单位所在国家
        /// </summary>
        public string ReceiverCountry { get; set; }

        /// <summary>
        /// 提货单位所在省份
        /// </summary>
        public string ReceiverProvince { get; set; }

        /// <summary>
        /// 收货单位所在城市
        /// </summary>
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 收货单位地址
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收货单位联系人姓名
        /// </summary>
        public string ReceiverContact { get; set; }

        /// <summary>
        /// 收货单位联系人电话
        /// </summary>
        public string ReceiverContactTel { get; set; }

        /// <summary>
        /// 收货方式
        /// </summary>
        public string ReceiveType { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 公里数
        /// </summary>
        public string KM { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 挂车号
        /// </summary>
        public string TrailerNo { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long CarrierId { get; set; }

        /// <summary>
        /// 承运单位名称
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 起点所在国家
        /// </summary>
        public string StartCountry { get; set; }

        /// <summary>
        /// 起点所在省份
        /// </summary>
        public string StartProvince { get; set; }

        /// <summary>
        /// 起点所在城市
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 创建人编码
        /// </summary>
        public long CreatorId { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// 创建部门办事处编码
        /// </summary>
        public long CreateOrganId { get; set; }

        /// <summary>
        /// 创建部门办事处名称
        /// </summary>
        public string CreateOrganName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 所属部门办事处编码
        /// </summary>
        public long OwnOrganId { get; set; }

        /// <summary>
        /// 所属部门办事处名称
        /// </summary>
        public string OwnOrganName { get; set; }

        /// <summary>
        /// 打印状态
        /// </summary>
        public bool PrintState { get; set; }

        /// <summary>
        /// 回单日期
        /// </summary>
        public DateTime ReturnTime { get; set; }

        /// <summary>
        /// 破损情况
        /// </summary>
        public string DamageInfo { get; set; }

        /// <summary>
        /// 结算记录编码
        /// </summary>
        public long CustomerTransportChargesSettlementId { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 累计件数
        /// </summary>
        public int TotalPackages { get; set; }

        /// <summary>
        /// 累计吨数
        /// </summary>
        public decimal TotalTunnages { get; set; }

        /// <summary>
        /// 累计垛数
        /// </summary>
        public decimal TotalPiles { get; set; }

        /// <summary>
        /// 累计万只
        /// </summary>
        public decimal TotalTenThousands { get; set; }

        /// <summary>
        /// 装运单累计吨数
        /// </summary>
        public decimal ShipmentBillTotalTunnages { get; set; }

        /// <summary>
        /// 装运单累计垛数
        /// </summary>
        public decimal ShipmentBillTotalPiles { get; set; }

        /// <summary>
        /// 承运单价
        /// </summary>
        public decimal TransportPrice { get; set; }

        /// <summary>
        /// 承运运费
        /// </summary>
        public decimal TransportCharges { get; set; }

        /// <summary>
        /// 合同编码
        /// </summary>
        public long ContractId { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNo { get; set; }

        /// <summary>
        /// 原始合同号
        /// </summary>
        public string OriginalContractNo { get; set; }

        /// <summary>
        /// 客户结算公式
        /// </summary>
        public string SettlementExpression { get; set; }

        /// <summary>
        /// 客户结算价格
        /// </summary>
        public decimal CustomerTransportPrice { get; set; }

        /// <summary>
        /// 客户运费
        /// </summary>
        public decimal CustomerTransportCharges { get; set; }

        /// <summary>
        /// 拼车费
        /// </summary>
        public decimal CarpoolFee { get; set; }

        /// <summary>
        /// 过江费
        /// </summary>
        public decimal RiverCrossingCharges { get; set; }

        /// <summary>
        /// 运费价差
        /// </summary>
        public decimal TransportChargesDifference { get; set; }

        /// <summary>
        /// 客户是否结算标志
        /// </summary>
        public bool IsCustomerTransportChargesSettled { get; set; }

        /// <summary>
        /// 承运单位是否结算标志
        /// </summary>
        public bool IsCarrierTransportChargesSettled { get; set; }

        /// <summary>
        /// 是否回单标志
        /// </summary>
        public bool IsDeliverBillReceiptReceived { get; set; }

        /// <summary>
        /// 冲帐金额
        /// </summary>
        public decimal ReverseAmount { get; set; }

        /// <summary>
        /// 运费差额
        /// </summary>
        public decimal TransportChargesBalance { get; set; }
    }
}
