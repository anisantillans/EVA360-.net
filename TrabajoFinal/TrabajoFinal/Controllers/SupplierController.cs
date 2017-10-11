using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Helpers;
using TrabajoFinal.Models;
using TrabajoFinal.ViewModels.Supplier;

namespace TrabajoFinal.Controllers
{
    public class SupplierController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LstProveedor()
        {
            var model = new LstProveedorViewModel();
            model.CargarDatos(context);
            return View(model);
        }
        public ActionResult AddEditProveedor(Int32? ProveedorId)
        {
            var model = new AddEditProveedorViewModel();
            model.CargarDatos(context, ProveedorId);
            return View(model);
        }
        public ActionResult EliminarProveedor(Int32? ProveedorId)
        {
            try
            {
                var usuario = context.Usuario.FirstOrDefault( x => x.Proveedor.ProveedorId == ProveedorId);
                usuario.Estado = ConstantHelpers.ESTADO_USUARIO.INACTIVO;
                context.SaveChanges();
                PostMessage(MessageType.Success, "La operación fue realizada de forma correcta");
                return RedirectToAction("LstProveedor");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                return RedirectToAction("LstProveedor");
            }
        }
        [HttpPost]
        public ActionResult AddEditProveedor(AddEditProveedorViewModel model)
        {
            try
            {
                Proveedor Proveedor = null;
                Usuario Usuario = null;
                if (model.ProveedorId.HasValue)
                {
                    Proveedor = context.Proveedor.FirstOrDefault( x => x.ProveedorId == model.ProveedorId);
                }
                else
                {
                    Usuario = new Usuario();
                    Proveedor = new Proveedor();
                    Proveedor.Usuario = Usuario;
                    Proveedor.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Proveedor.FechaCreacion = DateTime.Now;
                    Usuario.UsuarioCreacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                    Usuario.FechaCreacion = DateTime.Now;
                    Usuario.Estado = ConstantHelpers.ESTADO_USUARIO.ACTIVO;
                    context.Usuario.Add(Usuario);
                    context.Proveedor.Add(Proveedor);
                }

                Proveedor.UsuarioModificacionId = Convert.ToInt32(Session["UsuarioId"].ToString());
                Proveedor.FechaModificacion = DateTime.Now;

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
                return RedirectToAction("LstProveedor");
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Sucedió un error, intente nuevamente.");
                model.CargarDatos(context, model.ProveedorId);
                return View(model);
            }
        }
    }
}