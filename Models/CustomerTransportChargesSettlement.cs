using System;

namespace InnoSoft.LS.Models
{
    public class CustomerTransportChargesSettlement
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 发票号码
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 发票类别
        /// </summary>
        public string InvoiceType { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal InvoiceAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 开票时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
