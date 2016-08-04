namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 国家实体类
    /// </summary>
    public class Country
    {
        /// <summary>
        /// 编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
