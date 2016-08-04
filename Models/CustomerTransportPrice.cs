using System;

namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 客户结算价格实体类
    /// </summary>
    public class CustomerTransportPrice
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
        /// 起点国家
        /// </summary>
        public string StartCountry { get; set; }

        /// <summary>
        /// 起点省份
        /// </summary>
        public string StartProvince { get; set; }

        /// <summary>
        /// 起点城市
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 讫点国家
        /// </summary>
        public string DestCountry { get; set; }

        /// <summary>
        /// 讫点省份
        /// </summary>
        public string DestProvince { get; set; }

        /// <summary>
        /// 讫点城市
        /// </summary>
        public string DestCity { get; set; }

        /// <summary>
        /// 吨位（垛位）下限
        /// </summary>
        public decimal MinTunnagesOrPiles { get; set; }

        /// <summary>
        /// 吨位（垛位）上限
        /// </summary>
        public decimal MaxTunnagesOrPiles { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 运输价格
        /// </summary>
        public decimal TransportPrice { get; set; }

        /// <summary>
        /// 过江费
        /// </summary>
        public decimal RiverCrossingCharges { get; set; }
    }
}
