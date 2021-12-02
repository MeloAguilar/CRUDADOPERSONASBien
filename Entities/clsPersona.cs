using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class clsPersona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es Obligatorio"), StringLength(30, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Los apellidos son Obligatorios"), StringLength(40, MinimumLength = 2, ErrorMessage = "Los apellidos deben tener entre 2 y 40 caracteres")]
        public string Apellidos { get; set; }

        [StringLength(9, MinimumLength = 9, ErrorMessage = "Un número de teléfono español tiene 9 cifras, así que ya sabes")]
        public string Telefono { get; set; }

        [StringLength(100, ErrorMessage = "Te pasaste wey")]
        public string Direccion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public clsDepartamento Departamento { get; set; }

        public byte[] Imagen { get; set; }

        public int? IdDepartamento { get; set; }

        public clsPersona()
        {
        }
    }
}
