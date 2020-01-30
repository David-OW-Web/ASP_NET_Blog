using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mysql_EF_Pomelo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Session;

namespace Mysql_EF_Pomelo.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _db;
        public AccountController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var accounts = _db.Account.OrderByDescending(x => x.created_at).ToList();
            ViewBag.Accounts = accounts;
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("username");
            }
            return View();
        }

        public IActionResult Details(int? id)
        {
            var account = _db.Account.Where(x => x.account_id == id).Where(x => x.username != "Admin").ToList();
            return View();
        }

        public IActionResult Login([Bind("username, password")]Accounts account)
        {
            var query = _db.Account.Where(x => x.username == account.username).Where(x => x.password == account.password).ToList();
            ViewBag.Data = query;
            if (query.Count == 1)
            {

                HttpContext.Session.SetString("username", account.username);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                HttpContext.Session.Remove("username");
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Register([Bind("username, email, password")]Accounts account)
        {
            if(account.username != null)
            {
                var query = _db.Account.Where(x => x.username == account.username).ToList();
                if(query.Count == 1)
                {
                    ViewBag.Error = "Username taken";
                } else
                {
                    account.created_at = DateTime.Now;
                    _db.Account.Add(account);
                    _db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}