using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSSystem.Controllers
{
    public class UserController : Controller
    {
        IMRepository<User> context;
        // GET: User
        public UserController(IMRepository<User> Usercontext)
        {
            context = Usercontext;
        }
        public ActionResult Index()
        {
            List<User> users = context.Collection().ToList();
            return View(users);
        }
    }
}