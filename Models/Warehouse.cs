namespace InnoSoft.LS.Models
{
    public class Warehouse
    {
        /// <summary>
        /// 职位编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否租借标志
        /// </summary>
        public bool IsLease { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
