using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Fitness_Zone.DAL
{
    class DBEstablish
    {
        public static string makeConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["Fitness_Zone"].ToString();
            return con;
        }
    }
}
