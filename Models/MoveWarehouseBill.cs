using System;

namespace InnoSoft.LS.Models
{
    public class MoveWarehouseBill
    {
        /// <summary>
        /// 移库单编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 移库单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// 寄库交货单号
        /// </summary>
        public string ConsignedDeliveryNo { get; set; }

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
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
