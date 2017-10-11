using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;


namespace TrabajoFinal.ViewModels.Employee
{
    public class LstEmployeeViewModel
    {
        public List<Empleado> LstEmpleado { get; set; } = new List<Empleado>();
        public void CargarDatos(EVA360Entities context)
        {
            LstEmpleado = context.Empleado.ToList();
        }
    }
}