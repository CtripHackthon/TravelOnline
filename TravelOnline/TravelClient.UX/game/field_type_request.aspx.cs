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
    public partial class long_game_field_type_request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            bool exist = false;
            if (Request["field_id"] != null && Session["user_id"] != null)
            {
                Session["field_id"] = Request.QueryString["field_id"].ToString().Trim();
                bool blankfield = false;
                bool field = true;
                bool building = true;
                bool result = true;
                string[] buildinginfo = { };
                string building_string_id = "";
                string building_string_stage = "";
                string field_id = Session["field_id"].ToString().Trim();
                char field_char = Char.Parse(field_id);
                int len = field_char - 'a';
                string building_id = "";
                string building_stage = "";
                string user_id = Session["user_id"].ToString().Trim();
                exist = checkUserId(user_id);
                result = isInBuilding(field_id, user_id);
                if (exist)
                {
                    //有在建或者升级的建筑
                    if (result)
                    {
                        //判断该在建的建筑是不是用户选中的建筑
                        building = isClickingBuilding(field_id, user_id);
                        //如果选的地正好是在建设中的这块地
                        if (building)
                        {
                            //显示建设的状态是什么样的还剩多少时间
                            if (Request.QueryString["news"] != null)
                            {
                                Response.Redirect("building_updated_requset.aspx?field_id=" + field_id);
                            }
                            else
                            {
                                Response.Redirect("building_updated_requset.aspx?field_id=" + field_id);
                            }

                        }
                        //如果不是选中的这块地
                        else
                        {
                            blankfield = isBlankField(field_id, user_id);
                            if (blankfield)
                            {
                                //是空地则提醒玩家这块地上不能在建筑了
                                Response.Redirect("building_rejected.aspx");
                            }
                            else
                            {
                                //不是空地则提醒不能升级只能进行研发或者销售等活动
                                //这说明这块地只可能是有建筑的,判断这块地上建筑的类型和等级并显示给玩家看
                                //看是不是研发所或者是工厂，如果是工厂或者研发所则判断是不是有东西在
                                buildinginfo = getBuildingInfo(field_id, user_id);
                                building_string_id = buildinginfo[0].ToString().Trim();
                                building_string_stage = buildinginfo[1].ToString().Trim();
                                building_id = building_string_id[len].ToString();
                                building_stage = building_string_stage[len].ToString();
                                Response.Redirect("building_updating.aspx?building_id=" + building_id + "&building_stage=" + building_stage + "&flag=updatenotpermited");
                            }
                        }
                    }
                    //没有在建或者升级的建筑了
                    else
                    {
                        //判断选中的这块地是不是是空地
                        field = isBlankField(field_id, user_id);
                        //如果是空地的话
                        if (field)
                        {
                            Response.Redirect("build_welcome.aspx");
                        }
                        //这块地上已经有建筑了
                        else
                        {
                            //判断这块地上建筑的类型和等级
                            buildinginfo = getBuildingInfo(field_id, user_id);
                            //如果建筑信息不为空的话
                            if (buildinginfo.Length > 0)
                            {
                                building_string_id = buildinginfo[0].ToString().Trim();
                                building_string_stage = buildinginfo[1].ToString().Trim();
                                building_id = building_string_id[len].ToString();
                                building_stage = building_string_stage[len].ToString();
                                Response.Redirect("building_updating.aspx?building_id=" + building_id + "&building_stage=" + building_stage);
                            }
                            else
                            {
                                Response.Redirect("..\\login_main.aspx");
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("..\\login_main.aspx");
                }
            }
            else
            {
                //只显示图上的信息不显示建筑或者升级信息
            }
            //}
        }
        /// <summary>
        /// 判断当前的用户是不是已经在注册在游戏中注册过
        /// </summary>
        /// <returns></returns>
        private bool checkUserId(string user_id)
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable("select player_id from player_country where player_id='" + user_id + "'");
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 方法用来判断当前地图上有没有在建造的建筑
        /// </summary>
        /// <param name="fieldname">地块名字</param>
        /// <param name="user_id">用户的用户名</param>
        /// <returns></returns>
        private bool isInBuilding(string fieldname, string user_id)
        {
            bool result = true;
            string is_in_building = "";
            string sql = "select is_in_building from player_country where player_id='" + user_id + "'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                is_in_building = dt.Rows[0]["is_in_building"].ToString().Trim();
                if (is_in_building == "0")
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
                return result;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 本方法用来判断该在建的建筑是不是用户选中的那个
        /// </summary>
        /// <param name="field_id">用户选中的那块地的地号</param>
        /// <returns></returns>
        private bool isClickingBuilding(string field_id, string user_id)
        {
            bool result = true;
            string is_in_building = "";
            string sql = "select is_in_building from player_country where player_id='" + user_id + "'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                is_in_building = dt.Rows[0][0].ToString().Trim();
            }
            else
            {
                Message.Show("数据库连接失败", Response);
            }
            if (is_in_building == field_id)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 该方法判断用户选的这块地是不是是空地
        /// </summary>
        /// <param name="fiel_id"></param>
        /// <returns></returns>
        private bool isBlankField(string field_id, string user_id)
        {
            bool result = true;
            char field = Char.Parse(field_id);
            string field_type = "";
            int i = field - 'a';
            string sql = "select field_type from player_country where player_id='" + user_id + "'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                field_type = dt.Rows[0][0].ToString().Trim();
            }
            else
            {
                Message.Show("数据库连接失败", Response);
            }
            //如果该位置上的建筑类型为0的话证明该处没有建筑
            if (field_type[i] != '0')
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 该方法获取该建筑的信息
        /// </summary>
        /// <param name="fiel_id">用户选中的建筑的名字</param>
        /// <returns></returns>
        private string[] getBuildingInfo(string field_id, string user_id)
        {
            string sql = "select field_level,field_type from player_country where player_id='" + user_id + "'";
            string[] building_info = { "0", "0" };//建筑的类型
            string building_type = "";
            string building_level = "";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                building_level = dt.Rows[0][0].ToString().Trim();
                building_type = dt.Rows[0][1].ToString().Trim();
            }
            else
            {
                Message.Show("数据库连接失败", Response);
            }
            building_info[0] = building_type;
            building_info[1] = building_level;
            return building_info;
        }
    }
}