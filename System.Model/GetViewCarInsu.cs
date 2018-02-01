using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 车与分期付款两表查询试图
    /// </summary>
    [TableAttribute(ID = "CarID")]
    public class GetViewCarInsu
    {
        /// <summary>
        /// 汽车主键
        /// </summary>
        public string CarID { get; set; }
        /// <summary>
        /// 汽车名称
        /// </summary>
        public string CarName { get; set; }
        /// <summary>
        /// 汽车款式
        /// </summary>
        public string CarStyle { get; set; }
        /// <summary>
        /// 汽车型态
        /// </summary>
        public string CarType { get; set; }
        /// <summary>
        /// 厂商指导价
        /// </summary>
        public decimal Vendor { get; set; }
        /// <summary>
        /// 参考价
        /// </summary>
        public decimal ReferPrice { get; set; }
        /// <summary>
        /// 排量（升）
        /// </summary>
        public double Displacement { get; set; }
        /// <summary>
        /// 变数箱
        /// </summary>
	    public string Variable { get; set; }
        /// <summary>
        /// 油耗
        /// </summary>
        public double OysterSauce { get; set; }
        /// <summary>
        /// 座位个数
        /// </summary>
        public int Seat { get; set; }
        /// <summary>
        /// 二手车龄
        /// </summary>
        public int CarAge { get; set; }
        /// <summary>
        /// 二手车里程
        /// </summary>
        public double Mileage { get; set; }
        /// <summary>
        /// 二手车所在城市
        /// </summary>
        public string CarCity { get; set; }        
        /// <summary>
        /// 二手车上牌时间
        /// </summary>
        public string Card { get; set; }
        /// <summary>
        /// 是否为二手车0新车、1二手车
        /// </summary>
        public int TrueFalse { get; set; }
        /// <summary>
        /// 关联车身类型表
        /// </summary>
        public string CarBodyID { get; set; }
        /// <summary>
        /// 关联汽车价格表
        /// </summary>
        public string CarMoneyID { get; set; }
        /// <summary>
        /// 关联汽车品牌表
        /// </summary>
        public string CarBrandID { get; set; }
        /// <summary>
        /// 关联商家表
        /// </summary>
        public string MerchantsID { get; set; }
        /// <summary>
        /// 关联车险公司表
        /// </summary>
        public string InsuComplayID { get; set; }
        /// <summary>
        /// 关联分期付款表
        /// </summary>
        public string InstallmentID { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string InstaID { get; set; }
        /// <summary>
        /// 首次支出
        /// </summary>
        public decimal FristSpeeding { get; set; }
        /// <summary>
        /// 月租
        /// </summary>
        public decimal Rental { get; set; }
        /// <summary>
        /// 期限
        /// </summary>
        public int Timelimit { get; set; }
    }
}
