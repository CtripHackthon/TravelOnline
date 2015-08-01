using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DataModel
{
    class test
    {
        static void Main(string[] args)
        {
            user u = new user();
            u.userName = "hui";
            u.password = "123";
            User.saveUser(u);
            Console.WriteLine( User.getIdentity("hui", "123"));

            Console.ReadKey();
        }
    }
}
