using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;//引入反射程序命名空间

namespace System.Model
{
    /// <summary>
    /// 自定义特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]//绑定特性集成 
    public class TableAttribute : Attribute//继承特性
    {
        /// <summary>
        /// 用于绑定主键
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 用于绑定外键
        /// </summary>
        public string ForeignKey { get; set; }
        /// <summary>
        /// 用于绑定外键
        /// </summary>
        public string ForeignKey2 { get; set; }
        /// <summary>
        /// 用于绑定名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用于绑定时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 用于绑定移动设备
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 用于绑定名称
        /// </summary>
        public string ObjName { get; set; }


        public TableAttribute() { }//无参构造
        public TableAttribute(string id,string name,string time,string phone,string objName,string foreignkey, string foreignkey2)//有参构造
        {
            this.ID = id;
            this.ForeignKey = foreignkey;
            this.Name = name;
            this.Time = time;
            this.Phone = phone;
            this.ObjName = objName;
            this.ForeignKey2 = foreignkey2;
        }
        #region 数组数据赛选方法
        /// <summary>
        /// 数组数据赛选方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodel"></param>
        /// <returns></returns>
        public static string[] GetScreen<T>(T nodel)where T:new()
        {
            Type type = typeof(T);
            PropertyInfo[] per = type.GetProperties();
            string Name = "";
            TableAttribute table = new TableAttribute();
            foreach (PropertyInfo item in per)
            {
                object NameValue = table.GetAttributeValue<T>(nodel, item.Name);
                if (NameValue == DBNull.Value || NameValue == null || NameValue.ToString() == "0001/1/1 0:00:00"||NameValue.ToString()=="0")
                {
                     Name+= item.Name + ",";
                }
            }
            string[] Strarray = Name.Substring(0,Name.LastIndexOf(',')).Split(new char[] { ',' });
            return Strarray;
        }
        #endregion
        #region 根据反射对象指定属性名称返回相对值方法
        /// <summary>
        /// 根据反射对象指定属性名称返回相对值方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodel"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public object GetAttributeValue<T>(T nodel ,string Name)
        {
            return nodel.GetType().GetProperty(Name).GetValue(nodel,null);
        }
        #endregion
        #region 根据反射对象,返回自定义特性对象方法
        /// <summary>
        /// 根据反射对象,返回自定义特性对象方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static TableAttribute GetTable<T>()
        {
            Type type = typeof(T);
            object[] obj = type.GetCustomAttributes(false);
            TableAttribute table=obj[0] as TableAttribute;
            return table;
        }
        #endregion
        #region 根据反射对象,筛选出对象名是否加中括号方法
        /// <summary>
        /// 根据反射对象,筛选出对象名是否加中括号方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetObjName<T>()
        {
            Type type = typeof(T);
            object[] obj = type.GetCustomAttributes(false);
            TableAttribute table = obj[0] as TableAttribute;
            if (table.ObjName != null)
                return "[" + type.Name + "]";
            else
                return type.Name;
        }
        #endregion 
    }
}
