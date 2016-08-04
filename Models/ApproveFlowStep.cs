namespace InnoSoft.LS.Models
{
    public class ApproveFlowStep
    {
        /// <summary>
        /// 步骤编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// 步骤序号
        /// </summary>
        public int StepNum { get; set; }

        /// <summary>
        /// 流程类别
        /// </summary>
        public string FlowType { get; set; }

        /// <summary>
        /// 处理人编码
        /// </summary>
        public long DisposerId { get; set; }

        /// <summary>
        /// 处理人姓名
        /// </summary>
        public string DisposerName { get; set; }

        /// <summary>
        /// 条件表达式
        /// </summary>
        public string ConditionExpression { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        public string Conditions { get; set; }
    }
}
