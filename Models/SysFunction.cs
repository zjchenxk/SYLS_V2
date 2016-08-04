namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 系统功能实体类
    /// </summary>
    public class SysFunction
    {
        /// <summary>
        /// 功能编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 允许打开标志
        /// </summary>
        public bool AllowOpen { get; set; }

        /// <summary>
        /// 允许新增标志
        /// </summary>
        public bool AllowNew { get; set; }

        /// <summary>
        /// 允许修改标志
        /// </summary>
        public bool AllowModify { get; set; }

        /// <summary>
        /// 允许删除标志
        /// </summary>
        public bool AllowDelete { get; set; }

        /// <summary>
        /// 允许注销标志
        /// </summary>
        public bool AllowCancel { get; set; }

        /// <summary>
        /// 允许查看详细标志
        /// </summary>
        public bool AllowDetail { get; set; }

        /// <summary>
        /// 允许查询标志
        /// </summary>
        public bool AllowSearch { get; set; }

        /// <summary>
        /// 允许提交标志
        /// </summary>
        public bool AllowSubmit { get; set; }

        /// <summary>
        /// 允许审批标志
        /// </summary>
        public bool AllowApprove { get; set; }

        /// <summary>
        /// 允许调度标志
        /// </summary>
        public bool AllowDispatch { get; set; }

        /// <summary>
        /// 允许导出标志
        /// </summary>
        public bool AllowExport { get; set; }

        /// <summary>
        /// 允许导入标志
        /// </summary>
        public bool AllowImport { get; set; }

        /// <summary>
        /// 允许打印标志
        /// </summary>
        public bool AllowPrint { get; set; }
    }
}
