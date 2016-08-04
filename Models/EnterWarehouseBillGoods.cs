using System;

namespace InnoSoft.LS.Models
{
    public class EnterWarehouseBillGoods
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 入库单编码
        /// </summary>
        public long EnterWarehouseBillId { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string EnterWarehouseBillNo { get; set; }

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
        /// 入库类型
        /// </summary>
        public string EnterType { get; set; }

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
        /// 货位
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 件数
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
        /// 对应划拨出仓单编码
        /// </summary>
        public string ShipmentBillGoodsIds { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
