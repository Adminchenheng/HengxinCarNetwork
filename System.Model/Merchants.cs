using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 商家
    /// </summary>
    public class Merchants
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string MerchantsID { get; set; }
        /// <summary>
        /// 公司类别
        /// </summary>
        public string CompanyType { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public int ContactPhone { get; set; }
        /// <summary>
        /// 商家登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplyforTime { get; set; }
        /// <summary>
        /// 关联密保问题表
        /// </summary>
        public string EncryptedID { get; set; }        
    }
}
