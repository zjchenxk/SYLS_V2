namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 组织部门实体类
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// 组织部门编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 组织部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上级组织部门编码
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 上级组织部门名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 组织部门全名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 组织部门全路径
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// 所在国家
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// 所在省份
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 街道地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 组织部门负责人编码
        /// </summary>
        public long ManagerId { get; set; }

        /// <summary>
        /// 组织部门负责人姓名
        /// </summary>
        public string ManagerName { get; set; }
    }
}
