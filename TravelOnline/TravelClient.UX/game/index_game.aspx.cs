using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace TravelClient.UX.game
{
    public partial class game_index_game : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckInfo();
        }

        //游戏前进行用户登录和游戏领地已申领的检测
        private void CheckInfo()
        {
            if (Session["user_id"] == null)
            {
                Session["preAdd"] = ("~/game/index_game.aspx");
                //请先登录提示
                Response.Redirect("../Account/Login.aspx");
            }
            else if (!CheckSpaceForUserBeforeApplication())
            {
                lrInfo.Text = "对不起，游戏地图用户已满";
            }
            else if (!ValidApllication(Session["user_id"].ToString().Trim()))
            {
                Response.Redirect("game_country.aspx");
            }
            else
            {
                Response.Redirect("race_select.aspx");
            }
        }

        //查看游戏地图中是否还有空间以容纳用户
        private bool CheckSpaceForUserBeforeApplication()
        {
            bool re = false;
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select count(*) counts from map where map_field_type='0'";
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["counts"].ToString().Trim() == "0")
                {
                    re = false;
                }
                else
                {
                    re = true;
                }
            }
            return re;
        }

        //检查是否表中已经存在此用户的游戏信息记录
        private bool ValidApllication(string user_id)
        {
            bool re = false;
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select count(*) counts from player_country where player_id='" + user_id + "'";
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["counts"].ToString().Trim() == "1")
                {
                    re = false;
                }
                else
                {
                    re = true;
                }
            }
            return re;
        }

    }
}