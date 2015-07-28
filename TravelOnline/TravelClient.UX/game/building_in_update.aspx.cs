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
    public partial class game_building_in_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPage();
            String field_id = Session["field_id"].ToString();
            String user_id = Session["user_id"].ToString();
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            if (Session["field_id"] != null && Session["user_id"] != null)
            {
                field_id = Session["field_id"].ToString().Trim();
                user_id = Session["user_id"].ToString().Trim();
                String selectSql = "select type_in_building,eof_dt from player_country where player_id='" + user_id + "'";
                DataTable dt = dbo.SelectToDataTable(selectSql);
                DateTime dTime = Convert.ToDateTime(dt.Rows[0]["eof_dt"].ToString());
                TimeSpan span = dTime - DateTime.Now;
                Session["eof_dt"] = Convert.ToInt32(span.TotalSeconds);
                if (span.TotalSeconds < 0)
                {
                    Response.Redirect("dealAccomplish.aspx?type=2");
                }
            }
        }
        private void loadPage()
        {
            if (!this.IsPostBack)
            {
                string sql1 = "";
                string nextlevel = "";
                string level = "";
                string sql = "";
                string type_in_building = "";
                string former_level = "";
                if (Request.QueryString["type_in_building"] != null && Request.QueryString["formerlevel"] != null)
                {
                    type_in_building = Request.QueryString["type_in_building"].ToString().Trim();
                    former_level = Request.QueryString["formerlevel"].ToString().Trim();
                    level = former_level;
                    nextlevel = ((char)(Char.Parse(level) + 1)).ToString();
                    if (type_in_building == "1")
                    {
                        //是研发所的升级状态显示
                        lbcurrenttitle.Text = "<font size=2px>当前研发时间</font>";
                        lbnexttitle.Text = "<font size=2px>下一级研发时间</font>";
                        sql = "select building_description,building_name,develop_time from building_ability,building_description where building_ability.building_id=building_description.building_id and building_description.building_id='" + type_in_building + "' and building_ability.building_level='" + level + "'";
                        sql1 = "select develop_time from building_ability where building_id='" + type_in_building + "' and building_level='" + nextlevel + "'";
                        DataTable dt1 = selectToTable(sql1);
                        DataTable dt = selectToTable(sql);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lbcurrentability.Text = "<font size=2px>" + dt.Rows[0][2].ToString().Trim() + "分钟</font>";
                            lbnextability.Text = "";
                            lbbuildingtype.Text = "<font size=2px>" + dt.Rows[0][1].ToString().Trim() + "</font>";
                            lbdescription.Text = "<font size=2px>" + dt.Rows[0][0].ToString().Trim() + "</font>";
                        }
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            lbnextability.Text = "<font size=2px>" + dt1.Rows[0][0].ToString().Trim() + "分钟</font>";
                        }
                    }
                    else if (type_in_building == "2")
                    {
                        //是仓库的升级状态
                        lbcurrenttitle.Text = "<font size=2px>当前的存储容量</font>";
                        lbnexttitle.Text = "<font size=2px>下一级的存储容量</font>";
                        lbcurrentwoodtitle.Visible = true;
                        lbcurrentability1.Visible = true;
                        lbnextwoodtitle.Visible = true;
                        lbnextability1.Visible = true;
                        lbcurrentstonetitle.Visible = true;
                        lbnextstonetitle.Visible = true;
                        sql1 = "select stored_wood_count,stored_stone_count from building_ability where building_id='" + type_in_building + "' and building_level='" + nextlevel + "'";
                        sql = "select building_description,building_name,stored_wood_count,stored_stone_count from building_ability,building_description where building_ability.building_id=building_description.building_id and building_description.building_id='" + type_in_building + "' and building_ability.building_level='" + level + "'";
                        DataTable dt = selectToTable(sql);
                        DataTable dt1 = selectToTable(sql1);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lbbuildingtype.Text = "<font size=2px>" + dt.Rows[0][1].ToString().Trim() + "</font>";
                            lbdescription.Text = "<font size=2px>" + dt.Rows[0][0].ToString().Trim() + "</font>";
                            lbcurrentability.Text = "<font size=2px>" + dt.Rows[0][2].ToString().Trim() + "</font>";
                            lbcurrentability1.Text = "<font size=2px>" + dt.Rows[0][3].ToString().Trim() + "</font>";
                        }
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            lbnextability.Text = "<font size=2px>" + dt1.Rows[0][0].ToString().Trim() + "</font>";
                            lbnextability1.Text = "<font size=2px>" + dt1.Rows[0][1].ToString().Trim() + "</font>";
                        }
                    }
                    else if (type_in_building == "3")
                    {
                        int ability1 = 0;
                        int ability2 = 0;
                        //是工厂的升级状态
                        sql1 = "select manufacture_time from building_ability where building_id='" + type_in_building + "' and building_level='" + nextlevel + "'";
                        DataTable dt1 = selectToTable(sql1);
                        lbcurrenttitle.Text = "<font size=2px>当前生产时间</font>";
                        lbnexttitle.Text = "<font size=2px>下一级生产时间</font>";
                        sql = "select building_description,building_name,manufacture_time from building_ability,building_description where building_ability.building_id=building_description.building_id and building_description.building_id='" + type_in_building + "' and building_ability.building_level='" + level + "'";
                        DataTable dt = selectToTable(sql);
                        if (dt != null && dt.Rows.Count > 0 && dt1 != null && dt1.Rows.Count > 0)
                        {
                            if (Session["user_id"] != null)
                            {
                                string racename = "";
                                string id = Session["user_id"].ToString().Trim();
                                racename = getPlayerRace(id);
                                //判断用户的种族，如果是1或者4的话，用户的生产能力就会比其他的种族强

                                if (racename == "4")
                                {
                                    ability1 = (int)(Int32.Parse(dt.Rows[0][2].ToString().Trim()) * 0.8);
                                    ability2 = (int)(Int32.Parse(dt1.Rows[0][0].ToString().Trim()) * 0.8);
                                }
                                else
                                {
                                    ability1 = (int)(Int32.Parse(dt.Rows[0][2].ToString().Trim()));
                                    ability2 = (int)(Int32.Parse(dt1.Rows[0][0].ToString().Trim()));
                                }
                            }
                            lbcurrentability.Text = "<font size=2px>" + ability1.ToString() + "分</font>";
                            lbnextability.Text = "";
                            lbbuildingtype.Text = "<font size=2px>" + dt.Rows[0][1].ToString().Trim() + "</font>";
                            lbdescription.Text = "<font size=2px>" + dt.Rows[0][0].ToString().Trim() + "</font>";
                            lbnextability.Text = "<font size=2px>" + ability2.ToString() + "分</font>";
                        }
                    }
                    else
                    {
                        //是市场的升级状态
                        sql1 = "select sale_count_top from building_ability where building_id='" + type_in_building + "' and building_level='" + nextlevel + "'";
                        DataTable dt1 = selectToTable(sql1);
                        lbcurrenttitle.Text = "<font size=2px>当前销售上限</font>";
                        lbnexttitle.Text = "<font size=2px>下一级销售上限</font>";
                        sql = "select building_description,building_name,sale_count_top from building_ability,building_description where building_ability.building_id=building_description.building_id and building_description.building_id='" + type_in_building + "' and building_ability.building_level='" + level + "'";
                        DataTable dt = selectToTable(sql);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lbcurrentability.Text = "<font size=2px>" + dt.Rows[0][2].ToString().Trim() + "</font>";
                            lbnextability.Text = "";
                            lbbuildingtype.Text = "<font size=2px>" + dt.Rows[0][1].ToString().Trim() + "</font>";
                            lbdescription.Text = "<font size=2px>" + dt.Rows[0][0].ToString().Trim() + "</font>";
                        }
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            lbnextability.Text = "<font size=2px>" + dt1.Rows[0][0].ToString().Trim() + "</font>";
                        }
                    }
                }
                if (Request.QueryString["news"] != null)
                {
                    Response.Write("<script language='javascript'>window.parent.location.reload();</script>");
                }
            }
        }
        /// <summary>
        /// 得到用户的种族
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        private string getPlayerRace(string user_id)
        {
            string race = "";
            string sql = "select player_race from player_country where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                race = dt.Rows[0][0].ToString().Trim();
                return race;
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// 操作数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DataTable selectToTable(string sql)
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
}