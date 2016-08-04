using System;

namespace InnoSoft.LS.Models
{
    public class ContractReverseDetail
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 冲帐记录编码
        /// </summary>
        public long ReverseId { get; set; }

        /// <summary>
        /// 合同编码
        /// </summary>
        public long ContractId { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNo { get; set; }

        /// <summary>
        /// 原始合同号
        /// </summary>
        public string OriginalContractNo { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        public string StartPlace { get; set; }

        /// <summary>
        /// 终点
        /// </summary>
        public string DestPlace { get; set; }

        /// <summary>
        /// 装车时间
        /// </summary>
        public DateTime ShipmentTime { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 挂号
        /// </summary>
        public string TrailerNo { get; set; }

        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 驾驶员手机
        /// </summary>
        public string DriverMobileTel { get; set; }

        /// <summary>
        /// 累计吨数
        /// </summary>
        public decimal TotalTunnages { get; set; }

        /// <summary>
        /// 累计垛数
        /// </summary>
        public decimal TotalPiles { get; set; }

        /// <summary>
        /// 累计运费
        /// </summary>
        public decimal TotalTransportCharges { get; set; }

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
