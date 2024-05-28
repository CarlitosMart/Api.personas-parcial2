using System;
using System.Collections.Generic;

namespace Repository.Models.BD
{
    public partial class Factura
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NroFactura { get; set; } = null!;
        public string FechaHora { get; set; } = null!;
        public string Total { get; set; } = null!;
        public string TotalIva5 { get; set; } = null!;
        public string TotalIva10 { get; set; } = null!;
        public string TotalIva { get; set; } = null!;
        public string TotalLetras { get; set; } = null!;
        public string Sucursal { get; set; } = null!;

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
