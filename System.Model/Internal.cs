using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 内部配置信息
    /// </summary>
    public class Internal
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string InternalID { get; set; }
        /// <summary>
        /// 多功能方向盘
        /// </summary>
        public string Morefunction { get; set; }
        /// <summary>
        /// 巡航定速
        /// </summary>
        public string Cruise { get; set; }
        /// <summary>
        /// 倒车影像
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 电脑显示屏
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// HUD数字显示
        /// </summary>
        public string HUD { get; set; }
        /// <summary>
        /// GPS定位导航系统
        /// </summary>
        public string GPS { get; set; }
        /// <summary>
        /// 中央台液晶屏
        /// </summary>
        public string LCD { get; set; }
        /// <summary>
        /// CD
        /// </summary>
        public string CD { get; set; }
        /// <summary>
        /// DVD
        /// </summary>
        public string DVD { get; set; }
        /// <summary>
        /// 蓝牙
        /// </summary>
        public string Bluetooth { get; set; }
        /// <summary>
        /// 扬声器
        /// </summary>
        public string Spearker { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }        
    }
}
