using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class LstPeriodoEmpleadoViewModel
    {
        public List<EmpleadoPeriodo> LstPeriodo { get; set; }
        public Int32 PeriodoId { get; set; }
        public Periodo Periodo { get; set; }
        public void CargarDatos(EVA360Entities context, Int32 periodoId)
        {
            this.PeriodoId = periodoId;
            Periodo = context.Periodo.FirstOrDefault(x => x.PeriodoId == PeriodoId);

            LstPeriodo = context.EmpleadoPeriodo.Include(x => x.Empleado).Where(x => x.PeriodoId == PeriodoId).ToList();
        }
    }
}