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
using TravelClient.UX.utils;
namespace TravelClient.UX.game
{
    public partial class game_game_country_others : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null || Session["country_x"] == null || Session["country_y"] == null)
            {
                Session["preAdd"] = ("~/game/index_game.aspx");
                //请先登录提示
                Response.Redirect("../Account/Login.aspx");
            }
            GetPlayerCurrentWoodStoneMoney();
            GetPlayerTotalWoodStone();
            Session["user_id_others"] = GetCountryOwnerId();
        }

        //组装显示玩家的木材数，石头数，金币数
        private string AssembleGetPlayerCurrentWoodStoneMoney()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select wood_count,stone_count,money_count from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //组装特定级别建筑的容纳木材和石头的能力
        private string AssembleGetWoodStoneCount(string building_id, string building_level)
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select stored_wood_count,stored_stone_count from building_ability where building_id=");
            re.Append("'");
            re.Append(building_id);
            re.Append("' and building_level=");
            re.Append("'");
            re.Append(building_level);
            re.Append("'");
            return re.ToString();
        }

        //组装显示玩家的仓库能容纳的木材总数，石头总数
        private string AssembleGetPlayerTotalWoodStone()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select field_type,field_level from player_country where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //玩家进入的是自己的村庄时，显示玩家的木材数，石头数，金币数
        private void GetPlayerCurrentWoodStoneMoney()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetPlayerCurrentWoodStoneMoney();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                lbCurrentWoodCount.Text = dt.Rows[0]["wood_count"].ToString().Trim();
                lbCurrentStoneCount.Text = dt.Rows[0]["stone_count"].ToString().Trim();
                lbCurrentMoneyCount.Text = dt.Rows[0]["money_count"].ToString().Trim();
            }
        }

        //玩家进入的是自己的村庄时，显示玩家的仓库能容纳的木材总数，石头总数
        private void GetPlayerTotalWoodStone()
        {
            int sum_wood = 0;
            int sum_stone = 0;
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetPlayerTotalWoodStone();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows[0]["field_type"].ToString().Trim().Length; i++)
                {
                    if (HLString.StringPickUp(dt.Rows[0]["field_type"].ToString().Trim(), i) == "2")
                    {
                        sqlStr = AssembleGetWoodStoneCount(HLString.StringPickUp(dt.Rows[0]["field_type"].ToString().Trim(), i), HLString.StringPickUp(dt.Rows[0]["field_level"].ToString().Trim(), i));
                        DataTable dt_count = dbo.SelectToDataTable(sqlStr);
                        if (dt_count != null && dt_count.Rows.Count != 0)
                        {
                            sum_wood += Convert.ToInt32(dt_count.Rows[0]["stored_wood_count"].ToString().Trim());
                            sum_stone += Convert.ToInt32(dt_count.Rows[0]["stored_stone_count"].ToString().Trim());
                        }
                    }
                }
            }
            dbo.CloseConnection();
            lbTotalWoodCount.Text = sum_wood.ToString();
            lbTotalStoneCount.Text = sum_stone.ToString();
        }

        //得到村庄属主的id
        private string GetCountryOwnerId()
        {
            string re = "";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select player_id from player_country where country_x=" + Session["country_x"].ToString().Trim() + " and country_y=" + Session["country_y"].ToString().Trim();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                re = dt.Rows[0]["player_id"].ToString().Trim();
            }
            lbOtherPlayer.Text = re;
            return re;
        }

    }
}