using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mysql_EF_Pomelo.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Mysql_EF_Pomelo.Controllers
{
    public class CommentController : Controller
    {
        private readonly DataContext _db;
        public CommentController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? page)
        {
            int pagesize = 3;
            int pageNumber = (page ?? 1);
            var comments = _db.Comment.OrderByDescending(x => x.comment_date);
            var pagedComments = comments.ToList().ToPagedList(pageNumber, pagesize);
            ViewBag.Comments = pagedComments;
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _db.Comment.Remove(_db.Comment.Single(x => x.comment_id == id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}