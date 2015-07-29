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
    public partial class long_game_building_in_updating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string formerlevel = "";
            bool result = false;
            string field_id = "";
            string user_id = "";
            string type_in_building = "";
            if (!this.IsPostBack)
            {
                if (Request.QueryString["field_id"] != null && Session["user_id"] != null)
                {
                    field_id = Request.QueryString["field_id"].ToString().Trim();
                    user_id = Session["user_id"].ToString().Trim();
                    //判断这个建筑是在升级中还是在建筑中
                    type_in_building = getBuildingId(user_id);
                    result = checkBuildingType(field_id, user_id);
                    if (result)
                    {
                        //是建设中的
                        if (Request.QueryString["new"] != null)
                        {
                            Response.Redirect("building_in_build.aspx?type_in_building=" + type_in_building + "&new=yes");
                        }
                        else
                        {
                            Response.Redirect("building_in_build.aspx?type_in_building=" + type_in_building);
                        }
                    }
                    else
                    {
                        //是升级中的
                        //得到升级前建筑的级别
                        formerlevel = getBuildingLeve(user_id, field_id);
                        if (Request.QueryString["news"] != null)
                        {
                            //从升级按钮发过来的
                            Response.Redirect("building_in_update.aspx?formerlevel=" + formerlevel + "&type_in_building=" + type_in_building + "&news=yes");
                        }
                        else
                        {
                            //是从点击地图上的坐标发过来的
                            Response.Redirect("building_in_update.aspx?formerlevel=" + formerlevel + "&type_in_building=" + type_in_building);
                        }
                    }
                }
                else
                {
                    Message.Show("您还没有登录", Response);
                }
            }
        }
        /// <summary>
        /// 本方法用来判断当前选中的建筑是在升级还是建筑
        /// </summary>
        /// <param name="field_id">所选中的地块的号</param>
        /// <param name="user_id">玩家的id</param>
        /// <returns>true 当前是在建筑的地块  false 当前是在升级的建筑</returns>
        private bool checkBuildingType(string field_id, string user_id)
        {
            string build_type = "";
            bool result = false;
            int i = Char.Parse(field_id) - 'a';
            string sql = "select field_type from player_country where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                build_type = dt.Rows[0][0].ToString().Trim();
                if (build_type[i] == '0')
                {
                    //是在建设中的
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 用来获取在建设中的地形是什么
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        private string getBuildingId(string user_id)
        {
            string type_in_building = "";
            string sql = "select type_in_building from player_country where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                type_in_building = dt.Rows[0][0].ToString();
            }
            else
            {
                type_in_building = "0";
            }
            return type_in_building;
        }
        /// <summary>
        /// 本方法用来显示在建中建筑的级别
        /// </summary>
        /// <param name="user_id">用户的id</param>
        /// <param name="field_type">选择的空地的id</param>
        /// <returns></returns>
        private string getBuildingLeve(string user_id, string field_id)
        {
            int i = Char.Parse(field_id) - 'a';
            string field_level = "";
            string level = "";
            string sql = "select field_level from player_country where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                field_level = dt.Rows[0][0].ToString().Trim();
                level = field_level[i].ToString();
                return level;
            }
            else
            {
                return null;
            }


        }
        /// <summary>
        /// 本方法用来查询数据库
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