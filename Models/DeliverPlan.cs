using System;

namespace InnoSoft.LS.Models
{
    public class DeliverPlan
    {
        /// <summary>
        /// 计划编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 计划单号
        /// </summary>
        public string PlanNo { get; set; }

        /// <summary>
        /// 计划类别
        /// </summary>
        public string PlanType { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 装运单号
        /// </summary>
        public string ShipmentNo { get; set; }

        /// <summary>
        /// 交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

        /// <summary>
        /// 出库类别
        /// </summary>
        public string DeliverType { get; set; }

        /// <summary>
        /// 提货单位名称
        /// </summary>
        public string ReceiverName { get; set; }

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
        /// 收货单位联系人姓名
        /// </summary>
        public string ReceiverContact { get; set; }

        /// <summary>
        /// 收货单位联系人电话
        /// </summary>
        public string ReceiverContactTel { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 提货方式
        /// </summary>
        public string ReceiveType { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 挂车号
        /// </summary>
        public string TrailerNo { get; set; }

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
        /// 发货仓库
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// 到货时间
        /// </summary>
        public string ArrivalTime { get; set; }

        /// <summary>
        /// 结算付款单位编码
        /// </summary>
        public long PayerId { get; set; }

        /// <summary>
        /// 结算付款单位名称
        /// </summary>
        public string PayerName { get; set; }

        /// <summary>
        /// 是否寄库
        /// </summary>
        public bool IsConsigning { get; set; }

        /// <summary>
        /// 寄库交货单号
        /// </summary>
        public string ConsignedDeliveryNo { get; set; }

        /// <summary>
        /// 是否分期发货
        /// </summary>
        public bool IsInstalment { get; set; }

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
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人编码
        /// </summary>
        public long CreatorId { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// 创建部门办事处编码
        /// </summary>
        public long CreateOrganId { get; set; }

        /// <summary>
        /// 创建部门办事处名称
        /// </summary>
        public string CreateOrganName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 所属部门办事处编码
        /// </summary>
        public long OwnOrganId { get; set; }

        /// <summary>
        /// 所属部门办事处名称
        /// </summary>
        public string OwnOrganName { get; set; }

        /// <summary>
        /// 计划状态，待提交/待客户审批/待审批/生效/取消
        /// </summary>
        public string PlanState { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 最后一次审批结论
        /// </summary>
        public string LastIsAgreed { get; set; }

        /// <summary>
        /// 最后一次审批意见
        /// </summary>
        public string LastApproveComment { get; set; }

        /// <summary>
        /// 最后一次审批人编码
        /// </summary>
        public long LastApproverId { get; set; }

        /// <summary>
        /// 最后一次审批人姓名
        /// </summary>
        public string LastApproverName { get; set; }

        /// <summary>
        /// 总吨数
        /// </summary>
        public decimal TotalTunnages { get; set; }

        /// <summary>
        /// 总垛数
        /// </summary>
        public decimal TotalPiles { get; set; }

        /// <summary>
        /// 剩余吨数
        /// </summary>
        public decimal BalanceTunnages { get; set; }

        /// <summary>
        /// 剩余垛数
        /// </summary>
        public decimal BalancePiles { get; set; }

        /// <summary>
        /// 合同冲帐标志
        /// </summary>
        public bool IsContractReversed { get; set; }

        /// <summary>
        /// 客户结算标志
        /// </summary>
        public bool IsCustomerTransportChargesSettled { get; set; }

        /// <summary>
        /// 承运单位结算标志
        /// </summary>
        public bool IsCarrierTransportChargesSettled { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRows { get; set; }
    }
}
