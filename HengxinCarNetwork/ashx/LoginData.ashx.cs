using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Model;
using System.BLL;
using System.Runtime.Serialization.Json;
using System.Web.SessionState;//引入session命名空间

namespace HengxinCarNetwork.ashx
{
    /// <summary>
    /// LoginData 的摘要说明
    /// </summary>
    public class LoginData : IHttpHandler, IRequiresSessionState//集成Session接口方可读取Session
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Uid = context.Request["Uid"];
            string Pwd = context.Request["Pwd"];
            if (!string.IsNullOrEmpty(Uid) && !string.IsNullOrEmpty(Pwd))
            {
                TableAttribute table = TableAttribute.GetTable<User>();
                string Paramter = table.Phone + "='" + Uid + "'";
                if (Bll.GetDataCount<User>(Paramter) > 0)
                {
                    List<User> Modellist = Bll.GetDataMethod<User>(Paramter);
                    if (Modellist[0].UserPwd != Bll.GetMD5(Pwd))
                        context.Response.Write("密码不正确，请重新输入!");
                    else
                    {
                        string[] array = new string[2];
                        array[0] = Modellist[0].UserPhone.ToString().Substring(0, 3) + "****" + Modellist[0].UserPhone.ToString().Substring(7, 4);
                        array[1] = "登录成功!";
                        context.Session["UserList"] = Modellist;
                        DataContractJsonSerializer Json = new DataContractJsonSerializer(array.GetType());
                        Json.WriteObject(context.Response.OutputStream, array);
                    }
                }
                else
                    context.Response.Write("没有此用户");
            }
            else if(context.Session["UserList"]==null)
                context.Response.Write("个人登录");
            else
            {               
                List<User>Modellist=context.Session["UserList"]as List<User>;
                string Phone = Modellist[0].UserPhone.ToString().Substring(0, 3) + "****" + Modellist[0].UserPhone.ToString().Substring(7, 4);
                context.Response.Write(Phone);               
            }
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