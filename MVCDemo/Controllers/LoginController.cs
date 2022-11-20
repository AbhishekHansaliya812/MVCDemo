using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                using (MVCDemoEntities db = new MVCDemoEntities())
                {
                    var obj = db.Users.Where(model => model.UserName.Equals(user.UserName) && model.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Product");
                    }
                    else 
                    {
                        ViewBag.Message = "User Name or Password is incorrect";
                    }
                }
            }
            return View(user);
        }

        public ActionResult Product()
        {
            if (Session["UserID"] != null)
            {
                MVCDemoEntities db = new MVCDemoEntities();
                return View(db.Products.ToList());
            }
            else
            {
                ViewBag.Message = "User Name or Password is incorrect";
                return RedirectToAction("Login");
            }
        }
    }
}