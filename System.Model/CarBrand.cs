using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 汽车品牌
    /// </summary>
    [TableAttribute(ID = "CarBrandID")]
    public class CarBrand
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string CarBrandID { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 子品牌名称
        /// </summary>
        public string SonBrand { get; set; }        
    }
}
