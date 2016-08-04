namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 承运单位对帐单实体类
    /// </summary>
    public class CarrierStatement
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 送货单号
        /// </summary>
        public string DeliverBillNo { get; set; }

        /// <summary>
        /// 交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

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
        /// 运费
        /// </summary>
        public decimal TransportCharges { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 特殊承运价格备注
        /// </summary>
        public string Remark2 { get; set; }

        /// <summary>
        /// 送货单回单已收标志
        /// </summary>
        public bool DeliverBillReceiptReceived { get; set; }

        /// <summary>
        /// 货损情况
        /// </summary>
        public string DamageInfo { get; set; }
    }
}
