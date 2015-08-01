using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.MainBoundedContext.Aggregates.Account
{
    public class UserAccount : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
