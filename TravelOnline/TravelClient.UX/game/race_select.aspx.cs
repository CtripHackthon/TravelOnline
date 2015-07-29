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
    public partial class game_RaceSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Session["preAdd"] = ("~/game/index_game.aspx");
                //���ȵ�¼��ʾ
                Response.Redirect("../Account/Login.aspx");
            }
        }

        //�����û���id���û���race����ʼ���û�����Ϸ����
        private void FillUserToGamePart(string user_id, string player_race)
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select data_id,country_x,country_y from map where map_field_type='0'";
            DataTable dt_map = dbo.SelectToDataTable(sqlStr);
            Random rd = new Random();
            int randomRow = 0;
            if (dt_map != null && dt_map.Rows.Count != 0)
            {
                randomRow = rd.Next(0, dt_map.Rows.Count);
                sqlStr = "update map set map_field_type='1',player_id='" + user_id + "' where data_id=" + dt_map.Rows[randomRow]["data_id"].ToString().Trim();
                dbo.UpdateDataBase(sqlStr);
                sqlStr = "insert into player_country(player_id,player_race,country_x,country_y) values('" + user_id + "','" + player_race + "'," + dt_map.Rows[randomRow]["country_x"].ToString().Trim() + "," + dt_map.Rows[randomRow]["country_y"].ToString().Trim() + ")";
                dbo.UpdateDataBase(sqlStr);
                sqlStr = "insert into player_resource(player_id,wood_count,stone_count,money_count) values('" + user_id + "',10,10,50)";
                dbo.UpdateDataBase(sqlStr);
            }
            dbo.CloseConnection();
        }

        //����Ƿ�����Ѿ����ڴ��û�����Ϸ��Ϣ��¼
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

        //�鿴��Ϸ��ͼ���Ƿ��пռ��������û�
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

        //��ʼ���û���Ϸ����
        protected void btGotoGame_Click(object sender, EventArgs e)
        {
            string userRace = "1";
            if (rb1.Checked)
            {
                userRace = "1";
            }
            else if (rb2.Checked)
            {
                userRace = "2";
            }
            else if (rb3.Checked)
            {
                userRace = "3";
            }
            else if (rb4.Checked)
            {
                userRace = "4";
            }
            if (CheckSpaceForUserBeforeApplication() && ValidApllication(Session["user_id"].ToString().Trim()))
            {
                FillUserToGamePart(Session["user_id"].ToString().Trim(), userRace);
                Response.Redirect("game_country.aspx");
            }
            else
            {
                //add������ʾ
            }
        }

    }
}