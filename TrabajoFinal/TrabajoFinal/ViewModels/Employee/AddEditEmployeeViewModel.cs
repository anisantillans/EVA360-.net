using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TrabajoFinal.ViewModels.Employee
{
    public class AddEditEmployeeViewModel
    {
        public Int32? EmpleadoId { get; set; }
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
        public void CargarDatos(EVA360Entities context, Int32? EmpleadoId)
        {
            LstSexo.Add(new SelectListItem { Text ="MACULINO",Value="M"});
            LstSexo.Add(new SelectListItem { Text = "FEMENINO", Value = "F" });
           
            LstTipoDocumentos = context.TipoDocumento.ToList();
            this.EmpleadoId = EmpleadoId;
            if (this.EmpleadoId.HasValue)
            {
                var supervisor = context.Empleado.Include(x => x.Usuario).FirstOrDefault(x => x.EmpleadoId == this.EmpleadoId);
                Nombre = supervisor.Usuario.Nombre;
                Apellido = supervisor.Usuario.Apellido;
                Codigo = supervisor.Usuario.Codigo;
                FechaNacimiento = supervisor.Usuario.FechaNacimiento;
                NroDocumento = supervisor.Usuario.NroDocumento;
                TipoDocumentoId = supervisor.Usuario.TipoDocumentoId;
                Email = supervisor.Usuario.Email;
                Password = supervisor.Usuario.Password;
                Salt = supervisor.Usuario.Salt;
                Sexo = supervisor.Usuario.Sexo;
            }
        }
    }
}