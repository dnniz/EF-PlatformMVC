using AutoMapper;
using DEMO.Entity;
using DEMO.Services.Interface;
using DEMO.Web.Models;
using DEMO.Web.Models.Validation;
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
            int zero;
            var listUser = DBProviderManager<UserIProvider>.Provider.GetUsersByType(null, null, null, null, 0, 0, out zero);

            //Chrome sessionId = j3jnguxblec1h03d2uhml5wm
            //Firefox sessionId = zg3s0udd4awnh125dof1yw2x
            var sessionId = Session.SessionID;
            //Session["test"] = "FirstUser";
            //var userValid = Session[0];
            return View(listUser);
        }


        public ActionResult User()
        {
            var model = new JsonDTO();

            return View(model);
        }
        public class Data
        {
            public string message { get; set; }
        }
        public JsonResult AddUser(UserViewModel model)
        {
            var response = new UserViewModel();
            
            if (!ModelState.IsValid)
            {
                //Código para enviar errores del modelo
                response.Errors = new UserValidator().Validate(model).Errors;
                response.ModelValid = ModelState.IsValid;
            }

            //Mapeo de propiedades
            var user = Mapper.Map<User>(model);

            //Ejecución en Base de Datos
            DBProviderManager<UserIProvider>.Provider.AddUser(user, "admin");

            return Json(response);
        }


        //public JsonResult AddUser(User user)
        //{
        //    var model = new JsonDTO();

        //    DBProviderManager<UserIProvider>.Provider.AddUser(user, "admin");

        //    return Json(model);
        //}

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