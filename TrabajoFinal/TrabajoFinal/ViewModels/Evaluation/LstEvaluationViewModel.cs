using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class LstEvaluationViewModel
    {
        public String RutaInforme { get; set; }
        public List<Evaluacion> LstEvaluation { get; set; } = new List<Evaluacion>();
        public void CargarDatos(EVA360Entities context)
        {
            LstEvaluation = context.Evaluacion.ToList();
        }
    }
}