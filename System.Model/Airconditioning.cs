using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 空调配置信息
    /// </summary>
    public class Airconditioning
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string AirID { get; set; }
        /// <summary>
        /// 空调控制方式
        /// </summary>
        public string ControlMode { get; set; }
        /// <summary>
        /// 后排独立空调
        /// </summary>
        public string Independent { get; set; }
        /// <summary>
        /// 后排出风口
        /// </summary>
        public string Outlet { get; set; }
        /// <summary>
        /// 温度分区控制
        /// </summary>
        public string Wen { get; set; }
        /// <summary>
        /// 空气调节
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 车载冰箱
        /// </summary>
        public string Icebox { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }       

    }
}
