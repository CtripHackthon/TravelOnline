using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class User
    {
        //用户注册 -- UserRegist
        //todo: 同名的username可以添加
        public static void saveUser(user u)
        {
            using (var ctx = new hackthonEntities())
            {
                if (u.credits == null) u.credits = 0; //虽然db中默认值为0，但是添加新行还是为空；
                ctx.AddTousers(u);
                ctx.SaveChanges();
            }
        }

        //用户登录 -- UserLogin
        //登陆失败返回-1，登陆成功返回用户的身份: 
        public static int? getIdentity(string userName, string password)
        {
            IQueryable<user> results; int? identity;
            using (var ctx = new hackthonEntities())
            {
                   results  = ctx.users.Where(c => c.userName ==userName && c.password ==password);
                   if (results != null)
                       identity = results.First().identity;
                   else
                       identity = -1;
                   return identity;
            }            
        }

        //获取用户信息 selectUserInfoById
        public static user selectUserInfoById(int userID)
        {
            IQueryable<user> results;
            using (var ctx = new hackthonEntities())
            {
                   results  = ctx.users.Where(c => c.userID == userID);
                   return results.First();
            }            
        }

        //付款成功添加100积分
	//updateCredits(userID, price) ;  价格的1/10的积分，比如10000就给1000积分，相当于10块，（1/1000）
        public static void updateCredits(int userID, decimal credits)
        {
            using (var ctx = new hackthonEntities())
            {
                user user = selectUserInfoById(userID);
                ctx.users.Attach(user);
                
                user.credits += credits;
                ctx.SaveChanges();
            }
        }
    }
}
