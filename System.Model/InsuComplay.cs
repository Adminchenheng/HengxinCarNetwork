using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 保险公司
    /// </summary>
    [TableAttribute(ID = "InsuComplayID",Name = "ComplayName",Phone = "Phone")]
    public class InsuComplay
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string InsuComplayID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string ComplayName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Phone { get; set; }
        
    }
}
