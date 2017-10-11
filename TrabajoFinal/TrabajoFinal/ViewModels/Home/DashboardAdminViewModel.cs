using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;
using System.Data.Entity;
using TrabajoFinal.Helpers;


namespace TrabajoFinal.ViewModels.Home
{
    public class DashboardAdminViewModel
    {
        public Int32 CantEmpleados { get; set; }
        public Int32 CantSupervisores { get; set; }
        public Int32 CantProveedores { get; set; }
        public void CargarDatos(EVA360Entities context)
        {
            CantEmpleados = context.Empleado.Count( x => x.Usuario.Estado == ConstantHelpers.ESTADO_USUARIO.ACTIVO);
            CantSupervisores = context.Supervisor.Count(x => x.Usuario.Estado == ConstantHelpers.ESTADO_USUARIO.ACTIVO);
            CantProveedores = context.Proveedor.Count(x => x.Usuario.Estado == ConstantHelpers.ESTADO_USUARIO.ACTIVO);
        }
    }
}