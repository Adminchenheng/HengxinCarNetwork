using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    [TableAttribute(ID ="UserID",Phone = "UserPhone",ObjName ="User")]
    public class User
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 微信或qq
        /// </summary>
        public string WeChatQQ { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string CardID { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime UserTime { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string UserAddress { get; set; }
        /// <summary>
        /// 关联密保问题
        /// </summary>
        public string EncryptedID { get; set; }
        
    }
}
