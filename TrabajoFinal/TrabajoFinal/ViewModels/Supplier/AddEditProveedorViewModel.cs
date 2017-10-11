using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TrabajoFinal.ViewModels.Supplier
{
    public class AddEditProveedorViewModel
    {
        public Int32? ProveedorId { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public String Apellido { get; set; }
        [Required]
        public String Codigo { get; set; }
        [Required]
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public String Sexo { get; set; }
        [Required]
        public String NroDocumento { get; set; }
        [Required]
        public Int32 TipoDocumentoId { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }

        public String Salt { get; set; }
        public List<TipoDocumento> LstTipoDocumentos { get; set; } = new List<TipoDocumento>();
        public List<SelectListItem> LstSexo { get; set; } = new List<SelectListItem>();
        public void CargarDatos(EVA360Entities context, Int32? proveedorId)
        {
            LstSexo.Add(new SelectListItem { Text = "MACULINO", Value = "M" });
            LstSexo.Add(new SelectListItem { Text = "FEMENINO", Value = "F" });

            LstTipoDocumentos = context.TipoDocumento.ToList();
            this.ProveedorId = proveedorId;
            if (this.ProveedorId.HasValue)
            {
                var proveedor = context.Proveedor.Include( x => x.Usuario).FirstOrDefault(x => x.ProveedorId == this.ProveedorId);
                Nombre = proveedor.Usuario.Nombre;
                Apellido = proveedor.Usuario.Apellido;
                Codigo = proveedor.Usuario.Codigo;
                FechaNacimiento = proveedor.Usuario.FechaNacimiento;
                NroDocumento = proveedor.Usuario.NroDocumento;
                TipoDocumentoId = proveedor.Usuario.TipoDocumentoId;
                Email = proveedor.Usuario.Email;
                Password = proveedor.Usuario.Password;
                Salt = proveedor.Usuario.Salt;
                Sexo = proveedor.Usuario.Sexo;
            }
        }
    }
}