using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Model;
using System.BLL;
using System.Runtime.Serialization.Json;

namespace HengxinCarNetwork.ashx
{
    /// <summary>
    /// InsuranceData 的摘要说明
    /// </summary>
    public class InsuranceData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<InsuComplay> Modellist = Bll.GetTopDataMethod<InsuComplay>(6);
            DataContractJsonSerializer Json = new DataContractJsonSerializer(typeof(List<InsuComplay>));
            Json.WriteObject(context.Response.OutputStream, Modellist);
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