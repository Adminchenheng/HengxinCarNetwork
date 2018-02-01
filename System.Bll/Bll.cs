using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DAL;
using System.Data.SqlClient;

namespace System.BLL
{
    public class Bll
    {
        #region 业务层、数据读取方法
        /// <summary>
        /// 业务层、全部数据读取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T>GetDataMethod<T>(params string[]array)where T:new()
        {
            return Dal.GetDataMethod<T>(array);
        }
        /// <summary>
        /// 业务层、条件数据读取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramter"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T>GetDataMethod<T>(string paramter,params string[]array)where T:new()
        {
            return Dal.GetDataMethod<T>(paramter, array);
        }
        #endregion
        #region 业务层、查询前几条数据方法
        /// <summary>
        /// 业务层、查询前几条数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rocord"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T>GetTopDataMethod<T>(int rocord,params string[]array)where T:new()
        {
            return Dal.GetTopDataMethod<T>(rocord, array);
        }
        /// <summary>
        /// 业务层、带条件查询前几条数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rocord"></param>
        /// <param name="paramter"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T> GetTopDataMethod<T>(int rocord,string paramter, params string[] array) where T : new()
        {
            return Dal.GetTopDataMethod<T>(rocord,paramter, array);
        }
        #endregion 
        #region 业务层、调用存储过程方法
        /// <summary>
        /// 业务层、调用存储过程方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ProcName"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<T>GetProcMethod<T>(string ProcName,params SqlParameter[]p)where T:new()
        {
            return Dal.GetProcMetod<T>(ProcName, p);
        }
        #endregion 
        #region 业务层、数据统计方法
        /// <summary>
        /// 业务层、数据统计方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetDataCount<T>() where T:new()
        {
            return Dal.GetDataCount<T>();
        }
        /// <summary>
        /// 业务层、条件数据统计方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public static int GetDataCount<T>(string paramter)where T:new()
        {
            return Dal.GetDataCount<T>(paramter);
        }
        #endregion
        #region 业务层、数据添加方法
        /// <summary>
        /// 业务层、数据添加方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodel"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int AddDataMethod<T>(T nodel,params string[]array)where T:new()
        {
            return Dal.AddDataMethod<T>(nodel, array);
        }
        #endregion
        #region 业务层、创建主键方法
        /// <summary>
        /// 业务层、创建主键方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Prefix"></param>
        /// <returns></returns>
        public static string GetCreateKey<T>(string Prefix) where T : new()
        {
            int count = Dal.GetDataCount<T>();
            string KeyID = Prefix + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + count;
            return KeyID;//返回主键字符串
        }
        #endregion
        #region 业务层、MD5非对称加密方法
        /// <summary>
        /// 业务层、MD5非对称加密方法
        /// </summary>
        /// <param name="Paramter"></param>
        /// <returns></returns>
        public static string GetMD5(string Paramter)
        {
            return Dal.GetMD5(Paramter);
        }
        #endregion 
    }
}
