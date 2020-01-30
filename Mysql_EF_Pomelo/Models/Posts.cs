using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mysql_EF_Pomelo.Models
{
    public class Posts
    {
        public int post_id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
