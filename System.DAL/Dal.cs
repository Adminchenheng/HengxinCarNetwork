using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Model;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL
{
    public class Dal
    {
        #region 访问层、数据读取方法
        /// <summary>
        /// 访问层、数据读取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T>GetDataMethod<T>(params string[]array)where T:new()
        {
            string Name = TableAttribute.GetObjName<T>();
            string strsql = "select * from " + Name;
            SqlDataReader dr = DBHelper.ExecuteReader(strsql);//获取数据读取对象
            return DBHelper.GetPertend<T>(dr);
        }
        /// <summary>
        /// 访问层、条件数据读取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramter"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T>GetDataMethod<T>(string paramter,params string[] array)where T:new()
        {
           
            string strsql = "select * from " + TableAttribute.GetObjName<T>() + " where " + paramter;
            SqlDataReader dr = DBHelper.ExecuteReader(strsql);
            return DBHelper.GetPertend<T>(dr);
        }
        #endregion
        #region 访问层、查询前几条数据方法
        /// <summary>
        /// 访问层、查询前几条数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rocord"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T>GetTopDataMethod<T>(int rocord,params string[]array)where T:new()
        {
            string strsql = "select top(@rocord) * from " + typeof(T).Name;
            SqlParameter[] p = { new SqlParameter("@rocord", rocord) };
            SqlDataReader dr = DBHelper.ExecuteReader(strsql,p);
            return DBHelper.GetPertend<T>(dr);
        }
        /// <summary>
        /// 访问层、带条件查询前几条数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rocord"></param>
        /// <param name="paramter"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T> GetTopDataMethod<T>(int rocord,string paramter, params string[] array) where T : new()
        {
            string strsql = "select top("+rocord+") * from "+typeof(T).Name+" where "+paramter;
            SqlDataReader dr = DBHelper.ExecuteReader(strsql);
            return DBHelper.GetPertend<T>(dr);
        }
        #endregion 
        #region 访问层、调用存储过程方法
        /// <summary>
        /// 访问层、调用存储过程方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ProcName"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<T>GetProcMetod<T>(string ProcName,params SqlParameter[]p)where T:new()
        {
            return DBHelper.GetPertendProc<T>(ProcName, p);
        }
        #endregion 
        #region 访问层、数据统计方法
        /// <summary>
        /// 访问层、数据统计方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetDataCount<T>() where T : new()
        {
            string Name = TableAttribute.GetObjName<T>();
            string strsql = "select count(*) from " + Name;
            int count = Convert.ToInt32(DBHelper.ExecuteScalar(strsql));
            return count;
        }
        /// <summary>
        /// 访问层、条件参数数据统计方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Cond"></param>
        /// <returns></returns>
        public static int GetDataCount<T>(string paramter) where T : new()
        {
            string Name = TableAttribute.GetObjName<T>();
            string strsql = "select count(*) from " + Name + " where " + paramter;
            int count = Convert.ToInt32(DBHelper.ExecuteScalar(strsql));
            return count;
        }
        #endregion
        #region 访问层、数据添加方法
        /// <summary>
        /// 访问层、数据添加方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int AddDataMethod<T>(T nodel, string[] msg) where T : new()
        {
            string Name = TableAttribute.GetObjName<T>();
            string strsql = "insert into " + Name;
            return DBHelper.AddDataMethod<T>(strsql, nodel, msg);//返回受影响函数方法
        }
        #endregion
        #region 访问层、非对称MD5加密技术方法
        /// <summary>
        /// 访问层、非对称MD5加密技术方法
        /// </summary>
        /// <param name="Sender"></param>
        /// <returns></returns>
        public static string GetMD5(string Sender)
        {
            return DBHelper.GetMD5(Sender);
        }
        #endregion 
    }
}
