namespace InnoSoft.LS.Models
{
    public class PendingCount
    {
        //待提交计划个数
        public int SubmitDeliverPlansCount { get; set; }

        //客户审核计划个数
        public int CustomerApprovePaperPlansCount { get; set; }

        //审批计划个数
        public int ApproveDeliverPlansCount { get; set; }

        //调度计划个数
        public int DispatchDeliverPlansCount { get; set; }

        //待提交调度单个数
        public int SubmitDispatchBillsCount { get; set; }

        //待打印调度出仓单的调度单个数
        public int DispatchBillsForPrintDispatchedShipmentBillCount { get; set; }

        //待打印划拨出仓单个数
        public int PrintAllocateShipmentBillsCount { get; set; }

        //待提交出仓单个数
        public int SubmitShipmentBillsCount { get; set; }

        //待打印送货单个数
        public int PrintDeliverBillsCount { get; set; }

        //待接收回单送货单个数
        public int ReceiptDeliverBillsCount { get; set; }

        //待录入合同个数
        public int NewContractsCount { get; set; }

        //待提交合同个数
        public int SubmitContractsCount { get; set; }

        //待打印合同个数
        public int PrintContractsCount { get; set; }

        //审批价格合同个数
        public int ApproveContractsCount { get; set; }

        //待冲帐合同个数
        public int ReverseContractsCount { get; set; }

        //待罚款处理合同个数
        public int FineContractsCount { get; set; }
    }
}
