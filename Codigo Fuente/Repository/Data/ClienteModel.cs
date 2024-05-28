using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Id_banco { get; set; }
        [Required] 
        [StringLength(100, MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]\d{9}$", ErrorMessage = "Formato no coincide con lo esperado")]
        public string Celular { get; set; }
        public string Estado { get; set; }


    }
}
