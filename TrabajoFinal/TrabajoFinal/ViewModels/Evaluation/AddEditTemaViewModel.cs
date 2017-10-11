using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrabajoFinal.Models;
using System.ComponentModel.DataAnnotations;

namespace TrabajoFinal.ViewModels.Evaluation
{
    public class AddEditTemaViewModel
    {
        public Int32? TemaId { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public Int32 ObjetivoId { get; set; }
        [Required]
        public String Descripcion { get; set; }
        [Required]
        public Int32 Orden { get; set; }
        public List<Objetivo> LstObjetivo { get; set; } = new List<Objetivo>();

        public void CargarDatos(EVA360Entities context, Int32? TemaId)
        {
            this.TemaId = TemaId;
            LstObjetivo = context.Objetivo.Where(x => x.Periodo.FechaFin > DateTime.Now).ToList();
            if (this.TemaId.HasValue)
            {
                var tema = context.Tema.FirstOrDefault(x=>x.TemaId==TemaId);
                Nombre = tema.Nombre;
                ObjetivoId = tema.ObjetivoId;
                Descripcion = tema.Descripcion;
                Orden = tema.Orden;
            }
        }
    }
}