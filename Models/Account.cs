using System;

namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 帐号实体类
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 帐号编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 帐号名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 帐号密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 帐号类别
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// 所属组织部门或客户的编码
        /// </summary>
        public long OrganId { get; set; }

        /// <summary>
        /// 所属组织部门或客户的名称
        /// </summary>
        public string OrganFullName { get; set; }

        /// <summary>
        /// 所属组织部门员工或客户联系人的编码
        /// </summary>
        public long StaffId { get; set; }

        /// <summary>
        /// 所属组织部门员工或客户联系人的姓名
        /// </summary>
        public string StaffName { get; set; }

        /// <summary>
        /// 是否注销标志
        /// </summary>
        public bool IsCancel { get; set; }

        /// <summary>
        /// 在线数据起始编码
        /// </summary>
        public long OnlineStartId { get; set; }

        /// <summary>
        /// 离线数据起始编码
        /// </summary>
        public long OfflineStartId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
