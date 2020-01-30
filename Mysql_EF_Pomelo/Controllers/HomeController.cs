using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mysql_EF_Pomelo.Models;
using Microsoft.EntityFrameworkCore;

namespace Mysql_EF_Pomelo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _db;

        public HomeController(ILogger<HomeController> logger, DataContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var posts = _db.Post.OrderBy(x => x.created_at).ToList();
            ViewBag.Posts = posts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Delete(int? id)
        {
            // var post = new Posts { post_id = id };
            _db.Post.Remove(_db.Post.Single(a => a.post_id == id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create([Bind("title, body")]Posts post)
        {
            if (post.title != null)
            {
                post.created_at = DateTime.Now;
                post.updated_at = DateTime.Now;
                _db.Post.Add(post);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int? id)
        {
            var post = _db.Post.Where(x => x.post_id == id).ToList();
            ViewBag.Post = post;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
