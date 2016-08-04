namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 产品类别实体类
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// 产品编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 上级类别编码
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 类别全路径
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类别全名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
