using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 高科技配置
    /// </summary>
    public class HighTech
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string HighTechID { get; set; }
        /// <summary>
        /// 自动泊车
        /// </summary>
        public string Parking { get; set; }
        /// <summary>
        /// 并线辅助
        /// </summary>
        public string Andlines { get; set; }
        /// <summary>
        /// 主刹系统
        /// </summary>
        public string MainBrake{ get; set; } 
        /// <summary>
        /// 夜视系统
        /// </summary>
        public string Nightvision { get; set; }
        /// <summary>
        /// 全景设像头
        /// </summary>
        public string Camera { get; set; }
        /// <summary>
        /// 自适应巡航
        /// </summary>
        public string Adaptivecruise { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }
        
    }
}
