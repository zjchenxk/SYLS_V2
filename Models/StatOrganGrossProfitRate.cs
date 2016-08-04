namespace InnoSoft.LS.Models
{
    public class StatOrganGrossProfitRate
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 组织部门名称
        /// </summary>
        public string OrganName { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        public string StartPlace { get; set; }

        /// <summary>
        /// 讫点
        /// </summary>
        public string DestPlace { get; set; }

        /// <summary>
        /// 累计承运运费
        /// </summary>
        public decimal TotalCarrierTransportCharges { get; set; }

        /// <summary>
        /// 累计结算运费
        /// </summary>
        public decimal TotalCustomerTransportCharges { get; set; }

        /// <summary>
        /// 累计价差
        /// </summary>
        public decimal TotalTransportChargesDifference { get; set; }

        /// <summary>
        /// 累计毛利率
        /// </summary>
        public decimal TotalGrossProfitRate { get; set; }
    }
}
