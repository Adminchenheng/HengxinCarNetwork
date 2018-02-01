using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 座椅配置信息
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string SeatID { get; set; }
        /// <summary>
        /// 座椅材质
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 座椅调节方向
        /// </summary>
        public int Aglin { get; set; }
        /// <summary>
        /// 腰部调节
        /// </summary>
        public string Waist { get; set; }
        /// <summary>
        /// 驾驶座调节
        /// </summary>
        public string DrivingSeat { get; set; }
        /// <summary>
        /// 电动记忆
        /// </summary>
        public string Memory { get; set; }
        /// <summary>
        /// 关联汽车信息表
        /// </summary>
        public string CarInfoID { get; set; }
        
    }
}
