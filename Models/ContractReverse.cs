using System;

namespace InnoSoft.LS.Models
{
    public class ContractReverse
    {
        /// <summary>
        /// 冲帐记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 冲帐金额
        /// </summary>
        public decimal ReverseAmount { get; set; }

        /// <summary>
        /// 扣款金额
        /// </summary>
        public decimal WithholdAmount { get; set; }

        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal FactpaymentAmount { get; set; }

        /// <summary>
        /// 创建人编码
        /// </summary>
        public long CreatorId { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
