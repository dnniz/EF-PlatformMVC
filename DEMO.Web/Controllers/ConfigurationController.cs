using DEMO.Entity;
using DEMO.Services.Interface;
using DEMO.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEMO.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        // GET: Configuration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User()
        {
            var model = new JsonDTO();

            return View(model);
        }

        public JsonResult AddUser(User user)
        {
            var model = new JsonDTO();

            DBProviderManager<UserIProvider>.Provider.AddUser(user, "admin");

            return Json(model);
        }

        public JsonResult ListUsers(string nombre, DateTime? fechaI, DateTime? fechaF, bool? flagActivo, int pageNumber, int pageSize)
        {
            var model = new JsonDTO();

            int total = 0;

            model.ListUser = new List<User>();
            model.ListUser = DBProviderManager<UserIProvider>.Provider.GetUsersByType(nombre, fechaI, fechaF, flagActivo, pageNumber, pageSize, out total);
            model.Total = total;

            return Json(model);
        }
    }
}