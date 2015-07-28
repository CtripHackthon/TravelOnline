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
/// �ַ�������
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
        /// ��ʾ��ʾ��Ϣ�ķ���
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
        /// ҳ��������
        /// </summary>
        /// <param name="response"></param>
        public static void PageReload(HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\">window.location.reload();</script>");
        }
        /// <summary>
        /// ָ��ҳ�������
        /// </summary>
        /// <param name="response"></param>
        public static void AssignPageLoad(string page, HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\">window.location.replace(" + page + ");</script>");
        }
        /// <summary>
        /// �Թ������ַ�����������length�Ľض�,�ضϺ����...
        /// </summary>
        /// <param name="response"></param>
        public static string StringHeadOff(string str, int length)
        {
            return (str.Trim().Length > length) ? (str.Trim().Substring(0, length) + "...") : (str.Trim());
        }
        /// <summary>
        /// �Թ������ַ�����������length�Ľض�
        /// </summary>
        /// <param name="response"></param>
        public static string StringHeadOff2(string str, int length)
        {
            return (str.Trim().Length > length) ? (str.Trim().Substring(0, length)) : (str.Trim());
        }
        /// <summary>
        /// �ַ�������ASCIIֵ�������С���󣬴�д��ĸС��Сд��ĸ
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
            //ֱ��ѡ������
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
        /// ��һ���ϵ��ַ�����ȥ��һ���µ��ַ������ϣ�(ע���µ��ַ����г��ּ��Σ������ϵ��ַ�����ȥ�����Σ�
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
        /// ��һ���ַ�������ȡһ���ַ�,����wantedPosition�Ǵ�0��ʼ����
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
        /// ����ĳ��HTML��tag��innerHTML����
        /// </summary>
        /// <param name="response"></param>
        public static void SetInnerHTMLValue(string id, string value, HttpResponse response)
        {
            response.Write("<script type=\"text/javascript\">document.getElementById('" + id + "').innerHTML='" + value + "';</script>");
        }
        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="response"></param>
        public static String YuEncode(String str)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(str)).Replace("+", "%2B");
        }
        /// <summary>
        /// �ַ�������
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
