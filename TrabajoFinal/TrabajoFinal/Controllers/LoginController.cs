using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TrabajoFinal.Models;
using TrabajoFinal.ViewModels.Login;

namespace TrabajoFinal.Controllers
{
    public class LoginController : BaseController
    {
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var context = new EVA360Entities();
       
            var usuario = context.Usuario.FirstOrDefault(x=>x.Codigo==model.Usuario
                            &&  x.Password==model.Password);

            if (usuario != null)
            {
                Session["UsuarioId"] = usuario.UsuarioId;
                Session["NombreCompleto"] = usuario.Nombre + " " + usuario.Apellido;
                String Roles = usuario.Codigo.Substring(0, 3).ToUpper();
                if (Roles == "EMP")
                {
                    Session["Rol"] = "EMP";
                    return RedirectToAction("DashboardEmpleado", "Home");
                }
                else if (Roles == "SUP")
                {
                    Session["Rol"] = "SUP";
                    return RedirectToAction("DashboardSupervisor", "Home");
                }
                else if (Roles == "PRO")
                {
                    Session["Rol"] = "PRO";
                    return RedirectToAction("DashboardProveedor", "Home");
                }
                else //(Roles == "ADM")
                {
                    Session["Rol"] = "ADM";
                    return RedirectToAction("DashboardAdmin", "Home");
                }
            }
            else
            {
                PostMessage(MessageType.Error, "Usuario/Contraseña incorrectos");
            }
            return View(model);
        }
    }
}