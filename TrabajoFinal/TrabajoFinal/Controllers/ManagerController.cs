using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Helpers;
using TrabajoFinal.Models;
using TrabajoFinal.ViewModels.Manager;

namespace TrabajoFinal.Controllers
{
    public class ManagerController : BaseController
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LstManager()
        {
            var model = new LstManagerViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult AddEditManager(Int32? SupervisorId)
        {
            var model = new AddEditManagerViewModel();
            model.CargarDatos(context, SupervisorId);
            return View(model);
        }
        public ActionResult EliminarManager(Int32? SupervisorId)
        {
            try
            {
                var usuario = context.Usuario.FirstOrDefault(x => x.Supervisor.SupervisorId == SupervisorId);
                usuario.Estado = ConstantHelpers.ESTADO_USUARIO.INACTIVO;
                context.SaveChanges();
                PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                return RedirectToAction("LstManager");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                return RedirectToAction("LstManager");
            }
        }
        [HttpPost]
        public ActionResult AddEditManager(AddEditManagerViewModel model)
        {
            try
            {
                Supervisor Supervisor = null;
                Usuario Usuario = null;
                if (model.SupervisorId.HasValue)
                {
                    Supervisor = context.Supervisor.FirstOrDefault(x => x.SupervisorId == model.SupervisorId);
                }
                else
                {
                    Usuario = new Usuario();
                    Supervisor = new Supervisor();
                    Supervisor.Usuario = Usuario;
                    Supervisor.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Supervisor.FechaCreacion = DateTime.Now;
                    Usuario.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Usuario.FechaCreacion = DateTime.Now;
                    Usuario.Estado = ConstantHelpers.ESTADO_USUARIO.ACTIVO;
                    context.Usuario.Add(Usuario);
                    context.Supervisor.Add(Supervisor);
                }

                Supervisor.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                Supervisor.FechaModificacion = DateTime.Now;

                Usuario.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                Usuario.FechaModificacion = DateTime.Now;

                Usuario.Nombre = model.Nombre;
                Usuario.Apellido = model.Apellido;
                Usuario.Codigo = model.Codigo;
                Usuario.FechaNacimiento = model.FechaNacimiento.Value;
                Usuario.NroDocumento = model.NroDocumento;
                Usuario.TipoDocumentoId = model.TipoDocumentoId;
                Usuario.Email = model.Email;
                Usuario.Password = model.Password;
                Usuario.Salt = "123";
                Usuario.Sexo = model.Sexo;
                context.SaveChanges();

                PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                return RedirectToAction("LstManager");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                model.CargarDatos(context, model.SupervisorId);
                return View(model);
            }
        }
    }
}