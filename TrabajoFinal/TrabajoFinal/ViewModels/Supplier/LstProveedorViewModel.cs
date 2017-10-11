using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoFinal.Models;

namespace TrabajoFinal.ViewModels.Supplier
{
    public class LstProveedorViewModel
    {
        public List<Proveedor> LstProveedor { get; set; } = new List<Proveedor>();
        public void CargarDatos(EVA360Entities context)
        {
            LstProveedor = context.Proveedor.ToList();
        }
    }
}