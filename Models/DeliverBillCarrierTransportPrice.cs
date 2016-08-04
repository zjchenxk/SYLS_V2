using System;

namespace InnoSoft.LS.Models
{
    public class DeliverBillCarrierTransportPrice
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 送货单编码
        /// </summary>
        public long DeliverBillId { get; set; }

        /// <summary>
        /// 送货单号
        /// </summary>
        public string DeliverBillNo { get; set; }

        /// <summary>
        /// 交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long CarrierId { get; set; }

        /// <summary>
        /// 承运单位名称
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 调度价格
        /// </summary>
        public decimal DispatchedTransportPrice { get; set; }

        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal TransportPrice { get; set; }

        /// <summary>
        /// 实际运费
        /// </summary>
        public decimal TransportCharges { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人编码
        /// </summary>
        public long CreatorId { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// 创建部门办事处编码
        /// </summary>
        public long CreateOrganId { get; set; }

        /// <summary>
        /// 创建部门办事处名称
        /// </summary>
        public string CreateOrganName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
