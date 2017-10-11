using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TrabajoFinal.ViewModels.Manager
{
    public class AddEditManagerViewModel
    {
        public Int32? SupervisorId { get; set; }
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
        public void CargarDatos(EVA360Entities context, Int32? supervisorId)
        {
            LstSexo.Add(new SelectListItem { Text = "MACULINO", Value = "M" });
            LstSexo.Add(new SelectListItem { Text = "FEMENINO", Value = "F" });

            LstTipoDocumentos = context.TipoDocumento.ToList();
            this.SupervisorId = supervisorId;
            if (this.SupervisorId.HasValue)
            {
                var supervisor = context.Supervisor.Include(x => x.Usuario).FirstOrDefault(x => x.SupervisorId == this.SupervisorId);
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