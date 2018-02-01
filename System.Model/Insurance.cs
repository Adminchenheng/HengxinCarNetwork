using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 车险
    /// </summary>
    public class Insurance
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string InsuranceID { get; set; }
        /// <summary>
        /// 较强险
        /// </summary>
        public decimal Strong { get; set; }
        /// <summary>
        /// 盗抢险
        /// </summary>
        public decimal DaoQing { get; set; }
        /// <summary>
        /// 车损险
        /// </summary>
        public decimal Carloss { get; set; }
        /// <summary>
        /// 三者险
        /// </summary>
        public decimal Three { get; set; }        
    }
}
