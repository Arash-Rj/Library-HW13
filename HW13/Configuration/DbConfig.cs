using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Configuration
{
    public class DbConfig
    {
        public static string ConnectionString { get; set; }
        static DbConfig()
        {
            ConnectionString = @"Data Source=DESKTOP-7648UU0\SQLEXPRESS; Initial Catalog=HW13-2; User Id=sa; Password=123456; TrustServerCertificate=True;";
        }
    }
}
