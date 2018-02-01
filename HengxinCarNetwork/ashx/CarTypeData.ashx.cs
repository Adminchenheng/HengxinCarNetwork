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
    /// CarTypeData 的摘要说明
    /// </summary>
    public class CarTypeData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int rocord =Convert.ToInt32(context.Request["record"]);
            string CarType = context.Request["CarType"];
            if (rocord != 0 && CarType == "Brand")
            {
                List<CarBrand> modellist = Bll.GetTopDataMethod<CarBrand>(rocord);
                foreach (CarBrand item in modellist)
                {
                    if (item.BrandName.Count() >= 3)
                        item.BrandName = item.BrandName.Substring(2, 2);
                }
                GetModellist<CarBrand>(modellist, context);
            }
            else if (rocord != 0 && CarType == "Money")
                GetModellist(Bll.GetTopDataMethod<CarMoney>(rocord), context);
            else if (rocord != 0 && CarType == "Body")
                GetModellist(Bll.GetTopDataMethod<CarBody>(rocord), context);
            else if (rocord == 0 && CarType == "Brand")
                GetModellist<CarBrand>(Bll.GetDataMethod<CarBrand>(), context);
            else if (rocord == 0 && CarType == "Money")
                GetModellist<CarMoney>(Bll.GetDataMethod<CarMoney>(), context);
            else if (rocord == 0 && CarType == "Body")
                GetModellist<CarBody>(Bll.GetDataMethod<CarBody>(), context);
        }
        public static void GetModellist<T>(List<T>List,HttpContext context)
        {
            DataContractJsonSerializer Json = new DataContractJsonSerializer(List.GetType());
            Json.WriteObject(context.Response.OutputStream, List);
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