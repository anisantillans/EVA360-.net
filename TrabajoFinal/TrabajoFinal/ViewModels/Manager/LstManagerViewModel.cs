using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels.Manager
{
    public class LstManagerViewModel
    {
        public List<Supervisor> LstSupervisor { get; set; } = new List<Supervisor>();
        public void CargarDatos(EVA360Entities context)
        {
            LstSupervisor = context.Supervisor.ToList();
        }
    }
}