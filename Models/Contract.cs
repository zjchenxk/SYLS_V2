using System;

namespace InnoSoft.LS.Models
{
    public class Contract
    {
        /// <summary>
        /// 合同编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 调度单编码
        /// </summary>
        public long DispatchBillId { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNo { get; set; }

        /// <summary>
        /// 原始合同号
        /// </summary>
        public string OriginalContractNo { get; set; }

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
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 包装样式
        /// </summary>
        public string Packing { get; set; }

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
        /// 到达时间
        /// </summary>
        public DateTime ArrivalTime { get; set; }

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
        /// 预付运费
        /// </summary>
        public decimal PrepayTransportCharges { get; set; }

        /// <summary>
        /// 剩余运费
        /// </summary>
        public decimal ResidualTransportCharges { get; set; }

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
        /// 审批状态
        /// </summary>
        public string ApproveState { get; set; }

        /// <summary>
        /// 当前审批步骤序号
        /// </summary>
        public int ApproveFlowStepNum { get; set; }

        /// <summary>
        /// 当前审批步骤名称
        /// </summary>
        public string ApproveFlowStepName { get; set; }

        /// <summary>
        /// 当前审批人编码
        /// </summary>
        public long ApproverId { get; set; }

        /// <summary>
        /// 当前审批人姓名
        /// </summary>
        public string ApproverName { get; set; }

        /// <summary>
        /// 已审批记录数
        /// </summary>
        public int ApproveCount { get; set; }

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
        /// 罚款金额
        /// </summary>
        public decimal FineAmount { get; set; }

        /// <summary>
        /// 罚款时间
        /// </summary>
        public DateTime FineTime { get; set; }

        /// <summary>
        /// 是否配载合同标志
        /// </summary>
        public bool IsPrestowage { get; set; }

        /// <summary>
        /// 累计原始运费
        /// </summary>
        public decimal TotalOriginalTransportCharges { get; set; }

        /// <summary>
        /// 累计审批运费
        /// </summary>
        public decimal TotalApprovedTransportCharges { get; set; }
    }
}
