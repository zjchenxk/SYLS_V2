namespace InnoSoft.LS.Models
{
    public class CarrierTransportChargesSettlementDetail
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 结算记录编码
        /// </summary>
        public long CarrierTransportChargesSettlementId { get; set; }

        /// <summary>
        /// 送货单编码
        /// </summary>
        public long DeliverBillId { get; set; }

        /// <summary>
        /// 送货单号
        /// </summary>
        public string DeliverBillNo { get; set; }

        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long CarrierId { get; set; }

        /// <summary>
        /// 承运单位名称
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// 发货日期
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 车号
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
        /// 运费
        /// </summary>
        public decimal TransportCharges { get; set; }

        /// <summary>
        /// 货损情况
        /// </summary>
        public string DamageInfo { get; set; }
    }
}
