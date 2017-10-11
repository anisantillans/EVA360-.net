using TrabajoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class AddEditEvaluationViewModel
    {
        public Int32? evaluacionId { set; get; }
        public String nombre { set; get; }
        public decimal porcetajeavance { set; get; }
        public Int32 supervisorId { set; get; }
        public Int32 proveedorId { set; get; }
        public String rutaInforme { set; get; }
        public Int32 empleadoId { set; get; }
        public Int32 periodoId { set; get; }
        public Int32 usuariocreacionId { set; get; }
        public DateTime fechacreacion { set; get; }
        public Supervisor supervidor { set; get; }
        public Empleado empleado { set; get; }

        public List<Empleado> Lstempleado { set; get; } = new List<Empleado>();
        public List<SelectListItem> LstUsuario { set; get; } = new List<SelectListItem>();
        public void Cargar(EVA360Entities context, Int32? evaluacionId)
        {
            this.evaluacionId = evaluacionId;
            if (this.evaluacionId.HasValue)
            {
                var evaluacion = context.Evaluacion.FirstOrDefault(x => x.EvaluacionId == this.evaluacionId);
                nombre = evaluacion.Nombre;
                porcetajeavance = evaluacion.PorcentajeAvance;
                supervisorId = evaluacion.SupervisorId;
                proveedorId = evaluacion.ProveedorId.Value;
                rutaInforme = evaluacion.RutaInforme;
                empleadoId = evaluacion.EmpleadoId;
                periodoId = evaluacion.PeriodoId;
                usuariocreacionId = evaluacion.UsuarioCreacionId;
                fechacreacion = evaluacion.FechaCreacion;
            }
            else
            {
                var periodo = context.Periodo.FirstOrDefault(x => x.FechaInicio <= DateTime.Now && x.FechaFin >= DateTime.Now);
                periodoId = periodo.PeriodoId;
            }

            Lstempleado = context.Empleado.ToList();


            LstUsuario = context.Empleado.Where(x => x.EmpleadoId == x.Usuario.UsuarioId)
                .Select(y => new SelectListItem { Text = y.Usuario.Nombre + " " + y.Usuario.Apellido, Value = y.EmpleadoId.ToString() }).ToList();

        }

    }
}