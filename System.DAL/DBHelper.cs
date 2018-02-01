using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Model;//实体层命名空间
using System.Configuration;//连接字符串对象命名空间
using System.Data;//数据集命名空间
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;

namespace System.DAL
{
    public class DBHelper
    {
        //打开数据库的连接字符串
        static string Connstr = ConfigurationManager.ConnectionStrings["Sqlconn"].ConnectionString;
        public static SqlConnection Conn//定义静态共有连接对象属性
        {
            get
            {
                //动态生成连接对象
                SqlConnection conn = new SqlConnection(Connstr);
                conn.Open();
                if(conn.State==ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                }
                return conn;
            }
        }
        #region 通过SqlDataReader对象读取数据方法
        /// <summary>
        /// 通过SqlDataReader对象读取数据方法
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string strsql, params SqlParameter[] p)
        {
                SqlDataReader dr = null;
                try
                {
                    SqlCommand cmd = new SqlCommand(strsql, Conn);
                    cmd.Parameters.AddRange(p);
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception e)
                {
                    throw;
                }
                return dr;
            
        }
        public static SqlDataReader ExecuteReaderProduce(string produceName, params SqlParameter[] p)
        {
            SqlDataReader dr = null;
            try
            {
                SqlCommand cmd = new SqlCommand(produceName, Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(p);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw;
            }
            return dr;

        }
        #endregion
        #region 通过Int类型返回受影响行数方法
        /// <summary>
        /// 通过Int类型返回受影响行数方法
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string strsql, params SqlParameter[] p)
        {
            int count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(strsql, Conn);
                cmd.Parameters.AddRange(p);
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return -1;
            }
            return count;
        }
        public static DataSet ExecNonQueryProcedure(string productName,SqlParameter[]p)
        {
                DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(productName, Conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddRange(p);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        #endregion
        #region 通过Object对象读取首行首列数据方法
        /// <summary>
        /// 通过Object对象读取首行首列数据方法
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string strsql,params SqlParameter[]p)
        {
            object obj = null;
            try
            {
                SqlCommand cmd = new SqlCommand(strsql, Conn);
                cmd.Parameters.AddRange(p);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
            return obj;
        }
        #endregion
        #region 通过DataSet执行Select语句
        /// <summary>
        /// 执行Select语句
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string strsql)
        {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(strsql, Conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception e)
                {

                    string s = e.Message;
                    return null;
                }
            
        }
        #endregion
        #region 筛选数据读取方法
        /// <summary>
        /// 筛选数据读取方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodel"></param>
        /// <param name="strsql"></param>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static List<T>GetPertend<T>(SqlDataReader dr,params string[]array)where T:new()
        {
            List<T> modellist = new List<T>();
            while (dr.Read())
            {
                T nodel = new T();
                foreach (PropertyInfo item in typeof(T).GetProperties())
                {
                    int count = GetSelected(item.Name, array);//对象筛选结果
                    if (count >= 1)
                        continue;
                  if(dr[item.Name]!=DBNull.Value)//判断指定属性值不等于空
                        item.SetValue(nodel,dr[item.Name]);//给空对象赋值
                }
                modellist.Add(nodel);//将自定义对象添加到空集合
            }
            dr.Close();
            return modellist;
        }
        /// <summary>
        /// 存储过程数据封装方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="produceName"></param>
        /// <param name="p"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T> GetPertendProc<T>(string produceName,SqlParameter[]p, params string[] array) where T : new()
        {
            List<T> modellist = new List<T>();
            SqlDataReader dr = ExecuteReaderProduce(produceName, p);
            while (dr.Read())
            {
                T nodel = new T();
                foreach (PropertyInfo item in typeof(T).GetProperties())
                {
                    int count = GetSelected(item.Name, array);//对象筛选结果
                    if (count >= 1)
                        continue;
                    if (dr[item.Name] != DBNull.Value)//判断指定属性值不等于空
                        item.SetValue(nodel, dr[item.Name]);//给空对象赋值
                }
                modellist.Add(nodel);//将自定义对象添加到空集合
            }
            dr.Close();
            return modellist;
        }
        /// <summary>
        /// 通过DataSet对象赛选读取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<T> GetDataScreen<T>(DataSet ds, params string[] array) where T : new()
        {
            List<T> modellist = new List<T>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                T nodel = new T();//实例化对象
                foreach(PropertyInfo item in typeof(T).GetProperties())
                {
                    item.SetValue(nodel, row[item.Name]);//给对象指定属性赋值
                }
                modellist.Add(nodel);//将封装好的对象添加到集合中
            }
            return modellist;
        }
        #endregion
        #region 筛选数据添加方法
        /// <summary>
        /// 筛选数据添加方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strsql"></param>
        /// <param name="nodel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int AddDataMethod<T>(string strsql,T nodel,params string[] msg)where T:new()
        {
            string coulmn = "(";
            string value = "values(";
            string link = "";
            SqlParameter[] p = new SqlParameter[typeof(T).GetProperties().Length -msg.Length];
            int index = 0;
            foreach (PropertyInfo item in typeof(T).GetProperties())
            {
                int count = GetSelected(item.Name, msg);
                if(count==0)
                {
                    coulmn += link + "[" + item.Name+"]";
                    value += link + "@" + item.Name;
                    object Name = item.GetValue(nodel);
                    p[index++] = new SqlParameter("@" + item.Name,Name);
                    link = ",";
                }
            }
            coulmn += ")";
            value += ")";
            strsql += coulmn + value;
            return ExecuteNonQuery(strsql,p);
        }
        #endregion
        #region 条件赛选方法
        /// <summary>
        /// 条件赛选方法
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int GetSelected(string Name, string[] msg)
        {
            int count = 0;
            if (msg == null)
                return count;
            for (int i = 0; i < msg.Count(); i++)
            {
                if (Name == msg[i].ToString())
                {
                    count++;
                    break;
                }
            }
            return count;
        }
        #endregion
        #region 非对称、MD5加密技术
        /// <summary>
        /// 非对称、MD5加密技术
        /// </summary>
        /// <param name="pwd">加密参数</param>
        /// <returns></returns>
        public static string GetMD5(string pwd)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pwd);
            bytes = md5.ComputeHash(bytes);
            return BitConverter.ToString(bytes);
        }
        #endregion
    }
}
