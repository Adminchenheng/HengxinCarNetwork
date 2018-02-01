using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 灯光配置信息
    /// </summary>
    public class Light
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string LightID { get; set; }
        /// <summary>
        /// 大灯类型
        /// </summary>
        public string HeadLight { get; set; }
        /// <summary>
        /// 日间灯是否有
        /// </summary>
        public string DayLight { get; set; }
        /// <summary>
        /// 自动头灯
        /// </summary>
        public string Automatic { get; set; }
        /// <summary>
        /// 车内灯
        /// </summary>
        public string CarInternal { get; set; }
        /// <summary>
        /// 转向灯
        /// </summary>
        public string Turnto { get; set; }
        /// <summary>
        /// 前雾灯
        /// </summary>
        public string BeforeFog { get; set; }
        /// <summary>
        /// 大灯高度
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// 大灯清洗装置
        /// </summary>
        public string Cleaning { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }
        
    }
}
