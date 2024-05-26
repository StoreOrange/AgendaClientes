using System;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        [StringLength(50)]
        public string Departamento { get; set; } = string.Empty;

        [StringLength(50)]
        public string Municipio { get; set; } = string.Empty;

        [StringLength(200)]
        public string Dirección { get; set; } = string.Empty;

        [StringLength(15)]
        public string Teléfono { get; set; } = string.Empty;

        [StringLength(15)]
        public string Celular { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(40)]
        public string Correo { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaDeIngreso { get; set; }

        [StringLength(50)]
        public string Profesión { get; set; } = string.Empty;

        [StringLength(50)]
        public string Puesto { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public double Salario { get; set; }
    }
}
