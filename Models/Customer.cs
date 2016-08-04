using System;

namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 客户实体对象类
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 客户编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 客户全称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 预警库存
        /// </summary>
        public int WarningStock { get; set; }

        /// <summary>
        /// 停止发货库存
        /// </summary>
        public int StopStock { get; set; }

        /// <summary>
        /// 结算公式
        /// </summary>
        public string SettlementExpression { get; set; }

        /// <summary>
        /// 计价模式
        /// </summary>
        public string ValuationMode { get; set; }

        /// <summary>
        /// 毛重率
        /// </summary>
        public decimal GrossWeightRate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 所属组织部门编码
        /// </summary>
        public long OwnOrganId { get; set; }

        /// <summary>
        /// 所属组织部门名称
        /// </summary>
        public string OwnOrganName { get; set; }
    }
}
