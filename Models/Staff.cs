using System;

namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 员工实体类
    /// </summary>
    public class Staff
    {
        /// <summary>
        /// 员工编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 姓氏
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// 名子
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 组织部门编码
        /// </summary>
        public long OrganId { get; set; }

        /// <summary>
        /// 组织部门名称
        /// </summary>
        public string OrganName { get; set; }

        /// <summary>
        /// 组织部门全名称
        /// </summary>
        public string OrganFullName { get; set; }

        /// <summary>
        /// 组织部门全路径
        /// </summary>
        public string OrganFullPath { get; set; }

        /// <summary>
        /// 职位编码
        /// </summary>
        public long PositionId { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 办公电话
        /// </summary>
        public string OfficeTel { get; set; }

        /// <summary>
        /// 分机
        /// </summary>
        public string TelExt { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 手机1
        /// </summary>
        public string MobileTel1 { get; set; }

        /// <summary>
        /// 手机2
        /// </summary>
        public string MobileTel2 { get; set; }

        /// <summary>
        /// 手机3
        /// </summary>
        public string MobileTel3 { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 上司编码
        /// </summary>
        public long BossStaffId { get; set; }

        /// <summary>
        /// 上司姓名
        /// </summary>
        public string BossStaffName { get; set; }

        /// <summary>
        /// 是否为组织部门管理人员标志
        /// </summary>
        public bool IsOrganManager { get; set; }

        /// <summary>
        /// 是否为组织部门负责人标志
        /// </summary>
        public bool IsOrganLeader { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
