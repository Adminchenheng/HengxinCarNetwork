using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 分期
    /// </summary>
    public class Installment
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string InstallmentID { get; set; }
        /// <summary>
        /// 首次支出
        /// </summary>
        public decimal FristSpeeding { get; set; }
        /// <summary>
        /// 月租
        /// </summary>
        public decimal Rental { get; set; }
        /// <summary>
        /// 期限
        /// </summary>
        public int Timelimit { get; set; }
        
    }
}
