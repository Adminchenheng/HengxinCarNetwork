using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 安全配置信息
    /// </summary>
    public class Security
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string SecurityID { get; set; }
        /// <summary>
        /// 主驾驶安全气囊
        /// </summary>
        public string MainAirbag { get; set; }
        /// <summary>
        /// 副驾驶安全气囊
        /// </summary>
        public string ViceAirbag { get; set; }
        /// <summary>
        /// 前排侧气囊
        /// </summary>
        public string BeforeSideAirbag { get; set; }
        /// <summary>
        /// 后排侧气囊
        /// </summary>
        public string AfterSideAirbag { get; set; }
        /// <summary>
        /// 前气帘
        /// </summary>
        public string BeforeAirCurtain { get; set; }
        /// <summary>
        /// 后气帘
        /// </summary>
        public string AfterAirCurtain { get; set; }
        /// <summary>
        /// 遥控钥匙
        /// </summary>
        public string TheKey { get; set; }
        /// <summary>
        /// 无钥匙启动系统
        /// </summary>
        public string NoKey { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }
        
    }
}
