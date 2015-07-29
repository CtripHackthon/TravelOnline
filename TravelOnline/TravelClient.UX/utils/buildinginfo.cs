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
/// buildinginfo 的摘要说明
/// </summary>
/// 

namespace TravelClient.UX.utils
{
    public class buildinginfo
    {
        public buildinginfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 此方法是用来获取建造建筑所需资源的情况用的
        /// </summary>
        /// <param name="user_id">用户名</param>
        /// <param name="building_level">建筑级别</param>
        /// <param name="building_id">建筑的种类</param>
        /// <returns>返回建筑的信息</returns>
        public int[] GetResourcesNeeded(string user_id, string building_level, string building_id)
        {
            int[] resources = { 0, 0, 0 };
            int wood_needed = 0;
            int stone_needed = 0;
            int time_neede = 0;
            string player_race = "";
            string sql1 = "select player_race from player_country where player_id='" + user_id + "'";
            string sql2 = "select wood_needed,stone_needed,time_needed from building_fees where building_id='" + building_id + "' and building_level='" + building_level + "'";
            DataTable dt1 = selectTableInfo(sql1);
            DataTable dt2 = selectTableInfo(sql2);
            if (dt1 != null && dt1.Rows.Count > 0 && dt2 != null && dt2.Rows.Count > 0)
            {
                player_race = dt1.Rows[0][0].ToString().Trim();
                wood_needed = Int32.Parse(dt2.Rows[0][0].ToString().Trim());
                stone_needed = Int32.Parse(dt2.Rows[0][1].ToString().Trim());
                time_neede = Int32.Parse(dt2.Rows[0][2].ToString().Trim());
            }
            else
            {
                return null;
            }
            if (player_race == "1")
            {
                //是“金脉龙族”的话这里直接不用显示
                resources[0] = wood_needed;
                resources[1] = stone_needed;
                resources[2] = time_neede;
            }
            else if (player_race == "2")
            {
                //是绯艳龙族
                int dwood = (int)Math.Round((wood_needed * 0.75), 0);
                int dstone = (int)Math.Round((stone_needed * 0.75), 0);
                int dtime = (int)Math.Round((time_neede * 0.75), 0);
                resources[0] = dwood;
                resources[1] = dstone;
                resources[2] = dtime;
            }
            else if (player_race == "3")
            {
                //是麒麟龙族
                int dwood = (int)Math.Round((wood_needed * 0.8), 0);
                int dstone = (int)Math.Round((stone_needed * 0.8), 0);
                int dtime = (int)(time_neede * 0.8);
                resources[0] = dwood;
                resources[1] = dstone;
                resources[2] = dtime;
            }
            else
            {
                //是青凤龙族
                resources[0] = wood_needed;
                resources[1] = stone_needed;
                resources[2] = time_neede;
            }
            return resources;
        }
        public int[] getPlayerResources(string user_id)
        {
            return null;
        }
        public bool checkBuildingState(string user_id, string field_id)
        {


            string sql = "select work_content from building_state where player_id='" + user_id + "' and field_id='" + field_id + "'";
            DataTable dt = selectTableInfo(sql);
            if (dt.Rows.Count > 0 && dt != null)
            {
                //又在生产或者研发
                return false;
            }
            else
            {
                return true;
            }

        }
        private DataTable selectTableInfo(string sql)
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            return dt;
        }

    }
}