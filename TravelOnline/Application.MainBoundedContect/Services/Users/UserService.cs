using Infrastructor.MainBoundedContext.UnitWorks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Web;
using Microsoft.Owin.Host.SystemWeb;
using Application.MainBoundedContect.Extentions;
using Infrastructor.MainBoundedContext.Repositories.Users;
using System.Collections.Generic;
using Domain.MainBoundedContext.Aggregates.Account;
using Application.MainBoundedContext.DAO;
namespace Application.MainBoundedContect.Services.Users
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository usr)
        {
            userRepository = usr;
        }

        public bool LoginUser(AppUser user) {
            return userRepository.LoginUser(user.ToUser());
        }
        public bool RegisterUser(AppUser user)
        {
            return userRepository.AddUser(user.ToUser());
        }
    }
}
