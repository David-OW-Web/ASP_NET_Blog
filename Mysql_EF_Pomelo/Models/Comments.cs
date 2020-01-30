using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mysql_EF_Pomelo.Models
{
    public class Comments
    {
        public int comment_id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime comment_date { get; set; }
        public int fk_post_id { get; set; }
    }
}
