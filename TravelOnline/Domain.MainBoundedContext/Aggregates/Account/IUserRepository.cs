using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.MainBoundedContext.Aggregates.Account
{
    public interface IUserRepository : IRepository<UserAccount>
    {
         bool AddUser(UserAccount u);
         bool GetUserById(int id);
         bool LoginUser(UserAccount ua);
    }
}
