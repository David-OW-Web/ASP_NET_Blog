using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mysql_EF_Pomelo.Models
{
    public class Accounts
    {
        public int account_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime created_at { get; set; }
    }
}
