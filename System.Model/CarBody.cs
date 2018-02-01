using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 车身类型
    /// </summary>
    [TableAttribute(ID = "CarBodyID")]
    public class CarBody
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string CarBodyID { get; set; }
        /// <summary>
        /// 车身类型名称
        /// </summary>
        public string BodyName { get; set; }
        /// <summary>
        /// 车身子类型名称
        /// </summary>
        public string SonBodyName { get; set; }        
    }
}
