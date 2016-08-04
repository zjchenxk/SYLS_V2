using System;

namespace InnoSoft.LS.Models
{
    public class CarrierTransportPrice
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long CarrierId { get; set; }

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
        /// 计划类别
        /// </summary>
        public string PlanType { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 运输价格
        /// </summary>
        public decimal TransportPrice { get; set; }
    }
}
