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
    /// QueryCarInfoData 的摘要说明
    /// </summary>
    public class QueryCarInfoData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Brand = context.Request["BrandID"];
            string money = context.Request["MoneyID"];
            string Body = context.Request["BodyID"];
            string CarName = context.Request["CarName"];
            string Paramter ="TrueFalse='"+ context.Request["Paramter"]+"'";
            List<GetViewCarInsu> modellist = Bll.GetDataMethod<GetViewCarInsu>(Paramter);//获取所有数据源
            if (!string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(money) && !string.IsNullOrEmpty(Body))
                modellist = (from item in modellist where item.CarBrandID == Brand && item.CarMoneyID == money && item.CarBodyID == Body select item).ToList();
            else if (!string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(money))
                modellist = (from item in modellist where item.CarBrandID == Brand && item.CarMoneyID == money select item).ToList();
            else if (!string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(Body))
                modellist = (from item in modellist where item.CarBrandID == Brand && item.CarBodyID == Body select item).ToList();
            else if (!string.IsNullOrEmpty(money) && !string.IsNullOrEmpty(Body))
                modellist = (from item in modellist where item.CarMoneyID == money && item.CarBodyID == Body select item).ToList();
            else if (!string.IsNullOrEmpty(Brand) || !string.IsNullOrEmpty(money) || !string.IsNullOrEmpty(Body))
                modellist = (from item in modellist where item.CarBrandID == Brand || item.CarMoneyID == money || item.CarBodyID == Body select item).ToList();
            else if (!string.IsNullOrEmpty(CarName) && string.IsNullOrEmpty(Brand) && string.IsNullOrEmpty(money) && string.IsNullOrEmpty(Body))
                modellist = modellist.Where(m => m.CarName.Contains(CarName)).ToList();
            if (modellist != null)
            {
                for (int i = 0; i < modellist.Count(); i++)
                {
                    modellist[i].ReferPrice = modellist[i].ReferPrice / 10000;
                    modellist[i].FristSpeeding = modellist[i].FristSpeeding / 10000;
                }
            }
            GetJsonData<GetViewCarInsu>(modellist, context);
        }
        public static void GetJsonData<T>(List<T>modellist,HttpContext context)
        {            
            DataContractJsonSerializer Json = new DataContractJsonSerializer(modellist.GetType());
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