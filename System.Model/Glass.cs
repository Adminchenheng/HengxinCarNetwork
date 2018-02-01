using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 后视镜配置信息
    /// </summary>
    public class Glass
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string GlassID { get; set; }
        /// <summary>
        /// 车窗
        /// </summary>
        public string CarWindow { get; set; }
        /// <summary>
        /// 防夹手功能
        /// </summary>
        public string Clip { get; set; }
        /// <summary>
        /// 车窗防夹手功能
        /// </summary>
        public string Electric { get; set; }
        /// <summary>
        /// 加热功能
        /// </summary>
        public string Heating { get; set; }
        /// <summary>
        /// 内后视镜防眩目功能
        /// </summary>
        public string Antiglare { get; set; }
        /// <summary>
        /// 后视镜电动折叠
        /// </summary>
        public string Folding { get; set; }
        /// <summary>
        /// 后视镜记忆
        /// </summary>
        public string MirrorMomey { get; set; }
        /// <summary>
        /// 雨感应刷
        /// </summary>
        public string Shouldbrush { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }
        
    }
}
