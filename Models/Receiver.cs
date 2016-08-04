namespace InnoSoft.LS.Models
{
    public class Receiver
    {
        /// <summary>
        /// 提货单位编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 提货单位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所在国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 所在省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel { get; set; }
    }
}
