﻿using System;

namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 客户仓储费价格实体类
    /// </summary>
    public class CustomerStorageFeePrice
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
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 仓储费
        /// </summary>
        public decimal StorageFeePrice { get; set; }

    }
}
