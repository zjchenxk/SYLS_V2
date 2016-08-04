using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 承运单位结算记录实体类
    /// </summary>
    public class CarrierTransportChargesSettlement
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long CarrierId { get; set; }

        /// <summary>
        /// 承运单位名称
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal SettlementAmount { get; set; }

        /// <summary>
        /// 扣款金额
        /// </summary>
        public decimal WithholdAmount { get; set; }

        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal FactpaymentAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
