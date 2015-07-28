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
    public partial class long_game_building_station : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string building_id = "";
                string building_level = "";
                if (Request.QueryString["building_id"] != null && Request.QueryString["building_stage"] != null)
                {
                    building_id = Request.QueryString["building_id"].ToString().Trim();
                    building_level = Request.QueryString["building_stage"].ToString().Trim();
                    checkBuildingType(building_id, building_level);
                }
                else
                {
                    Message.Show("你没有选择任何建筑", Response);
                }
            }
        }
        private string getCpuId(string user_id, string field_id)
        {
            string cpu_id = "";
            string sql = "select work_content from building_state where player_id='" + user_id + "' and field_id='" + field_id + "'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                cpu_id = dt.Rows[0][0].ToString().Trim();
                return cpu_id;
            }
            else
            {
                return "";
            }

        }
        /// <summary>
        /// 该方法判断建筑的种类和建筑当前的级别
        /// </summary>
        /// <param name="building_id">建筑的种类，0代表空地、1代表研发所、2代表仓库、3代表工厂、4代表市场</param>
        /// <param name="building_type"></param>
        /// <returns></returns>
        private void checkBuildingType(string building_id, string building_type)
        {
            string cpu_id = "";
            string user_id = "";
            string field_id = "";
            buildinginfo bi = new buildinginfo();
            if (Request.QueryString["flag"] != null)
            {

                string flag = Request.QueryString["flag"].ToString().Trim();
                //是研发所
                if (building_id == "1")
                {

                    //研发所能进行升级或者研发的动作
                    //看是不是有东西在研发如果有研发则显示研发的状态，否则显示研发不升级
                    if (Session["user_id"] != null && Session["field_id"] != null)
                    {
                        user_id = Session["user_id"].ToString().Trim();
                        field_id = Session["field_id"].ToString().Trim();
                        if (bi.checkBuildingState(user_id, field_id) == false)
                        {
                            //又在研发的
                            //得到这款在研发的cpu_id
                            cpu_id = getCpuId(user_id, field_id);
                            Response.Redirect("developroom_working.aspx?cpu_id=" + cpu_id);
                        }
                        else
                        {
                            //没有在研发的
                            Response.Redirect("developroom_update.aspx?building_type=" + building_type + "&flag=" + flag);
                        }
                    }

                }
                //是仓库
                else if (building_id == "2")
                {
                    //仓库能进行升级和存储的动作
                    Response.Redirect("store_update.aspx?building_type=" + building_type + "&flag=" + flag);
                }
                //是工厂
                else if (building_id == "3")
                {
                    //工厂能进行升级和生产的功能
                    //看工厂里有没有东西在生产，如果有在生产则显示生产的状态。
                    if (Session["user_id"] != null && Session["field_id"] != null)
                    {
                        user_id = Session["user_id"].ToString().Trim();
                        field_id = Session["field_id"].ToString().Trim();
                        if (bi.checkBuildingState(user_id, field_id) == false)
                        {
                            //又在生产的
                            Response.Redirect("building_in_manufacture.aspx");

                        }
                        else
                        {
                            Response.Redirect("factory_update.aspx?building_type=" + building_type + "&flag=" + flag);
                        }
                    }

                }
                //是市场
                else
                {
                    //市场能进行升级和销售的作用
                    Response.Redirect("market_update.aspx?building_type=" + building_type + "&flag=" + flag);
                }
            }
            else
            {
                if (building_id == "1")
                {
                    //研发所能进行升级或者研发的动作
                    //判断研发所有没有东西在研发
                    if (Session["user_id"] != null && Session["field_id"] != null)
                    {
                        user_id = Session["user_id"].ToString().Trim();
                        field_id = Session["field_id"].ToString().Trim();
                        if (bi.checkBuildingState(user_id, field_id) == false)
                        {
                            //又在研发的
                            //得到这款在研发的cpu_id
                            cpu_id = getCpuId(user_id, field_id);
                            Response.Redirect("developroom_working.aspx?cpu_id=" + cpu_id);
                        }
                        else
                        {
                            //没有在研发的
                            Response.Redirect("developroom_update.aspx?building_type=" + building_type);
                        }
                    }

                }
                //是仓库
                else if (building_id == "2")
                {
                    //仓库能进行升级和存储的动作
                    Response.Redirect("store_update.aspx?building_type=" + building_type);
                }
                //是工厂
                else if (building_id == "3")
                {
                    //工厂能进行升级和生产的功能
                    //看有没有东西在生产
                    if (Session["user_id"] != null && Session["field_id"] != null)
                    {
                        user_id = Session["user_id"].ToString().Trim();
                        field_id = Session["field_id"].ToString().Trim();
                        if (bi.checkBuildingState(user_id, field_id) == false)
                        {
                            //又在生产的
                            Response.Redirect("building_in_manufacture.aspx");

                        }
                        else
                        {
                            Response.Redirect("factory_update.aspx?building_type=" + building_type);
                        }
                    }

                }
                //是市场
                else
                {
                    //市场能进行升级和销售的作用
                    Response.Redirect("market_update.aspx?building_type=" + building_type);
                }
            }
        }
    }
}