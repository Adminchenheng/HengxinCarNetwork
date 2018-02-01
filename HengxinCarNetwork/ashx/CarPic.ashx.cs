using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Model;
using System.BLL;
using System.Runtime.Serialization.Json;
using System.Web.SessionState;

namespace HengxinCarNetwork.ashx
{
    /// <summary>
    /// CarPic 的摘要说明
    /// </summary>
    public class CarPic : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string rocord = context.Request["rocrod"];
            string path = context.Server.MapPath("~/img/newCarpic");
            List<GetViewCarInsu>modellist= context.Session["CarList"]as List<GetViewCarInsu>;
            string[] files = Directory.GetFiles(path);//返回指定目录的文件名称123546494
            files = files.Where(i=>i.Contains(modellist[0].CarID)).ToArray();
            for (int i = 0; i < files.Count(); i++)
                files[i]= files[i].Substring(files[i].LastIndexOf("\\")+1);//从后往前找到“\”后一位开始截取
            DataContractJsonSerializer Json = new DataContractJsonSerializer(files.GetType());
            Json.WriteObject(context.Response.OutputStream, files);
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