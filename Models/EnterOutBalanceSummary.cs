using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoSoft.LS.Models
{
    public class EnterOutBalanceSummary
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
        /// 货物编码
        /// </summary>
        public long GoodsId { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

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
        /// 批次号
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
        /// 期初结存件数
        /// </summary>
        public int StartPackages { get; set; }

        /// <summary>
        /// 期初结存吨数
        /// </summary>
        public decimal StartTunnages { get; set; }

        /// <summary>
        /// 期初结存垛数
        /// </summary>
        public decimal StartPiles { get; set; }

        /// <summary>
        /// 期初结存万只
        /// </summary>
        public decimal StartTenThousands { get; set; }

        /// <summary>
        /// 累计入库件数
        /// </summary>
        public int TotalEnterWarehousePackages { get; set; }

        /// <summary>
        /// 累计入库吨数
        /// </summary>
        public decimal TotalEnterWarehouseTunnages { get; set; }

        /// <summary>
        /// 累计入库垛数
        /// </summary>
        public decimal TotalEnterWarehousePiles { get; set; }

        /// <summary>
        /// 累计入库万只
        /// </summary>
        public decimal TotalEnterWarehouseTenThousands { get; set; }

        /// <summary>
        /// 累计出库件数
        /// </summary>
        public int TotalOutWarehousePackages { get; set; }

        /// <summary>
        /// 累计出库吨数
        /// </summary>
        public decimal TotalOutWarehouseTunnages { get; set; }

        /// <summary>
        /// 累计出库垛数
        /// </summary>
        public decimal TotalOutWarehousePiles { get; set; }

        /// <summary>
        /// 累计出库万只
        /// </summary>
        public decimal TotalOutWarehouseTenThousands { get; set; }

        /// <summary>
        /// 期末结存件数
        /// </summary>
        public int EndPackages { get; set; }

        /// <summary>
        /// 期末结存吨数
        /// </summary>
        public decimal EndTunnages { get; set; }

        /// <summary>
        /// 期末结存垛数
        /// </summary>
        public decimal EndPiles { get; set; }

        /// <summary>
        /// 期末结存万只
        /// </summary>
        public decimal EndTenThousands { get; set; }

        /// <summary>
        /// 累计划拨入库件数
        /// </summary>
        public int TotalAllocateEnterWarehousePackages { get; set; }

        /// <summary>
        /// 累计划拨入库吨数
        /// </summary>
        public decimal TotalAllocateEnterWarehouseTunnages { get; set; }

        /// <summary>
        /// 累计划拨入库垛数
        /// </summary>
        public decimal TotalAllocateEnterWarehousePiles { get; set; }

        /// <summary>
        /// 累计划拨入库万只
        /// </summary>
        public decimal TotalAllocateEnterWarehouseTenThousands { get; set; }

        /// <summary>
        /// 累计划拨出库件数
        /// </summary>
        public int TotalAllocateOutWarehousePackages { get; set; }

        /// <summary>
        /// 累计划拨出库吨数
        /// </summary>
        public decimal TotalAllocateOutWarehouseTunnages { get; set; }

        /// <summary>
        /// 累计划拨出库垛数
        /// </summary>
        public decimal TotalAllocateOutWarehousePiles { get; set; }

        /// <summary>
        /// 累计划拨出库万只
        /// </summary>
        public decimal TotalAllocateOutWarehouseTenThousands { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductionDate { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        //public string Warehouse { get; set; }
    }
}
