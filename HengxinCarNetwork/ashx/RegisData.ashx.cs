using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.BLL;
using System.Model;
using System.Runtime.Serialization.Json;

namespace HengxinCarNetwork.ashx
{
    /// <summary>
    /// RegisData 的摘要说明
    /// </summary>
    public class RegisData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string UserName = context.Request["UserName"];//获取用户名请求
            string Pwd = context.Request["Pwd"];//获取密码请求
            string Phone = context.Request["Phone"];//获取手机号请求
            string Entity = context.Request["Entity"];//获取身份证请求
            string Paramter = "CardID='" + Entity + "'";//定义参数条件
            if (Bll.GetDataMethod<User>(Paramter).Count() > 0)//判断是否有此数据
                context.Response.Write("此身份证已注册!");
            else
            {
                User user = new User();
                user.UserID = Bll.GetCreateKey<User>("User");
                user.UserName = UserName;
                user.UserPwd =Bll.GetMD5(Pwd);
                user.UserTime = DateTime.Now.ToLocalTime();
                user.UserPhone =Phone;
                user.CardID = Entity;
                string[]array= TableAttribute.GetScreen<User>(user);//筛选数据
                if (Bll.AddDataMethod<User>(user, array) > 0)//判断添加返回受影响行数
                    context.Response.Write("注册成功!");
                else
                    context.Response.Write("注册失败!");
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