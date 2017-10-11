using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class AddEditPeriodoEmpleadoViewModel
    {
        [Display(Name ="Código Empleado")]
        public Int32 EmpleadoId { get; set; }
        public Int32? PeriodoId { get; set; } 
        public Int32? EmpleadoPeriodoId { get; set; }

        public Periodo Periodo { get; set; }
        public List<Usuario> LstUsuario { get; set; } = new List<Usuario>();
        public List<Int32> LstEmpleadosInscritos = new List<Int32>();
        public void CargarDatos(EVA360Entities context, Int32? periodoId, Int32? empleadoPeriodoId)
        {
            this.EmpleadoPeriodoId = empleadoPeriodoId;
            this.PeriodoId = periodoId;

            Periodo = context.Periodo.FirstOrDefault(x => x.PeriodoId == PeriodoId);

            LstEmpleadosInscritos = context.EmpleadoPeriodo.Where(x => x.PeriodoId == PeriodoId).Select(x => x.EmpleadoId).ToList();
            
            LstUsuario = context.Usuario.Where( x => x.Empleado != null 
            && LstEmpleadosInscritos.Contains(x.Empleado.EmpleadoId) == false).ToList();

            if (EmpleadoPeriodoId.HasValue)
            {
                var empleadoPeriodo = context.EmpleadoPeriodo.FirstOrDefault( x => x.EmpleadoPeriodoId == EmpleadoPeriodoId);
                EmpleadoId = empleadoPeriodo.EmpleadoId;
                PeriodoId = empleadoPeriodo.PeriodoId;
            }
        }
    }
}