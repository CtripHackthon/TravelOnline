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
/// 此类是用来判断目前所选的建筑内是否有东西在生产、升级、研发。
/// 如果有的话就不能进行生产、研发等活动
/// </summary>
namespace TravelClient.UX.utils
{
    public class checkbuildingstate
    {
        public checkbuildingstate()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 本方法用来判断当前建筑的状态
        /// </summary>
        /// <param name="palyer_id">玩家的用户名</param>
        /// <param name="field_id">玩家所选的地块号</param>
        /// <returns>true当前建筑内的没有动西在生产、研发</returns>
        public bool checkWorkContent(string palyer_id, string field_id)
        {
            string sql = "select work_content from building_state where player_id='" + palyer_id + "' and field_id='" + field_id + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// 该方法用来判断当前的建筑是否有在升级
        /// </summary>
        /// <param name="player_id">玩家的用户名</param>
        /// <param name="field_id">玩家当前选的这块地号</param>
        /// <returns>true：有在升级的 false: 没有在升级的</returns>
        public bool checkBuildingUpdate(string player_id, string field_id)
        {
            string is_in_building = "";
            string sql = "select is_in_building from player_country where player_id='" + player_id + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                is_in_building = dt.Rows[0][0].ToString();
                if (is_in_building == field_id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        /// <summary>
        /// 查询数据库的代码
        /// </summary>
        /// <param name="sql">传入的sql语句</param>
        /// <returns>dt选出的相应列</returns>
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
