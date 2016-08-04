namespace InnoSoft.LS.Models
{
    public class CarrierDriver
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long CarrierId { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 驾驶证号
        /// </summary>
        public string LicenseNo { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileTel { get; set; }

        /// <summary>
        /// 住宅电话
        /// </summary>
        public string HomeTel { get; set; }

    }
}
