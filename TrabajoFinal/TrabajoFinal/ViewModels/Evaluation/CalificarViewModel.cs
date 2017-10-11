using TrabajoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.Data.Entity;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class CalificarViewModel
    {
        public Int32? evaluacionTemaId { set; get; } /**/
        public Int32 evaluacionId { set; get; } /**/
        public Int32 temaId { set; get; }
        public Int32 puntaje { set; get; }
        public Int32 usuarioCreacionId { set; get; }
        public DateTime fechaCreacion { set; get; }

        public Int32 periodoId { set; get; }
        public String nombrePeriodo { set; get; }
        public List<Periodo> LstPeriodo { set; get; } = new List<Periodo>();
        public List<Evaluacion> LstEvaluacion { set; get; } = new List<Evaluacion>();
        public List<Tema> LstTema { set; get; } = new List<Tema>();
        public List<Objetivo> LstObjetivo { set; get; } = new List<Objetivo>();
        public List<Int32> LstPuntuacion { set; get; } = new List<Int32>();

        public void CargarDatos(EVA360Entities context, Int32? evaluacionTemaId)
        {
            this.evaluacionTemaId = evaluacionTemaId;
            if (this.evaluacionTemaId.HasValue)
            {
                var ET = context.EvalucionTema.FirstOrDefault(x => x.EvaluacionTemaId == this.evaluacionTemaId);
                evaluacionId = ET.EvaluacionId;
                temaId = ET.TemaId;
                puntaje = ET.Puntaje;
                usuarioCreacionId = ET.UsuarioCreacionId;
                fechaCreacion = ET.FechaCreacion;
            }
            LstEvaluacion = context.Evaluacion.ToList();
            LstTema = context.Tema.ToList();
            LstObjetivo = context.Objetivo.ToList();
            LstPeriodo = context.Periodo.Where(x => x.FechaInicio < DateTime.Now && x.FechaFin > DateTime.Now).ToList();
            var id = context.Periodo.FirstOrDefault(x => x.FechaInicio < DateTime.Now);
            periodoId = id.PeriodoId;
            LstObjetivo = context.Objetivo.Where(x => x.PeriodoId == periodoId).ToList();

            foreach (var item in LstObjetivo)
            {
                foreach (var tema in item.Tema.ToList())
                {
                    LstPuntuacion.Add(0);
                }
            }
        }

        public void CargarDatosCalificar(EVA360Entities context, Int32? EvaluacionId, Int32? EvaluacionTemaId)
        {
            evaluacionTemaId = EvaluacionTemaId;
            if (EvaluacionId.HasValue)
            {
                evaluacionTemaId = EvaluacionTemaId;
                evaluacionId = EvaluacionId.Value;
                var p = context.Periodo.FirstOrDefault(x => x.FechaInicio < DateTime.Now && x.FechaFin > DateTime.Now);
                nombrePeriodo = p.Nombre;
                LstObjetivo = context.Objetivo.ToList();
                foreach (var item in LstObjetivo)
                {
                    foreach (var tema in item.Tema.ToList())
                    {
                        LstPuntuacion.Add(0);
                    }
                }
            }
        }
    }
}