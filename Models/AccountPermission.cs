namespace InnoSoft.LS.Models
{
    /// <summary>
    /// 帐号权限实体类
    /// </summary>
    public class AccountPermission
    {
        /// <summary>
        /// 记录编码
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 帐号编码
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// 组编码
        /// </summary>
        public long GroupId { get; set; }
    }
}
