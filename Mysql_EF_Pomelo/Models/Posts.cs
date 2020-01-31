using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mysql_EF_Pomelo.Models
{
    public class Posts
    {
        public int post_id { get; set; }
        [Display(Name = "Post title")]
        public string title { get; set; }
        [Display(Name = "Post body")]
        public string body { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
