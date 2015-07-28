using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TravelClient.UX.utils;

/// <summary>
/// Summary description for Click
/// </summary>
public class Click
{
    /// <summary>
    /// 建造新的建筑
    /// </summary>
    /// <param name="building_id">新建筑的类型</param>
    /// <param name="field_id">建筑所在地段</param>
    /// <param name="player_id">用户id</param>
    static public String buildingClick(String building_id, String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        DateTime endTime = DateTime.Now;
        Int32 time_needed = getNeededTime(building_id, "a", player_id);
        endTime = endTime.AddMinutes(time_needed);
        if (checkResourceEnough(building_id, "a", player_id) == -1)
            return "原材料不足，不能进行建筑";
        String updateSql = "update player_country set is_in_building='" + field_id + "',type_in_building='" + building_id + "',eof_dt='" + endTime.ToString() + "' where player_id='" + player_id + "'";//将is_in_building字段设为建筑的地段号
        if (dbo.UpdateDataBase(updateSql) != -1)
        {
            reduceResource(building_id, "a", player_id);
        }
        dbo.CloseConnection();
        return "";
    }
    /// <summary>
    /// 建造或升级需要的时间
    /// </summary>
    /// <param name="building_id">建造或升级的类型</param>
    /// <param name="building_level">要建造或升级的级别</param>
    /// <param name="player_id">用户的ID</param>
    /// <returns></returns>
    static private Int32 getNeededTime(String building_id, String building_level, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        Int32 needed_time = 0;
        String selectSql = "select time_needed from building_fees where building_id='" + building_id + "' and building_level='" + building_level + "'";
        DataTable dt = new DataTable();

        dt = dbo.SelectToDataTable(selectSql);
        if (dt != null && dt.Rows.Count > 0)
        {
            needed_time = Convert.ToInt32(dt.Rows[0]["time_needed"]);
        }
        selectSql = "select building_time from player_country,race_info where player_country.player_race=race_info.race_id and player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        if (dt != null && dt.Rows.Count > 0)
        {
            needed_time = Convert.ToInt32(needed_time * Convert.ToSingle(dt.Rows[0]["building_time"]));
        }
        dbo.CloseConnection();
        return needed_time;

    }
    /// <summary>
    /// 将建造或升级消耗的资源去掉
    /// </summary>
    /// <param name="building_id">建造或升级的建筑类型</param>
    /// <param name="building_level">建筑或升级的建筑的级别</param>
    /// <param name="player_id">用户的id</param>
    static public void reduceResource(String building_id, String building_level, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        Int32 wood_needed = 0;
        Int32 stone_needed = 0;

        String selectSql = "select wood_needed,stone_needed from building_fees where building_id='" + building_id + "' and building_level='" + building_level + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        if (dt != null && dt.Rows.Count > 0)
        {
            wood_needed = Convert.ToInt32(dt.Rows[0]["wood_needed"].ToString());
            stone_needed = Convert.ToInt32(dt.Rows[0]["stone_needed"].ToString());
        }
        selectSql = "select building_resource from player_country,race_info where player_country.player_race=race_info.race_id and player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        if (dt != null && dt.Rows.Count > 0)
        {
            Single mulity = Convert.ToSingle(dt.Rows[0]["building_resource"]);
            String updateSql = "update player_resource set wood_count=wood_count-" + Convert.ToInt32(wood_needed * mulity) + ",stone_count=stone_count-" + Convert.ToInt32(stone_needed * mulity) + "where player_id='" + player_id + "'";
            dbo.UpdateDataBase(updateSql);
        }
        dbo.CloseConnection();
    }
    /// <summary>
    /// 升级已有建筑
    /// </summary>
    /// <param name="building_id">需升级的建筑的类型</param>
    /// <param name="field_id">需升级建筑所在地段</param>
    /// <param name="player_id">用户id</param>
    static public String updataing_click(String building_id, String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        DateTime endTime = DateTime.Now;
        String selectSql = "select field_level from player_country where player_id='" + player_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        String totalLevel = dt.Rows[0]["field_level"].ToString();
        Char currentLevel = (Char)(totalLevel[(Int32)field_id[0] - 97] + 1);
        Int32 time_needed = getNeededTime(building_id, currentLevel.ToString(), player_id);
        endTime = endTime.AddMinutes(time_needed);
        if (checkResourceEnough(building_id, currentLevel.ToString(), player_id) == -1)
            return "原料不足，不能升级建筑";
        String updateSql = "update player_country set is_in_building='" + field_id + "',type_in_building='" + building_id + "',eof_dt='" + endTime.ToString() + "' where player_id='" + player_id + "'";//将is_in_building字段设为建筑的地段号
        dbo.UpdateDataBase(updateSql);
        reduceResource(building_id, currentLevel.ToString(), player_id);
        dbo.CloseConnection();
        return "";
    }
    /// <summary>
    /// 检查资源是否充足
    /// </summary>
    /// <param name="building_id">建筑类型</param>
    /// <param name="building_level">升级后建筑级别</param>
    /// <param name="player_id">用户id</param>
    /// <returns>足够返回1，否则返回-1</returns>
    static public Int32 checkResourceEnough(String building_id, String building_level, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select wood_needed,stone_needed from building_fees where building_id='" + building_id + "' and building_level='" + building_level + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 wood_needed = Convert.ToInt32(dt.Rows[0]["wood_needed"].ToString());
        Int32 stone_needed = Convert.ToInt32(dt.Rows[0]["stone_needed"].ToString());
        selectSql = "select wood_count,stone_count from player_resource where player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        Int32 wood_count = Convert.ToInt32(dt.Rows[0]["wood_count"]);
        Int32 stone_count = Convert.ToInt32(dt.Rows[0]["stone_count"]);
        if (wood_needed > wood_count || stone_needed > stone_count)
            return -1;
        return 1;
    }
    /// <summary>
    /// 研发配方
    /// </summary>
    /// <param name="cpu_id">将要研发的配方的id</param>
    /// <param name="field_id">研发所所在地段id</param>
    /// <param name="player_id">用户id</param>
    static public String developCpu(String cpu_id, String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        DateTime endTime = DateTime.Now;
        endTime = endTime.AddMinutes(getDeveTime(field_id, player_id));
        String selectSql = "select develop_expense from cpu_info where cpu_id='" + cpu_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 expense = Convert.ToInt32(dt.Rows[0]["develop_expense"]);
        if (checkMoneyEnough(expense, player_id) == -1)
            return "龙币不足，不能研发配方";
        String updateSql = "update player_resource set money_count=money_count-" + expense + " where player_id='" + player_id + "'";
        if (dbo.UpdateDataBase(updateSql) != -1)
        {
            updateSql = "insert into building_state(player_id,field_id,work_content,eof_dt) values('" + player_id + "','" + field_id + "','" + cpu_id + "','" + endTime + "')";
            dbo.UpdateDataBase(updateSql);
        }
        dbo.CloseConnection();
        return "";
    }
    /// <summary>
    /// 得到研发配方所需要的时间
    /// </summary>
    /// <param name="field_id">地段id</param>
    /// <param name="player_id">用户id</param>
    /// <returns>需要的时间</returns>
    static public int getDeveTime(String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        Char level = getCurrentLevel(field_id, player_id);
        String selectSql = "select develop_time from building_ability where building_id='1' and building_level='" + level + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        dbo.CloseConnection();
        return Convert.ToInt32(dt.Rows[0]["develop_time"]);
    }
    static public Char getCurrentLevel(String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select field_level from player_country where player_id='" + player_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Char currentLevel = dt.Rows[0]["field_level"].ToString()[(Int32)field_id[0] - 97];
        dbo.CloseConnection();
        return currentLevel;
    }
    /// <summary>
    ///生产cpu产品
    /// </summary>
    /// <param name="cpu_id">cpu id</param>
    /// <param name="num">生产的cpu数量</param>
    /// <param name="field_id">生产cpu地块号</param>
    /// <param name="player_id">用户id</param>
    static public String manufactureCpu(String cpu_id, Int32 num, String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        //计算生产cpu的龙币耗费
        String selectSql = "select manufacture_expense from cpu_info where cpu_id='" + cpu_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 expense = Convert.ToInt32(dt.Rows[0]["manufacture_expense"]);
        selectSql = "select cpu_expense from player_country,race_info where player_country.player_race=race_info.race_id and player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        Single mulity = Convert.ToSingle(dt.Rows[0]["cpu_expense"]);
        expense = Convert.ToInt32(expense * mulity) * num;
        if (checkMoneyEnough(expense, player_id) == -1)
            return "龙币不足，不能生产芯片";
        String updateSql = "update player_resource set money_count=money_count-" + expense + " where player_id='" + player_id + "'";
        dbo.UpdateDataBase(updateSql);
        //计算生产cpu时间耗费
        Char level = getCurrentLevel(field_id, player_id);
        selectSql = "select manufacture_time from building_ability where building_id='3' and building_level='" + level + "'";
        dt = dbo.SelectToDataTable(selectSql);
        Int32 manufactureTime = Convert.ToInt32(dt.Rows[0]["manufacture_time"]);
        selectSql = "select cpu_time from player_country,race_info where player_country.player_race=race_info.race_id and player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        mulity = Convert.ToSingle(dt.Rows[0]["cpu_time"]);
        manufactureTime = Convert.ToInt32(manufactureTime * mulity * num);
        DateTime dTime = DateTime.Now;
        dTime = dTime.AddSeconds(manufactureTime);
        //在数据库中添加工厂状态信息
        updateSql = "insert into building_state(player_id,field_id,work_content,description,eof_dt) values('" + player_id + "','" + field_id + "','" + cpu_id + "'," + num + ",'" + dTime + "')";
        dbo.UpdateDataBase(updateSql);
        dbo.CloseConnection();
        return "";
    }
    /// <summary>
    /// 检查金币是否足够
    /// </summary>
    /// <param name="expense">需要的金币的数量</param>
    /// <param name="player_id">用户id</param>
    /// <returns>若足够返回1，否则返回-1</returns>
    static public Int32 checkMoneyEnough(Int32 expense, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select money_count from player_resource where player_id='" + player_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 count = Convert.ToInt32(dt.Rows[0]["money_count"]);
        if (expense > count)
            return -1;
        return 1;
    }
    /// <summary>
    /// 出售cpu
    /// </summary>
    /// <param name="cpu_id">出售的cpu的型号</param>
    /// <param name="num">出售的cpu的数量</param>
    /// <param name="field_id">出售cpu市场的地块号</param>
    /// <param name="player_id">用户id</param>
    /// <returns>返回出售情况</returns>
    static public String saleCpu(String cpu_id, Int32 num, String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        //查询产品价值
        if (checkCpuEnough(cpu_id, num, player_id) == -1)
            return "芯片数量不足";
        if (checkMarketEnough(num, field_id, player_id) == -1)
            return "市场容量不足";
        String selectSql = "select cpu_value from cpu_info where cpu_id='" + cpu_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 value = Convert.ToInt32(dt.Rows[0]["cpu_value"]) * num;
        String updateSql = "update player_resource set money_count=money_count+" + value + " where player_id='" + player_id + "'";
        dbo.UpdateDataBase(updateSql);
        updateSql = "update player_cpu set cpu_count=cpu_count-" + num + "where player_id='" + player_id + "' and cpu_id='" + cpu_id + "'";
        dbo.UpdateDataBase(updateSql);
        dbo.CloseConnection();
        return "销售成功";
    }
    /// <summary>
    /// 检查芯片数量是否足够
    /// </summary>
    /// <param name="cpu_id">芯片类型id</param>
    /// <param name="num">销售数量</param>
    /// <param name="player_id">用户id</param>
    /// <returns>若足够返回1，否则返回-1</returns>
    static public Int32 checkCpuEnough(String cpu_id, Int32 num, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select cpu_count from player_cpu where player_id='" + player_id + "' and cpu_id='" + cpu_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 count = Convert.ToInt32(dt.Rows[0]["cpu_count"]);
        dbo.CloseConnection();
        if (num > count)
            return -1;
        return 1;
    }
    /// <summary>
    /// 检查指定市场是否有足够的容量
    /// </summary>
    /// <returns></returns>
    static public Int32 checkMarketEnough(Int32 num, String field_id, String player_id)
    {
        Char level = getCurrentLevel(field_id, player_id);
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select sale_count_top from building_ability where building_id='4' and building_level='" + level + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 count_top = Convert.ToInt32(dt.Rows[0]["sale_count_top"]);
        dbo.CloseConnection();
        if (num > count_top)
            return -1;
        return 1;
    }
    /// <summary>
    /// 建造完毕后修改用户信息
    /// </summary>
    /// <param name="building_id">建造的类型</param>
    /// <param name="field_id">建筑所在的地段</param>
    /// <param name="player_id">用户id</param>
    static public void accomplishBuilding(String building_id, String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select field_level,field_type from player_country where player_id='" + player_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        String field_level = dt.Rows[0]["field_level"].ToString();
        String field_type = dt.Rows[0]["field_type"].ToString();
        Int32 field_num = Convert.ToInt32(field_id[0]) - 97;
        field_level = replace(field_num, field_level, 'a');
        field_type = replace(field_num, field_type, Convert.ToChar(building_id));
        String updateSql = "update player_country set is_in_building='0',field_level='" + field_level + "',field_type='" + field_type + "' where player_id='" + player_id + "'";
        dbo.UpdateDataBase(updateSql);
        dbo.CloseConnection();
    }
    /// <summary>
    /// 升级完建筑后修改数据库数据
    /// </summary>
    /// <param name="field_id">升级的数据库所在的diduan</param>
    /// <param name="player_id">用户id</param>
    static public void accomplishUpdate(String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select field_level from player_country where player_id='" + player_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 index = Convert.ToInt32(field_id[0] - 97);
        Char level = dt.Rows[0]["field_level"].ToString()[index];
        String levelResult = replace(index, dt.Rows[0]["field_level"].ToString(), (Char)(level + 1));
        String updateSql = "update player_country set is_in_building='0', field_level='" + levelResult + "' where player_id='" + player_id + "'";
        dbo.UpdateDataBase(updateSql);
        dbo.CloseConnection();
    }
    /// <summary>
    /// 替换字符串中指定位置的字符
    /// </summary>
    /// <param name="index">要替换的字符在字符串中的位置</param>
    /// <param name="str">要替换字符的字符串</param>
    /// <param name="c">替换后的字符</param>
    /// <returns>替换后的字符串</returns>
    static public String replace(Int32 index, string str, Char c)
    {
        if (index > str.Length || index < 0)
            return str;
        String str1 = str.Substring(0, index);
        String str2 = str.Substring(index + 1);
        String strResult = str1 + c + str2;
        return strResult;
    }
    /// <summary>
    /// 完成研发配方任务，修改数据库相关信息
    /// </summary>
    /// <param name="field_id">研发配方的地段id</param>
    /// <param name="player_id">用户id</param>
    static public void accomplishDevelop(String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        //得到研发的cpu的型号和数量
        String selectSql = "select work_content from building_state where player_id='" + player_id + "' and field_id='" + field_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        String cpu_id = dt.Rows[0]["work_content"].ToString();
        Int32 cpu_no = Convert.ToInt32(cpu_id);
        //修改数据库中配方及cpu信息
        selectSql = "select formula_collected from player_resource where player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        String formula_collecdted = dt.Rows[0]["formula_collected"].ToString();
        formula_collecdted = formula_collecdted.Replace(cpu_id, "");
        String updateSql = "update player_resource set formula_collected='" + formula_collecdted + "' where player_id='" + player_id + "'";
        dbo.UpdateDataBase(updateSql);

        selectSql = "select cpu_collected from player_resource where player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        String cpu_collecdted = "";
        if (dt.Rows[0]["cpu_collected"] != null)
        {
            cpu_collecdted = dt.Rows[0]["cpu_collected"].ToString();
            if (!cpu_collecdted.Contains(cpu_id))
            {
                cpu_collecdted += cpu_id;
            }
        }
        else
        {
            cpu_collecdted = cpu_id;
        }
        updateSql = "update player_resource set cpu_collected='" + cpu_collecdted + "' where player_id='" + player_id + "'";
        dbo.UpdateDataBase(updateSql);

        updateSql = "delete from building_state where player_id='" + player_id + "' and field_id='" + field_id + "'";
        dbo.UpdateDataBase(updateSql);

        dbo.CloseConnection();
    }
    /// <summary>
    /// 完成生产任务，修改数据库内容
    /// </summary>
    /// <param name="field_id">工厂所在的地段id</param>
    /// <param name="player_id">用户id</param>
    static public void accomplishManufacture(String field_id, String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select work_content,description from building_state where player_id='" + player_id + "' and field_id='" + field_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        String cpu_id = dt.Rows[0]["work_content"].ToString();
        Int32 cpu_num = Convert.ToInt32(dt.Rows[0]["description"]);
        selectSql = "select data_id from player_cpu where player_id='" + player_id + "' and cpu_id='" + cpu_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        String updateSql = "";
        if (dt.Rows.Count == 0)
        {
            updateSql = "insert into player_cpu(player_id,cpu_id,cpu_count) values('" + player_id + "','" + cpu_id + "'," + cpu_num + ")";
        }
        else
        {
            updateSql = "update player_cpu set cpu_count=cpu_count+" + cpu_num + " where player_id='" + player_id + "' and cpu_id='" + cpu_id + "'";
        }
        dbo.UpdateDataBase(updateSql);
        updateSql = "delete from building_state where player_id='" + player_id + "' and field_id='" + field_id + "'";
        dbo.UpdateDataBase(updateSql);
    }
    /// <summary>
    /// 得到距离现在最近的用户正在进行中的事务的完成时间
    /// </summary>
    /// <param name="player_id">用户id</param>
    /// <returns></returns>
    static public Int32 getLatestTime(String player_id)
    {
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select eof_dt from building_state where player_id='" + player_id + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        Int32 temp = 10000000;
        TimeSpan span = new TimeSpan();
        DateTime dTime = DateTime.Now;
        if (dt != null && dt.Rows.Count > 0)
        {
            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                span = Convert.ToDateTime(dt.Rows[i]["eof_dt"]) - dTime;
                if (span.TotalSeconds > 0)
                {
                    if (span.TotalSeconds < temp)
                    {
                        temp = Convert.ToInt32(span.TotalSeconds);
                    }
                }
            }
        }
        selectSql = "select is_in_building,eof_dt from player_country where  player_id='" + player_id + "'";
        dt = dbo.SelectToDataTable(selectSql);
        if (dt.Rows[0]["is_in_building"].ToString() == "0")
        {
            return temp;
        }
        else
        {
            span = Convert.ToDateTime(dt.Rows[0]["eof_dt"]) - dTime;
            if (span.TotalSeconds > 0)
            {
                if (span.TotalSeconds < temp)
                {
                    temp = Convert.ToInt32(span.TotalSeconds);
                }
            }
        }
        return temp;
    }
    /// <summary>
    /// 判断画龙点睛是否有当天活动记录
    /// </summary>
    /// <returns>有则返回true，否则返回false</returns>
    public static Boolean Is_Exist()
    {
        Boolean flag = true;
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String selectSql = "select data_id from logo_record where create_date='" + DateTime.Now.ToString("yyyy-M-d") + "'";
        DataTable dt = dbo.SelectToDataTable(selectSql);
        if (dt != null && dt.Rows.Count < 1)
        {
            flag = false;
        }
        dbo.CloseConnection();
        return flag;
    }
    /// <summary>
    /// 增加上传作品数量
    /// </summary>
    /// <param name="num">上传的作品的数量</param>
    /// <returns>若修改成功返回true，否则返回false</returns>
    public static Boolean Add_Work(Int32 num)
    {
        Boolean flag = true;
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String updateSql = "";
        if (Is_Exist())
        {
            updateSql = "update logo_record set work_num=work_num+" + num + " where create_date='" + DateTime.Now.ToString("yyyy-M-d") + "'";
        }
        else
        {
            updateSql = "insert into logo_record(work_num,vote_num,create_date) values(" + num + ",0,'" + DateTime.Now.ToString("yyyy-M-d") + "')";
        }
        if (dbo.UpdateDataBase(updateSql) == -1)
        {
            flag = false;
        }
        return flag;
    }
    /// <summary>
    /// 增加投票的次数
    /// </summary>
    /// <param name="num">投票次数</param>
    /// <returns>若修改成功返回true，否则返回false</returns>
    public static Boolean Add_Vote(Int32 num)
    {
        Boolean flag = true;
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String updateSql = "";
        if (Is_Exist())
        {
            updateSql = "update logo_record set vote_num=vote_num+" + num + " where create_date='" + DateTime.Now.ToString("yyyy-M-d") + "'";
        }
        else
        {
            updateSql = "insert into logo_record(work_num,vote_num,create_date) values(0," + num + ",'" + DateTime.Now.ToString("yyyy-M-d") + "')";
        }
        if (dbo.UpdateDataBase(updateSql) == -1)
        {
            flag = false;
        }
        return flag;
    }
    /// <summary>
    /// 增加获得兑换券的人的数量
    /// </summary>
    /// <param name="num">获得兑换券的人数</param>
    /// <returns>若修改成功返回true，否则返回false</returns>
    public static Boolean Add_Get_Ticket(Int32 num)
    {
        Boolean flag = true;
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String dTime = DateTime.Now.ToString("yyyy-M-d");
        String queryString = "select data_id from visit_record where visit_date='" + dTime + "' and visit_type='ticket_num'";
        DataTable dt = dbo.SelectToDataTable(queryString);
        String updateString = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            updateString = "update visit_record set visit_num=visit_num+1 where visit_type='ticket_num' and visit_date='" + dTime + "'";
        }
        else
        {
            updateString = "insert into visit_record(visit_type,visit_num,visit_date) values('ticket_num'," + num + ",'" + dTime + "')";
        }
        if (dbo.UpdateDataBase(updateString) == -1)
        {
            flag = false;
        }

        dbo.CloseConnection();
        return flag;
    }
    /// <summary>
    /// 增加回答问题人数
    /// </summary>
    /// <param name="num">回答问题的人数</param>
    /// <returns>若修改成功返回true，否则返回false</returns>
    public static Boolean Add_Answered(Int32 num)
    {
        Boolean flag = true;
        DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        dbo.Connect();
        String dTime = DateTime.Now.ToString("yyyy-M-d");
        String queryString = "select data_id from visit_record where visit_date='" + dTime + "' and visit_type='answered_Num'";
        DataTable dt = dbo.SelectToDataTable(queryString);
        String updateString = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            updateString = "update visit_record set visit_num=visit_num+1 where visit_type='answered_Num' and visit_date='" + dTime + "'";
        }
        else
        {
            updateString = "insert into visit_record(visit_type,visit_num,visit_date) values('answered_Num'," + num + ",'" + dTime + "')";
        }
        if (dbo.UpdateDataBase(updateString) == -1)
        {
            flag = false;
        }

        dbo.CloseConnection();
        return flag;
    }
    /// <summary>
    /// 根据用户输入信息不同给予响应
    /// </summary>
    /// <param name="input"></param>
    /// <param name="res"></param>
    public static void Response_To(String input, HttpResponse res)
    {
        //if (input == "yu")
        //    Message.Show(YuQing.YuDecode("YWxleCBsb3ZlIGphbmV0IGZvcmV2ZXI="), res);
    }

}
