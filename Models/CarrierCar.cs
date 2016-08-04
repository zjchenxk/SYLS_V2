namespace InnoSoft.LS.Models
{
    public class CarrierCar
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
        /// 挂号
        /// </summary>
        public string TrailerNo { get; set; }

        /// <summary>
        /// 载重
        /// </summary>
        public int CarryingCapacity { get; set; }

    }
}
