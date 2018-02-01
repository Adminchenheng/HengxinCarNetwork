using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 发动机配置
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// 发动机主键
        /// </summary>
        public string EngineID { get; set; }
        /// <summary>
        /// 发动机型号
        /// </summary>
        public string EngineModel { get; set; }
        /// <summary>
        /// 进气形式
        /// </summary>
        public string Intake { get; set; }
        /// <summary>
        /// 最大马力
        /// </summary>
        public int Force { get; set; }
        /// <summary>
        /// 供油方式
        /// </summary>
        public string OilSupply { get; set; }
        /// <summary>
        /// 档位个数
        /// </summary>
        public int Gear { get; set; }
        /// <summary>
        /// 气缸排列形式
        /// </summary>
        public string Cylinder { get; set;}
        /// <summary>
        /// 油箱容积
        /// </summary>
        public double OilBox { get; set; }
        /// <summary>
        /// 功率值
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// 最大功率值
        /// </summary>
        public int MaxPower { get; set; }
        /// <summary>
        /// 转速值
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// 扭矩值
        /// </summary>
        public int Torque { get; set; }
        /// <summary>
        /// 最大扭矩值
        /// </summary>
        public int MaxTorque { get; set; }
        /// <summary>
        /// 环保标准
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }
        
    }
}
