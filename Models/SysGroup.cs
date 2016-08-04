namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 权限组实体类
    /// </summary>
    public class SysGroup
    {
        /// <summary>
        /// 组编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
