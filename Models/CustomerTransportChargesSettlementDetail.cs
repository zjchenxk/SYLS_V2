namespace InnoSoft.LS.Models
{
    public class CustomerTransportChargesSettlementDetail
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 结算记录编码
        /// </summary>
        public long CustomerTransportChargesSettlementId { get; set; }

        /// <summary>
        /// 送货单编码
        /// </summary>
        public long DeliverBillId { get; set; }

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
        /// 收货单位名称
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收货单位地址
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 讫点
        /// </summary>
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public int Packages { get; set; }

        /// <summary>
        /// 吨数
        /// </summary>
        public decimal Tunnages { get; set; }

        /// <summary>
        /// 垛数
        /// </summary>
        public decimal Piles { get; set; }

        /// <summary>
        /// 万只
        /// </summary>
        public decimal TenThousands { get; set; }

        /// <summary>
        /// 运费单价
        /// </summary>
        public decimal TransportPrice { get; set; }

        /// <summary>
        /// 运费
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
    }
}
