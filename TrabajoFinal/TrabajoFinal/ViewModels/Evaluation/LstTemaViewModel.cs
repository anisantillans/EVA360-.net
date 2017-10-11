using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class LstTemaViewModel
    {
        public List<Tema> LstTema { get; set; } = new List<Tema>();
        public void CargarDatos(EVA360Entities context)
        {
            LstTema = context.Tema.ToList();
        }
    }
}