namespace InnoSoft.LS.Models
{
    public class StatStorageAndForceFee
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 累计移仓入库吨数
        /// </summary>
        public decimal TotalDeliverEnterWarehouseTunnages { get; set; }

        /// <summary>
        /// 累计移仓入库垛数
        /// </summary>
        public decimal TotalDeliverEnterWarehousePiles { get; set; }

        /// <summary>
        /// 下力资费单价
        /// </summary>
        public decimal UnloadingForceFeePrice { get; set; }

        /// <summary>
        /// 移仓入库力支费
        /// </summary>
        public decimal DeliverEnterWarehouseForceFee { get; set; }

        /// <summary>
        /// 累计划拨入库吨数
        /// </summary>
        public decimal TotalAllocateEnterWarehouseTunnages { get; set; }

        /// <summary>
        /// 累计发货出库吨数
        /// </summary>
        public decimal TotalDeliverOutWarehouseTunnages { get; set; }

        /// <summary>
        /// 累计发货出库垛数
        /// </summary>
        public decimal TotalDeliverOutWarehousePiles { get; set; }

        /// <summary>
        /// 上力支费单价
        /// </summary>
        public decimal LoadingForceFeePrice { get; set; }

        /// <summary>
        /// 发货出库力支费
        /// </summary>
        public decimal DeliverOutWarehouseForceFee { get; set; }

        /// <summary>
        /// 累计划拨出库吨数
        /// </summary>
        public decimal TotalAllocateOutWarehouseTunnages { get; set; }

        /// <summary>
        /// 划拨出库力支费
        /// </summary>
        public decimal AllocateOutWarehouseForceFee { get; set; }

        /// <summary>
        /// 结存吨数
        /// </summary>
        public decimal BalanceTunnages { get; set; }

        /// <summary>
        /// 结存垛数
        /// </summary>
        public decimal BalancePiles { get; set; }

        /// <summary>
        /// 仓储费单价
        /// </summary>
        public decimal StorageFeePrice { get; set; }

        /// <summary>
        /// 仓储费
        /// </summary>
        public decimal StorageFee { get; set; }
    }
}
