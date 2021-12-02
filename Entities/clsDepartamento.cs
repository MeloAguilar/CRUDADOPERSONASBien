using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsDepartamento
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nombre debe tener un largo de entre 3 y 30 caracteres")]
        public string nombre { get; set; }

        public clsDepartamento()
        {
        }

        public override string ToString()
        {
            return nombre;

        }
    }
}
