using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 底盘配置信息
    /// </summary>
    public class Chassis
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ChassisID { get; set; }
        /// <summary>
        /// 驱动方式
        /// </summary>
        public string Drive { get; set; }
        /// <summary>
        /// 助力类型
        /// </summary>
        public string Help { get; set; }
        /// <summary>
        /// 前悬挂形式
        /// </summary>
        public string Suspension { get; set; }
        /// <summary>
        /// 后悬挂形式
        /// </summary>
        public string AfterSuspenSion { get; set; }
        /// <summary>
        /// 前制动类型
        /// </summary>
        public string BeforeBrake { get; set; }
        /// <summary>
        /// 后制动类型
        /// </summary>
        public string AfterBrake { get; set; }
        /// <summary>
        /// 刹车类型
        /// </summary>
        public string Brack { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }
        
    }
}
