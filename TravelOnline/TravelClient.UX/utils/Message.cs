using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Message 的摘要说明
/// </summary>
namespace TravelClient.UX.utils
{
    public class Message
    {
        public Message()
        {
        }
        //显示提示消息的方法
        public static void Show(string message, HttpResponse response)
        {
            response.Write("<script language='javascript'> alert('" + message + "')</script>");
        }
    }
}