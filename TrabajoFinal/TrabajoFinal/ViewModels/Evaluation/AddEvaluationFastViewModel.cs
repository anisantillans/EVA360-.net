using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class AddEvaluationFastViewModel
    {
        public String Nombre { get; set; }
        public Decimal PorcentajeAvance { get; set; }
        public Int32 SupervisorId { get; set; }
        public Int32 EmpleadoId { get; set; }
        public Int32 PeriodoId { get; set; }
        public Int32 EvaluacionTemaId { get; set; }
        public Int32 TemaId { get; set; }
        public Int32 Puntaje { get; set; }
        public Int32 ObjetivoId { get; set; }
        public List<Objetivo> LstObjetivo { get; set; } = new List<Objetivo>();
        public List<Usuario> LstEmpleado { get; set; } = new List<Usuario>();
        public List<Tema> LstTema { get; set; } = new List<Tema>();

       public void CargarDatos(EVA360Entities context)
        {
            var periodo = context.Periodo.FirstOrDefault(x => x.FechaInicio <= DateTime.Now && x.FechaFin >= DateTime.Now);
            PeriodoId = periodo.PeriodoId;

            var empleadoPeriodo = context.EmpleadoPeriodo.Where(x => x.PeriodoId == PeriodoId 
                                            && x.Empleado.Evaluacion.FirstOrDefault(y => y.PeriodoId == PeriodoId) != null).ToList();

            if (empleadoPeriodo.Count() > 0)
            {
                LstEmpleado = empleadoPeriodo.Select(y => new Usuario
                {
                    UsuarioId = y.EmpleadoId,
                    Nombre = y.Empleado.Usuario.Nombre
                }).ToList();
            }

            LstObjetivo = context.Objetivo.Where(x => x.PeriodoId == PeriodoId).ToList();
        }
    }
}