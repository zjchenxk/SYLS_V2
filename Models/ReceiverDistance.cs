namespace InnoSoft.LS.Models
{
    public class ReceiverDistance
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 收货单位名称
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 起点国家
        /// </summary>
        public string StartCountry { get; set; }

        /// <summary>
        /// 起点省份
        /// </summary>
        public string StartProvince { get; set; }

        /// <summary>
        /// 起点城市
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 公里数
        /// </summary>
        public int KM { get; set; }
    }
}
