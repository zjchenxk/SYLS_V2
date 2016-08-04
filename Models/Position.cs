namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 职位实体类
    /// </summary>
    public class Position
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
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
