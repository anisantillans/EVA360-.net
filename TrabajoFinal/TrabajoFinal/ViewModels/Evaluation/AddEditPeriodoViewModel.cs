using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;


namespace TrabajoFinal.ViewModels.Evaluation
{
    public class AddEditPeriodoViewModel
    {
        public Int32? PeriodoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String Nombre { get; set; }
        public void CargarDatos(EVA360Entities context, Int32? periodoId)
        {
            this.PeriodoId = periodoId;
            if (this.PeriodoId.HasValue)
            {
                var periodo = context.Periodo.FirstOrDefault(x => x.PeriodoId == PeriodoId);
                FechaInicio = periodo.FechaInicio;
                FechaFin = periodo.FechaFin;
                Nombre = periodo.Nombre;
            }
        }
    }
}