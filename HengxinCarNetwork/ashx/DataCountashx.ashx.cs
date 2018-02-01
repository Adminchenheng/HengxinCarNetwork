using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Model;//引入实体层
using System.BLL;//引入业务层
using System.Runtime.Serialization.Json;

namespace HengxinCarNetwork.ashx
{
    /// <summary>
    /// DataCountashx 的摘要说明
    /// </summary>
    public class DataCountashx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //这是一个数据统计一般处理程序
            string paramter = context.Request["Paramter"];
            int record = Convert.ToInt32(context.Request["record"]);
            if (record != 0)
                Getarray(paramter, context);
            else
            {
                int count = Bll.GetDataCount<CarInfo>(paramter);
                context.Response.Write(count);
            }
        }
        public static void Getarray(string paramter, HttpContext context)
        {
            int count = Bll.GetDataCount<CarInfo>(paramter);
            float num =(float) count / 12;
            int num2 = count / 12;
            if (num > num2)
                num2++;
            int[] array = new int[num2];
            int sum = 1;
            for (int i = 0; i < num2; i++)
                array[i] = sum++;
            DataContractJsonSerializer Json = new DataContractJsonSerializer(array.GetType());
            Json.WriteObject(context.Response.OutputStream, array);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}