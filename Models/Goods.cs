namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 货物实体类
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 货物编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>
        public long TypeId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 类别全路径
        /// </summary>
        public string TypeFullPath { get; set; }

        /// <summary>
        /// 类别全名称
        /// </summary>
        public string TypeFullName { get; set; }

        /// <summary>
        /// 货物编码
        /// </summary>
        public string GoodsNo { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string SpecModel { get; set; }

        /// <summary>
        /// 克重
        /// </summary>
        public string GWeight { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 件重
        /// </summary>
        public string PieceWeight { get; set; }

        /// <summary>
        /// 包装
        /// </summary>
        public string Packing { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
