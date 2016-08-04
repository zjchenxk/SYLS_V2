namespace InnoSoft.LS.Models
{
    public class StatCustomerTotalOutput
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 加盟吨数
        /// </summary>
        public decimal JoinInTunnages { get; set; }

        /// <summary>
        /// 自营吨数
        /// </summary>
        public decimal SelfSupportTunnages { get; set; }

        /// <summary>
        /// 配载吨数
        /// </summary>
        public decimal PrestowageTunnages { get; set; }

        /// <summary>
        /// 吨数小计
        /// </summary>
        public decimal SubtotalTunnages { get; set; }

        /// <summary>
        /// 加盟垛数
        /// </summary>
        public decimal JoinInPiles { get; set; }

        /// <summary>
        /// 自营垛数
        /// </summary>
        public decimal SelfSupportPiles { get; set; }

        /// <summary>
        /// 配载垛数
        /// </summary>
        public decimal PrestowagePiles { get; set; }

        /// <summary>
        /// 垛数小计
        /// </summary>
        public decimal SubtotalPiles { get; set; }

        /// <summary>
        /// 加盟运费
        /// </summary>
        public decimal JoinInTransportCharges { get; set; }

        /// <summary>
        /// 自营运费
        /// </summary>
        public decimal SelfSupportTransportCharges { get; set; }

        /// <summary>
        /// 配载运费
        /// </summary>
        public decimal PrestowageTransportCharges { get; set; }

        /// <summary>
        /// 运费小计
        /// </summary>
        public decimal SubtotalTransportCharges { get; set; }

        /// <summary>
        /// 加盟价差
        /// </summary>
        public decimal JoinInTransportChargesDifference { get; set; }

        /// <summary>
        /// 自营价差
        /// </summary>
        public decimal SelfSupportTransportChargesDifference { get; set; }

        /// <summary>
        /// 配载价差
        /// </summary>
        public decimal PrestowageTransportChargesDifference { get; set; }

        /// <summary>
        /// 价差小计
        /// </summary>
        public decimal SubtotalTransportChargesDifference { get; set; }

        /// <summary>
        /// 加盟毛利率
        /// </summary>
        public decimal JoinInGrossProfitRate { get; set; }

        /// <summary>
        /// 自营毛利率
        /// </summary>
        public decimal SelfSupportGrossProfitRate { get; set; }

        /// <summary>
        /// 配载毛利率
        /// </summary>
        public decimal PrestowageGrossProfitRate { get; set; }

        /// <summary>
        /// 毛利率小计
        /// </summary>
        public decimal SubtotalGrossProfitRate { get; set; }

    }
}
