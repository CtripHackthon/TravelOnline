using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.Base.Common
{
    public class UserInfo
    {
        public String username { get; set; }
        public String  password { get; set; }

        public String email { get; set; }

        public String phone { get; set; }

        public account_type type { get; set; }
    }

    public enum account_type
    {
        ADMIN = 1,
        VIP = 2,
        NORMAL = 3
    }
}
