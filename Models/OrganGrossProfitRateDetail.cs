namespace InnoSoft.LS.Models
{
    public class OrganGrossProfitRateDetail
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 装运单号
        /// </summary>
        public string ShipmentNo { get; set; }

        /// <summary>
        /// 交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

        /// <summary>
        /// 起点所在国家
        /// </summary>
        public string StartCountry { get; set; }

        /// <summary>
        /// 起点所在省份
        /// </summary>
        public string StartProvince { get; set; }

        /// <summary>
        /// 起点所在城市
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 提货单位所在国家
        /// </summary>
        public string ReceiverCountry { get; set; }

        /// <summary>
        /// 提货单位所在省份
        /// </summary>
        public string ReceiverProvince { get; set; }

        /// <summary>
        /// 收货单位所在城市
        /// </summary>
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 收货单位地址
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 公里数
        /// </summary>
        public string KM { get; set; }

        /// <summary>
        /// 累计件数
        /// </summary>
        public int TotalPackages { get; set; }

        /// <summary>
        /// 累计吨数
        /// </summary>
        public decimal TotalTunnages { get; set; }

        /// <summary>
        /// 累计垛数
        /// </summary>
        public decimal TotalPiles { get; set; }

        /// <summary>
        /// 累计万只
        /// </summary>
        public decimal TotalTenThousands { get; set; }

        /// <summary>
        /// 客户结算单价
        /// </summary>
        public decimal CustomerTransportPrice { get; set; }

        /// <summary>
        /// 过江费
        /// </summary>
        public decimal CustomerRiverCrossingCharges { get; set; }

        /// <summary>
        /// 客户结算公式
        /// </summary>
        public string CustomerSettlementExpression { get; set; }

        /// <summary>
        /// 客户运费
        /// </summary>
        public decimal CustomerTransportCharges { get; set; }

        /// <summary>
        /// 客户拼车费
        /// </summary>
        public decimal CustomerCarpoolFee { get; set; }

        /// <summary>
        /// 承运单位运费
        /// </summary>
        public decimal CarrierTransportCharges { get; set; }

        /// <summary>
        /// 所属部门办事处编码
        /// </summary>
        public long OwnOrganId { get; set; }

        /// <summary>
        /// 所属部门办事处名称
        /// </summary>
        public string OwnOrganName { get; set; }
    }
}
