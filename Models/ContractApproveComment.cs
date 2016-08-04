using System;

namespace InnoSoft.LS.Models
{
    public class ContractApproveComment
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 合同编码
        /// </summary>
        public long ContractId { get; set; }

        /// <summary>
        /// 计划编码
        /// </summary>
        public long PlanId { get; set; }

        /// <summary>
        /// 审批价格
        /// </summary>
        public decimal ApprovedTransportPrice { get; set; }

        /// <summary>
        /// 审批运费
        /// </summary>
        public decimal ApprovedTransportCharges { get; set; }

        /// <summary>
        /// 审批人编码
        /// </summary>
        public long ApproverId { get; set; }

        /// <summary>
        /// 审批人姓名
        /// </summary>
        public string ApproverName { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime ApproveTime { get; set; }
    }
}
