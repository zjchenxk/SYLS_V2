using System;

namespace InnoSoft.LS.Models
{
    public class EnterWarehouseBill
    {
        /// <summary>
        /// 入库单编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 计划编码
        /// </summary>
        public long PlanId { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

        /// <summary>
        /// 入库类别
        /// </summary>
        public string EnterType { get; set; }

        /// <summary>
        /// 是否寄库标志
        /// </summary>
        public bool IsConsigning { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// 下力资费价格
        /// </summary>
        public decimal UnloadingForceFeePrice { get; set; }

        /// <summary>
        /// 力支费
        /// </summary>
        public decimal ForceFee { get; set; }

        /// <summary>
        /// 仓储费价格
        /// </summary>
        public decimal StorageFeePrice { get; set; }

        /// <summary>
        /// 是否有短驳费标志
        /// </summary>
        public bool HasDrayage { get; set; }

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
