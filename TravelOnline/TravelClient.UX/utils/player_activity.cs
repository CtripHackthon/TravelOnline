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
/// player_activity 的摘要说明
/// </summary>
namespace TravelClient.UX.utils
{
    public class player_activity
    {
        public player_activity()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 此方法用来判断用户选择的是什么地形
        /// </summary>
        /// <param name="conutry_x">村庄横坐标</param>
        /// <param name="country_y">村庄纵坐标</param>
        /// <returns>0，空地 1，村庄 2，森林 3，矿山 4，宝洞</returns>
        public static string getFieldType(int country_x, int country_y)
        {
            string map_field_type = "";
            DataTable dt = null;
            string sql = "select map_field_type from map where country_x='" + country_x + "' and country_y='" + country_y + "'";
            dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                map_field_type = dt.Rows[0][0].ToString().Trim();
            }
            return
                map_field_type;
        }
        /// <summary>
        /// 处理转向问题
        /// </summary>
        /// <param name="country_x">用户村庄的横坐标</param>
        /// <param name="country_y">用户村庄的纵坐标</param>
        /// <param name="user_id">用户的user_id,是从session中得到的</param>
        public static void requestProcess(int country_x, int country_y, string user_id)
        {
            //比较用户的user_id 和该处村庄的user_id是不是同一个，如果是同一个删除所有的出行记录,否则不删除
            bool same = true;
            same = sameUser(user_id, country_x, country_y);
            if (same)
            {
                //是从自己的村庄回来的这时要清空数据库

                deleteRecord(user_id);

            }
            else
            {
                //不是从自己村庄回来的这时要记录出行记录
                //判断当前用户点击的是什么地形
            }
        }
        /// <summary>
        /// 方法将本次浏览的村庄信息信息得到
        /// </summary>
        /// <param name="country_x"></param>
        /// <param name="country_y"></param>
        /// <returns></returns>
        public static string fromCountryMessage(int country_x, int country_y)
        {
            string user_id = "";
            string sql = "select player_id from player_country where country_x='" + country_x + "' and country_y='" + country_y + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                user_id = dt.Rows[0][0].ToString().Trim();
            }
            return user_id;
        }
        /// <summary>
        /// 方法清空数据库的出行记录
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static bool deleteRecord(string user_id)
        {
            bool result = false;
            string sql = "delete from activity_record where player_id='" + user_id + "'";
            int i = updateDataBase(sql);
            if (i > 0)
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
        /// 方法用来判断道歉的这个用户是从那里出来的。
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="country_x"></param>
        /// <param name="country_y"></param>
        /// <returns></returns>
        public static bool sameUser(string user_id, int country_x, int country_y)
        {
            string player_id = "";
            bool result = true;
            string sql = "select player_id from player_country where country_x='" + country_x + "' and country_y='" + country_y + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                player_id = dt.Rows[0][0].ToString().Trim();
                if (player_id == user_id)
                {
                    //是同一个用户
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
        /// 方法用来算出本次获得资源的机会
        /// </summary>
        /// <returns>true 能获得 false 不能获得</returns>
        public static bool getRandomRate()
        {
            bool result = false;
            int i = 0;
            Random rnd = new Random(unchecked((int)(DateTime.Now.Ticks)));
            i = rnd.Next(0, 5);
            if (i == 0)
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
        /// 方法用来获得玩家的最高级别建筑
        /// </summary>
        /// <param name="player_id">用户id</param>
        /// <returns>玩家的最高级建筑</returns>
        public static string getPlayerTopLevel(string player_id)
        {
            char max = 'a';
            string all_level = "";
            string sql = "select field_level from player_country where player_id='" + player_id + "'";
            //获得所有建筑的级别
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                all_level = dt.Rows[0][0].ToString().Trim();
            }
            for (int i = 0; i < all_level.Length; i++)
            {
                if (all_level[i] - max > 0)
                {
                    max = all_level[i];
                }
            }
            return max.ToString();

        }
        /// <summary>
        /// 获得玩家本次进入矿场、森林所获得的矿石和木头的量
        /// </summary>
        /// <param name="level">玩家建筑的最高级</param>
        /// <returns></returns>
        public static int getResourceAquired(string level)
        {
            Random rnd = new Random();
            int resouce_count = 0;
            switch (level)
            {
                case "a":
                    {
                        //一级
                        resouce_count = rnd.Next(1, 11);
                        break;
                    }
                case "b":
                    {
                        //二级 
                        resouce_count = rnd.Next(1, 11);
                        break;
                    }
                case "c":
                    {
                        resouce_count = rnd.Next(10, 14);
                        break;
                    }
                case "d":
                    {
                        resouce_count = rnd.Next(13, 21);
                        break;
                    }
                case "e":
                    {
                        resouce_count = rnd.Next(20, 33);
                        break;
                    }
                case "f":
                    {
                        resouce_count = rnd.Next(32, 54);
                        break;
                    }
                case "g":
                    {
                        resouce_count = rnd.Next(53, 92);
                        break;
                    }
                case "h":
                    {
                        resouce_count = rnd.Next(91, 161);
                        break;
                    }
                case "i":
                    {
                        resouce_count = rnd.Next(160, 285);
                        break;
                    }
                default:
                    {
                        resouce_count = rnd.Next(284, 513);
                        break;
                    }
            }
            return resouce_count;
        }
        /// <summary>
        /// 方法用来判断目前玩家的存储上限
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns>玩家的木头上限和玩家的石头上限</returns>
        public static int[] getMaxStorage(string user_id)
        {
            int maxwood = 0;
            int maxstone = 0;
            int[] storage = { 0, 1 };
            int wood_sum = 0;
            int stone_sum = 0;
            string field_type = "";
            string field_level = "";
            string store_level = "";
            string sql2 = "";
            string sql1 = "select field_type,field_level from player_country where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql1);
            if (dt != null && dt.Rows.Count > 0)
            {
                field_level = dt.Rows[0][1].ToString().Trim();
                field_type = dt.Rows[0][0].ToString().Trim();
                //得到玩家的仓库
                for (int i = 0; i < field_type.Length; i++)
                {
                    //如果是仓库
                    if (field_type[i] == '2')
                    {
                        //判断仓库的等级
                        store_level = field_level[i].ToString().Trim();
                        sql2 = "select stored_wood_count,stored_stone_count from building_ability where building_id=2 and building_level='" + store_level + "'";
                        DataTable woodstonedt = selectToTable(sql2);
                        if (woodstonedt != null && woodstonedt.Rows.Count > 0)
                        {
                            maxwood = Int32.Parse(woodstonedt.Rows[0][0].ToString().Trim());
                            maxstone = Int32.Parse(woodstonedt.Rows[0][1].ToString().Trim());
                            wood_sum += maxwood;
                            stone_sum += maxstone;
                        }
                    }
                }
                storage[0] = wood_sum;
                storage[1] = stone_sum;
                return storage;
            }
            else
            {
                return storage;
            }
        }
        /// <summary>
        /// 将玩家本次所获取的资源数填入数据库
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="wood_resource">玩家本次所获得的木头数</param>
        /// <param name="stone_resource">玩家本次所获得的石材数</param>
        /// <returns></returns>
        public static bool writeResourceToDb(string user_id, int wood_resource, int stone_resource)
        {
            //木头、石块上限
            int max_wood_sotorage = 0;
            int max_stone_storage = 0;
            string sql1 = "";
            string sql2 = "";
            int current_wood = 0;
            int current_stone = 0;
            int final_wood = 0;
            int final_stone = 0;
            int result = 0;
            DataTable dt1 = null;
            int[] storage = { 0, 0 };//实际的上限
            storage = getMaxStorage(user_id);
            max_wood_sotorage = storage[0];
            max_stone_storage = storage[1];
            sql1 = "select wood_count,stone_count from player_resource where player_id='" + user_id + "'";
            dt1 = selectToTable(sql1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                current_wood = Int32.Parse(dt1.Rows[0][0].ToString().Trim());
                current_stone = Int32.Parse(dt1.Rows[0][1].ToString().Trim());
                final_wood = current_wood + wood_resource;
                final_stone = current_stone + stone_resource;
                if (final_wood >= max_wood_sotorage && final_stone >= max_stone_storage)
                {
                    sql2 = "update player_resource set wood_count='" + max_wood_sotorage + "',stone_count='" + max_stone_storage + "' where player_id='" + user_id + "'";
                }
                else if (final_wood >= max_wood_sotorage && final_stone <= max_stone_storage)
                {
                    sql2 = "update player_resource set wood_count='" + max_wood_sotorage + "',stone_count='" + final_stone + "' where player_id='" + user_id + "'";
                }
                else if (final_wood <= max_wood_sotorage && final_stone <= max_stone_storage)
                {
                    sql2 = "update player_resource set wood_count='" + final_wood + "',stone_count='" + final_stone + "' where player_id='" + user_id + "'";
                }
                else
                {
                    sql2 = "update player_resource set wood_count='" + final_wood + "',stone_count='" + max_stone_storage + "' where player_id='" + user_id + "'";
                }
                result = updateDataBase(sql2);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                sql2 = "insert into player_resource(player_id,wood_count,stone_count) values('" + user_id + "','" + wood_resource + "','" + stone_resource + "')";
                int i = updateDataBase(sql2);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 获取玩家进入蔵宝洞后获得的字母
        /// </summary>
        /// <returns>本次获得字母</returns>
        public static string getLetterAquired()
        {
            string[] array = { "e", "u", "r", "l", "o", "h", "n", "t", "p", "s", "a", "i", "m" };
            string letter = "";
            int i = 0;
            Random rnd = new Random(~unchecked((int)(DateTime.Now.Ticks)));
            i = rnd.Next(0, 13);
            letter = array[i];
            return letter;
        }
        /// <summary>
        /// 将玩家所获得的字母填入表中
        /// </summary>
        /// <param name="letter">本次获得的字母</param>
        /// <param name="user_id"></param>
        /// <returns>写入口袋字母是不是是成功</returns>
        public static bool writeLetterToDb(string letter, string user_id)
        {
            bool user_exist = true;
            string sql1 = "";
            string sql2 = "";
            int result = 0;
            DataTable dt = null;
            string letter_collected = "";
            user_exist = userExsistInResource(user_id);
            if (user_exist)
            {
                sql1 = "select letter_collected from player_resource where player_id='" + user_id + "'";
                dt = selectToTable(sql1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    letter_collected = dt.Rows[0][0].ToString().Trim();
                }
            }
            else
            {
                sql1 = "insert into player_resource(player_id) values('" + user_id + "')";
                int i = updateDataBase(sql1);
            }
            sql2 = "UPDATE player_resource SET letter_collected ={ fn CONCAT('" + letter_collected + "', '" + letter + "')} WHERE (player_id = '" + user_id + "')";
            result = updateDataBase(sql2);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool userExsistInResource(string user_id)
        {
            string sql = "select player_id from player_resource where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql);
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
        /// 将玩家的拜访记录写进出行日志表中
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <param name="content">行动日志名称</param>
        public static bool visitActivityWrite(string user_id, string content)
        {
            string curent_content = "";
            string sql1 = "";
            string sql2 = "";
            int result = 0;
            DataTable dt = null;
            bool user_exsist = true;
            user_exsist = userExsist(user_id);
            if (user_exsist)
            {
                sql1 = "select content from activity_record where player_id='" + user_id + "'";
                dt = selectToTable(sql1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    curent_content = dt.Rows[0][0].ToString().Trim();
                }
            }
            else
            {
                sql1 = "insert into activity_record(player_id) values('" + user_id + "')";
                int i = updateDataBase(sql1);
            }
            sql2 = "UPDATE activity_record SET content ={ fn CONCAT('" + content + "</br>', '" + curent_content + "')} WHERE (player_id = '" + user_id + "')";
            result = updateDataBase(sql2);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断用户是否已经在出行表中有数据
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static bool userExsist(string user_id)
        {
            string sql = "select player_id from activity_record where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql);
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
        /// 将玩家的行动日志取出显示在界面上
        /// </summary>
        /// <param name="user_id">用户名</param>
        /// <returns></returns>
        public static DataTable getActivityRecord(string user_id)
        {
            string sql = "select content from activity_record where player_id='" + user_id + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 方法用来查询数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable selectToTable(string sql)
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
        /// <summary>
        /// 放发用来更新数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int updateDataBase(string sql)
        {
            int i = 0;
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            i = dbo.UpdateDataBase(sql);
            dbo.CloseConnection();
            return i;
        }
    }
}
