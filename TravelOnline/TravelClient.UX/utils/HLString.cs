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
/// 字符串操作
/// </summary>
/// 

namespace TravelClient.UX.utils
{
    public class HLString
    {
        public HLString()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 显示提示消息的方法
        /// </summary>
        /// <param name="response"></param>
        public static void MessageBoxShow(string message, HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\"> alert('" + message + "');</script>");
        }
        public static void WindowClose(HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\"> window.close();</script>");
        }
        public static void OpenerReload(HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\"> window.opener.location.reload();</script>");
        }
        /// <summary>
        /// 页面重载入
        /// </summary>
        /// <param name="response"></param>
        public static void PageReload(HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\">window.location.reload();</script>");
        }
        /// <summary>
        /// 指定页面的载入
        /// </summary>
        /// <param name="response"></param>
        public static void AssignPageLoad(string page, HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\">window.location.replace(" + page + ");</script>");
        }
        /// <summary>
        /// 对过长的字符串进行期望length的截断,截断后加上...
        /// </summary>
        /// <param name="response"></param>
        public static string StringHeadOff(string str, int length)
        {
            return (str.Trim().Length > length) ? (str.Trim().Substring(0, length) + "...") : (str.Trim());
        }
        /// <summary>
        /// 对过长的字符串进行期望length的截断
        /// </summary>
        /// <param name="response"></param>
        public static string StringHeadOff2(string str, int length)
        {
            return (str.Trim().Length > length) ? (str.Trim().Substring(0, length)) : (str.Trim());
        }
        /// <summary>
        /// 字符串（按ASCII值）排序从小到大，大写字母小于小写字母
        /// </summary>
        /// <param name="response"></param>
        public static string SortString(string str)
        {
            int length = str.Length;
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("");
            char[] temp = str.ToCharArray();
            char chartemp;
            int min = 0;
            //直接选择排序
            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (temp[min] > temp[j])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    chartemp = temp[i];
                    temp[i] = temp[min];
                    temp[min] = chartemp;
                }
            }
            for (int i = 0; i < length; i++)
            {
                re.Append(temp[i]);
            }
            return re.ToString().Trim();
        }
        /// <summary>
        /// 从一个老的字符串中去除一个新的字符串集合，(注：新的字符串中出现几次，就在老的字符串中去除几次）
        /// </summary>
        /// <param name="response"></param>
        public static string StringClipping(string oldStr, string newStr)
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("");
            char[] oldCharArray = oldStr.ToCharArray();
            char[] newCharArray = newStr.ToCharArray();
            for (int i = 0; i < newCharArray.Length; i++)
            {
                for (int j = 0; j < oldCharArray.Length; j++)
                {
                    if (newCharArray[i] == oldCharArray[j])
                    {
                        oldCharArray[j] = '0';
                        break;
                    }
                }
            }
            for (int i = 0; i < oldCharArray.Length; i++)
            {
                if (oldCharArray[i] != '0')
                {
                    re.Append(oldCharArray[i]);
                }
            }
            return re.ToString();
        }
        /// <summary>
        /// 从一个字符串中提取一个字符,其中wantedPosition是从0开始记起
        /// </summary>
        /// <param name="response"></param>
        public static string StringPickUp(string str, int wantedPosition)
        {
            string re = "";
            if (wantedPosition < str.Length && wantedPosition >= 0)
            {
                re = str.Substring(wantedPosition, 1);
            }
            return re;
        }
        /// <summary>
        /// 设置某个HTML中tag的innerHTML属性
        /// </summary>
        /// <param name="response"></param>
        public static void SetInnerHTMLValue(string id, string value, HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\">document.getElementById('" + id + "').innerHTML='" + value + "';</script>");
        }
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="response"></param>
        public static String YuEncode(String str)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(str)).Replace("+", "%2B");
        }
        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="response"></param>
        public static String YuDecode(String str)
        {
            return System.Text.Encoding.Default.GetString(Convert.FromBase64String(str.Replace("%2B", "+")));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public static void ParentWindowRefresh(HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\">window.parent.leftFrame.location.reload();</script>");
        }
    }
}
