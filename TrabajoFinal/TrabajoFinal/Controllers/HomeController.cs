using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.ViewModels.Home;

namespace TrabajoFinal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DashboardAdmin()
        {
            var model = new DashboardAdminViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult DashboardSupervisor()
        {
            var model = new DashboardSupervisorViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult DashboardProveedor()
        {
            var model = new DashboardProveedorViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult DashboardEmpleado()
        {
            var model = new DashboardEmpleadoViewModel();
            
            return View(model);
        }
    }
}