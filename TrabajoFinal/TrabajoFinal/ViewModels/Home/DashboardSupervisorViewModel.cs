using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrabajoFinal.Models;
using TrabajoFinal.Helpers;

namespace TrabajoFinal.ViewModels.Home
{
    public class DashboardSupervisorViewModel
    {
        public Int32 CantEmpleados { get; set; }
       
        
        public void CargarDatos(EVA360Entities context)
        {
            CantEmpleados = context.Empleado.Count(x => x.Usuario.Estado == ConstantHelpers.ESTADO_USUARIO.ACTIVO);
            
          }
    }
}