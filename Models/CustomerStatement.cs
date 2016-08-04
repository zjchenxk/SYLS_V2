namespace InnoSoft.LS.Models
{
    public class CustomerStatement
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 计划单号
        /// </summary>
        public string PlanNo { get; set; }

        /// <summary>
        /// 送货单号
        /// </summary>
        public string DeliverBillNo { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 装运单号
        /// </summary>
        public string ShipmentNo { get; set; }

        /// <summary>
        /// 交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

        /// <summary>
        /// 发货日期
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 收货单位
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 承运车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 讫点
        /// </summary>
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 公里数
        /// </summary>
        public string KM { get; set; }

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
        /// 结算价格
        /// </summary>
        public decimal TransportPrice { get; set; }

        /// <summary>
        /// 结算公式
        /// </summary>
        public string SettlementExpression { get; set; }

        /// <summary>
        /// 结算运费
        /// </summary>
        public decimal TransportCharges { get; set; }

        /// <summary>
        /// 拼车费
        /// </summary>
        public decimal CarpoolFee { get; set; }

        /// <summary>
        /// 过江费
        /// </summary>
        public decimal RiverCrossingCharges { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 特殊结算价格备注
        /// </summary>
        public string Remark2 { get; set; }

        /// <summary>
        /// 送货单回单已收标志
        /// </summary>
        public bool DeliverBillReceiptReceived { get; set; }

        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo { get; set; }
    }
}
