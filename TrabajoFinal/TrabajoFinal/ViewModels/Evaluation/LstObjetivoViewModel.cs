using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class LstObjetivoViewModel
    {
        public List<Objetivo> LstObjetivo { get; set; } = new List<Objetivo>();
        public void CargarDatos(EVA360Entities context)
        {
            LstObjetivo = context.Objetivo.ToList();
        }
    }
}