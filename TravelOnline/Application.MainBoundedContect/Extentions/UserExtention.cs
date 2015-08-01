using Infrastructor.MainBoundedContext.UnitWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MainBoundedContext.DAO;
using Domain.MainBoundedContext.Aggregates.Account;

namespace Application.MainBoundedContect.Extentions
{
    public static class UserExtention
    {
        public static AppUser ToAppUser(this UserAccount user)
        {
            var t =
            new AppUser()
            {
                 UserID=user.Id,
                  UserName=user.UserName,
                   UserPassword=user.Password
            };
            return t;
        }

        public static UserAccount ToUser(this AppUser user)
        {
            return new UserAccount()
            {
                 Id=user.UserID,
                 UserName=user.UserName,
                  Password=user.UserPassword
            };
        }
    }
}
