using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 汽车价格类型
    /// </summary>
    [TableAttribute(ID = "CarMoneyID")]
    public class CarMoney
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string CarMoneyID { get; set; }
        /// <summary>
        /// 价格类型
        /// </summary>
        public string MoneyType { get; set; }        
    }
}
