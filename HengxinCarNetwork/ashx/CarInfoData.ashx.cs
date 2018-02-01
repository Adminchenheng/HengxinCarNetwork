using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Model;
using System.BLL;
using System.Runtime.Serialization.Json;
using System.Data.SqlClient;

namespace HengxinCarNetwork.ashx
{
    /// <summary>
    /// CarInfoData 的摘要说明
    /// </summary>
    public class CarInfoData : IHttpHandler {

        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "text/plain";
            int record =Convert.ToInt32(context.Request["record"]);
            int index = Convert.ToInt32(context.Request["index"]);
            int style = Convert.ToInt32(context.Request["Style"]);
            int endIndex = Convert.ToInt32(context.Request["endIndex"]);
            string Paramter = null;
            if (!string.IsNullOrEmpty(context.Request["CarBrandID"]))
                Paramter = "CarBrandID='" + context.Request["CarBrandID"] + "'";
            else 
                Paramter = "TrueFalse='" + style + "'";
            if (record != 0)
                GetDataMethod(record, Paramter, context);
            else if (index != 0)
                GetCarPageMehtod<GetCarPage>(index, endIndex, style, context);
        }
        public static void GetDataMethod(int record,string Paramter, HttpContext context)
        {
            List<GetViewCarInsu> modellist = new List<GetViewCarInsu>();
            if (record != 0 && !string.IsNullOrEmpty(Paramter))
                modellist = Bll.GetTopDataMethod<GetViewCarInsu>(record, Paramter);
            else if (record !=0)
                modellist = Bll.GetTopDataMethod<GetViewCarInsu>(record);
            for (int i = 0; i < modellist.Count(); i++)
            {
                modellist[i].Vendor = modellist[i].Vendor / 10000;
                modellist[i].ReferPrice = modellist[i].ReferPrice / 10000;
                modellist[i].FristSpeeding = modellist[i].FristSpeeding / 10000;
            }
            GetJsonData<GetViewCarInsu>(context, modellist);
        }
        /// <summary>
        /// 调用分页存储过程方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <param name="endindex"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static void GetCarPageMehtod<T>(int index,int endindex,int style, HttpContext context) where T:new()
        {
            SqlParameter[] p = { new SqlParameter("@endIndex",endindex),
                                new SqlParameter("@pageIndex",index),
                                new SqlParameter("@Style",style)};
            List<GetCarPage> Modellist = Bll.GetProcMethod<GetCarPage>(typeof(T).Name, p);
            for (int i = 0; i < Modellist.Count(); i++)
            {
                Modellist[i].Vendor = Modellist[i].Vendor / 10000;
                Modellist[i].ReferPrice = Modellist[i].ReferPrice / 10000;
                Modellist[i].FristSpeeding = Modellist[i].FristSpeeding / 10000;
            }
            GetJsonData<GetCarPage>(context, Modellist);
        }       
        /// <summary>
        /// 数据json格式请求方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="modellist"></param>
        public static void GetJsonData<T>(HttpContext context,List<T>modellist)
        {
            DataContractJsonSerializer Json = new DataContractJsonSerializer(modellist.GetType());
            Json.WriteObject(context.Response.OutputStream, modellist);
        }
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}