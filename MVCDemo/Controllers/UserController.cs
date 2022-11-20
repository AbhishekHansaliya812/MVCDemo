using MVCDemo.DAL;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                RegisterDataAccessLayer registerDataAccessLayer = new RegisterDataAccessLayer();
                string message = registerDataAccessLayer.SignUpUser(model);
            }
            else 
            {
                return View("~/Views/User/Index.cshtml");
            }

            return View();
        }
    }
}