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
    public partial class game_game_country : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Session["preAdd"] = ("~/game/index_game.aspx");
                //���ȵ�¼��ʾ
                Response.Redirect("../Account/Login.aspx");
            }
            CheckUserValidation();
            SetSessionCountry_x_y();
            GetPlayerCurrentWoodStoneMoney();
            GetPlayerTotalWoodStone();
            CheckDevelopingOver();
            CheckProduceOver();
            //�ڡ���settimeout
            Session["time_span"] = Click.getLatestTime(Session["user_id"].ToString().Trim());

        }

        //��װ��ʾ��ҵ�ľ������ʯͷ���������
        private string AssembleGetPlayerCurrentWoodStoneMoney()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select wood_count,stone_count,money_count from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //��װ�ض�������������ľ�ĺ�ʯͷ������
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

        //��װ��ʾ��ҵĲֿ������ɵ�ľ��������ʯͷ����
        private string AssembleGetPlayerTotalWoodStone()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select field_type,field_level from player_country where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //��ҽ�������Լ��Ĵ�ׯʱ����ʾ��ҵ�ľ������ʯͷ���������
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

        //��ҽ�������Լ��Ĵ�ׯʱ����ʾ��ҵĲֿ������ɵ�ľ��������ʯͷ����
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

        //���ڡ�������Ƿ����з�����
        private void CheckDevelopingOver()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select player_id,description,field_id,eof_dt from building_state where description is null and player_id='" + Session["user_id"].ToString().Trim() + "'";
            DateTime currentDT = DateTime.Now;
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((DateTime)dr["eof_dt"] < currentDT)
                    {
                        Click.accomplishDevelop(dr["field_id"].ToString().Trim(), dr["player_id"].ToString().Trim());
                    }
                }
            }
        }

        //���ڡ�������Ƿ�����������
        private void CheckProduceOver()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select player_id,description,field_id,eof_dt from building_state where description is not null and player_id='" + Session["user_id"].ToString().Trim() + "'";
            DateTime currentDT = DateTime.Now;
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((DateTime)dr["eof_dt"] < currentDT)
                    {
                        Click.accomplishManufacture(dr["field_id"].ToString().Trim(), dr["player_id"].ToString().Trim());
                    }
                }
            }
        }

        //����user_id����SetSessionCountry_x_y
        private void SetSessionCountry_x_y()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select country_x,country_y from player_country where player_id='" + Session["user_id"].ToString().Trim() + "'";
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                Session["country_x"] = dt.Rows[0]["country_x"];
                Session["country_y"] = dt.Rows[0]["country_y"];
            }
        }

        //����Ƿ��Ѵ����뱾��Ϸ�У����player_country
        private void CheckUserValidation()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = "select data_id from player_country where player_id='" + Session["user_id"].ToString().Trim() + "'";
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    //add����ȥ��ȡ��ׯ
                    Response.Redirect("../Account/Login.aspx");
                }
            }
        }

    }
}