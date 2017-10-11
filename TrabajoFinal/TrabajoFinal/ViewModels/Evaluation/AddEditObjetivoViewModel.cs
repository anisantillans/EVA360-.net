using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace TrabajoFinal.ViewModels.Evaluation
{
    public class AddEditObjetivoViewModel
    {
        public Int32? ObjetivoId { get; set; }
        [Required]
        public String Nombre { get; set; } 
        [Required]
        public Int32 PeriodoId { get; set; }
        [Required]
        public Int32 Orden { get; set; }
        [Required]
        public String Descripcion { get; set; }
        public List<Periodo> LstPeriodo { get; set; } = new List<Periodo>();

        public void CargarDatos(EVA360Entities context, Int32? ObjetivoId)
        {
            LstPeriodo = context.Periodo.Where(x => x.FechaFin > DateTime.Now).ToList();
            this.ObjetivoId = ObjetivoId;
            if (this.ObjetivoId.HasValue)
            {
                var objetivo = context.Objetivo.FirstOrDefault(x => x.ObjetivoId == this.ObjetivoId);
                Nombre = objetivo.Nombre;
                PeriodoId = objetivo.PeriodoId;
                Orden = objetivo.Orden;
                Descripcion = objetivo.Descripcion;
            }
        }
        
    }
}