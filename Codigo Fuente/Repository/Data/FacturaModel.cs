using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{6}$", ErrorMessage = "Formato no coincide con lo esperado")]
        public string Nro_factura { get; set; }
        public string Fecha_hora { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Formato no coincide con lo esperado")]
        public string Total { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Formato no coincide con lo esperado")]
        public string Total_iva5 { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Formato no coincide con lo esperado")]
        public string Total_iva10 { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Formato no coincide con lo esperado")]
        public string Total_iva { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Total_letras { get; set; }
        public string Sucursal { get; set; }

    }
}
