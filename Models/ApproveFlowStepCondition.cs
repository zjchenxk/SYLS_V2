namespace InnoSoft.LS.Models
{
    public class ApproveFlowStepCondition
    {
        /// <summary>
        /// 条件编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 步骤编码
        /// </summary>
        public long StepId { get; set; }

        /// <summary>
        /// 流程类别
        /// </summary>
        public string FlowType { get; set; }

        /// <summary>
        /// 条件序号
        /// </summary>
        public int ConditionNum { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 比较运算符
        /// </summary>
        public string CompareOperator { get; set; }

        /// <summary>
        /// 字段值
        /// </summary>
        public string FieldValue { get; set; }
    }
}
