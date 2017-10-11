using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class PuntosAcumuladosViewModel
    {
        public Int32 PeriodoId { get; set; }
        public List<Evaluacion> LstEvaluacion { get; set; } = new List<Evaluacion>();
        public void CargarDatos(EVA360Entities context, Int32? EmpleadoId)
        {
            var periodo = context.Periodo.FirstOrDefault(x => x.FechaInicio <= DateTime.Now && x.FechaFin >= DateTime.Now);
            PeriodoId = periodo.PeriodoId;
            var LstEvaluacion = context.Evaluacion.Where(x => x.EmpleadoId == EmpleadoId).ToList();   
        }
    }
}