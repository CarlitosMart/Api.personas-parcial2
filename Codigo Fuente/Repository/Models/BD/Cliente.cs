using System;
using System.Collections.Generic;

namespace Repository.Models.BD
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int Id { get; set; }
        public string IdBanco { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
