using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class AddInformeViewModel
    {
        public Int32? EvaluacionId { get; set; }
        public String RutaInforme { get; set; }
        public void CargarDatos(Evaluacion objEvaluacion)
        {
            RutaInforme = objEvaluacion.RutaInforme;
        }
    }
}