using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.ServiceModel
{
    public class UserLoginRequest
    {
        public String username { get; set; }

        public String password { get; set; }
    }
}
