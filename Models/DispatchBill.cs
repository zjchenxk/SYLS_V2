using System;

namespace InnoSoft.LS.Models
{
    public class DispatchBill
    {
        /// <summary>
        /// 调度单编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 调度单编号
        /// </summary>
        public string DispatchBillNo { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 挂车号
        /// </summary>
        public string TrailerNo { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 驾驶证号
        /// </summary>
        public string DriverLicenseNo { get; set; }

        /// <summary>
        /// 驾驶员手机
        /// </summary>
        public string DriverMobileTel { get; set; }

        /// <summary>
        /// 驾驶员住宅电话
        /// </summary>
        public string DriverHomeTel { get; set; }

        /// <summary>
        /// 承运单位编码
        /// </summary>
        public long CarrierId { get; set; }

        /// <summary>
        /// 承运单位名称
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// 车辆载重
        /// </summary>
        public int CarryingCapacity { get; set; }

        /// <summary>
        /// 经营性质
        /// </summary>
        public string BusinessType { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string PaymentType { get; set; }

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
        /// 累计运费
        /// </summary>
        public decimal TotalTransportCharges { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
