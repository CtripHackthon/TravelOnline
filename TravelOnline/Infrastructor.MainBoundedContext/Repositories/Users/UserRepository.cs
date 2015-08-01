using Infrastructor.MainBoundedContext.UnitWorks;
using Infrastructor.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainBoundedContext.Aggregates.Account;

namespace Infrastructor.MainBoundedContext.Repositories.Users
{
    public class UserRepository: Repository<UserAccount>, IUserRepository
    {
        public UserRepository(MainDBUnitWorkContext _unitOfWork) :base(_unitOfWork) { 
        
        }


        public bool AddUser(UserAccount u)
        {
            this.Add(u);
            return true;
        }

        public bool GetUserById(int id)
        {
            return true;
        }

        public bool LoginUser(UserAccount ua)
        {
            var selectedUser = this.GetFiltered(_ => _.UserName == ua.UserName && _.Password == ua.Password);
            return selectedUser.Count() > 0;
        }
    }
}
