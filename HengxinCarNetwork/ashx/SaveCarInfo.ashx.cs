using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Model;
using System.BLL;
using System.Runtime.Serialization.Json;
using System.Web.SessionState;

namespace HengxinCarNetwork.ashx
{
    /// <summary>
    /// SaveCarInfo 的摘要说明
    /// </summary>
    public class SaveCarInfo : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string CarID = context.Request["CarID"];
            int rocord =Convert.ToInt32(context.Request["rocord"]);
            List<GetViewCarInsu> modellist = new List<GetViewCarInsu>();
            if (!string.IsNullOrEmpty(CarID))
            {
                modellist = Bll.GetDataMethod<GetViewCarInsu>("CarID='" + CarID + "' and TrueFalse=" + rocord);
                for (int i = 0; i < modellist.Count(); i++)
                {
                    modellist[i].FristSpeeding = modellist[i].FristSpeeding / 10000;
                    modellist[i].Vendor = modellist[i].Vendor / 10000;
                }
                context.Session["CarList"] = modellist;
                List<GetViewCarInsu> model = context.Session["CarList"] as List<GetViewCarInsu>;
            }
            else
                modellist = context.Session["CarList"] as List<GetViewCarInsu>;
            DataContractJsonSerializer Json = new DataContractJsonSerializer(typeof(List<GetViewCarInsu>));
            Json.WriteObject(context.Response.OutputStream, modellist);
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