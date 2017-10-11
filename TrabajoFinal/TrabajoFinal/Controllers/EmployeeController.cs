using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Helpers;
using TrabajoFinal.ViewModels.Employee;
using TrabajoFinal.Models;

namespace TrabajoFinal.Controllers
{
    public class EmployeeController : BaseController
    {        
        public ActionResult LstEmployee()
        {
            var model = new LstEmployeeViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult AddEditEmployee(Int32? EmpleadoId)
        {
            var model = new AddEditEmployeeViewModel();
            model.CargarDatos(context, EmpleadoId);
            return View(model);
        }
        public ActionResult EliminarEmployee(Int32? EmpleadoId)
        {
            try
            {
                var usuario = context.Usuario.FirstOrDefault(x => x.Empleado.EmpleadoId == EmpleadoId);
                usuario.Estado = ConstantHelpers.ESTADO_USUARIO.INACTIVO;
                context.SaveChanges();
                PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                return RedirectToAction("LstEmployee");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                return RedirectToAction("LstEmployee");
            }
        }
        [HttpPost]
        public ActionResult AddEditEmployee(AddEditEmployeeViewModel model)
        {
            try
            {
                Empleado Empleado = null;
                Usuario Usuario = null;
                if (model.EmpleadoId.HasValue)
                {
                    Empleado = context.Empleado.FirstOrDefault(x => x.EmpleadoId == model.EmpleadoId);
                }
                else
                {
                    Usuario = new Usuario();
                    Empleado = new Empleado();
                    Empleado.Usuario = Usuario;
                    Empleado.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Empleado.FechaCreacion = DateTime.Now;
                    Usuario.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Usuario.FechaCreacion = DateTime.Now;
                    Usuario.Estado = ConstantHelpers.ESTADO_USUARIO.ACTIVO;
                    context.Usuario.Add(Usuario);
                    context.Empleado.Add(Empleado);
                }

                Empleado.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                Empleado.FechaModificacion = DateTime.Now;

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
                return RedirectToAction("LstEmployee");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                model.CargarDatos(context, model.EmpleadoId);
                return View(model);
            }
        }

        
      
    }
}
