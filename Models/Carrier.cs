namespace InnoSoft.LS.Models
{
    public class Carrier
    {
        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 承运单位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 经营性质
        /// </summary>
        public string BusinessType { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string PaymentType { get; set; }
    }
}
