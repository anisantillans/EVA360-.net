using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;


namespace TrabajoFinal.ViewModels.Evaluation
{
    public class LstPeriodoViewModel
    {
        public List<Periodo> LstPeriodo { get; set; }
        public void CargarDatos(EVA360Entities context)
        {
            LstPeriodo = context.Periodo.ToList();
        }
    }
}