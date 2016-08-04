using System;

namespace InnoSoft.LS.Models
{
    public class DispatchBillGoods
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 调度单编码
        /// </summary>
        public long DispatchBillId { get; set; }

        /// <summary>
        /// 计划编码
        /// </summary>
        public long PlanId { get; set; }

        /// <summary>
        /// 货物编码
        /// </summary>
        public long GoodsId { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>
        public long TypeId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 类别全路径
        /// </summary>
        public string TypeFullPath { get; set; }

        /// <summary>
        /// 类别全名称
        /// </summary>
        public string TypeFullName { get; set; }

        /// <summary>
        /// 货物编码
        /// </summary>
        public string GoodsNo { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string SpecModel { get; set; }

        /// <summary>
        /// 克重
        /// </summary>
        public string GWeight { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 件重
        /// </summary>
        public decimal PieceWeight { get; set; }

        /// <summary>
        /// 包装
        /// </summary>
        public string Packing { get; set; }

        /// <summary>
        /// 批次编号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// 货位
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 件数/箱数
        /// </summary>
        public int Packages { get; set; }

        /// <summary>
        /// 吨数
        /// </summary>
        public decimal Tunnages { get; set; }

        /// <summary>
        /// 垛数
        /// </summary>
        public decimal Piles { get; set; }

        /// <summary>
        /// 万只
        /// </summary>
        public decimal TenThousands { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductionDate { get; set; }

        /// <summary>
        /// 入库单编码
        /// </summary>
        public long EnterWarehouseBillId { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string EnterWarehouseBillNo { get; set; }

        /// <summary>
        /// 实发件数/箱数
        /// </summary>
        public int ActualPackages { get; set; }

        /// <summary>
        /// 实发吨数
        /// </summary>
        public decimal ActualTunnages { get; set; }

        /// <summary>
        /// 实发垛数
        /// </summary>
        public decimal ActualPiles { get; set; }

        /// <summary>
        /// 实发万只
        /// </summary>
        public decimal ActualTenThousands { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 挂号
        /// </summary>
        public string TrailerNo { get; set; }

        /// <summary>
        /// 调度时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
