using System;

namespace EFMysqlFrameWork.Model
{
    /// <summary>
    /// 账号表
    /// </summary>
    public class User
    {
        /// <summary>
        /// 
        /// </summary>   
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string TenantId { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string RealName { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string UserCode { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Salt { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public int UserType { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Creator { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Reviser { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public DateTime ReviseTime { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public DateTime? LoginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string LastIP { get; set; }
    }
}
