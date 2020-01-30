using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mysql_EF_Pomelo.Models;
using Microsoft.EntityFrameworkCore;

namespace Mysql_EF_Pomelo.Controllers
{
    public class PostController : Controller
    {
        private readonly DataContext _db;
        public PostController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var posts = _db.Post.OrderByDescending(x => x.created_at).ToList();
            ViewBag.Posts = posts;
            return View();
        }

        public IActionResult Delete(int? id)
        {
            // var post = new Posts { post_id = id };
            _db.Post.Remove(_db.Post.Single(a => a.post_id == id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            var post = _db.Post.Where(x => x.post_id == id).ToList();
            ViewBag.Post = post;
            ViewBag.Id = id;
            var comments = _db.Comment.Where(x => x.fk_post_id == id).ToList();
            ViewBag.Comments = comments;
            return View();
        }

        public IActionResult Comment(int? id, [Bind("fk_post_id, title, body")]Comments comment)
        {
            if (comment.title != null)
            {
                comment.comment_date = DateTime.Now;
                _db.Comment.Add(comment);
                _db.SaveChanges();
                return RedirectToRoute(new { Controller = "Post", Action = "Details", id = comment.fk_post_id });
            }
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

        public IActionResult Edit(int? id, [Bind("title, body, updated_at")]Posts post)
        {
            if (post.title != null)
            {
                var postC = _db.Post.Where(x => x.post_id == id).First();
                postC.title = post.title;
                postC.body = post.body;
                postC.updated_at = DateTime.Now;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            var postData = _db.Post.Where(x => x.post_id == id).ToList();
            ViewBag.Post = postData;
            return View();
        }
    }
}