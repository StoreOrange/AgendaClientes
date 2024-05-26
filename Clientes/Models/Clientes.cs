using System;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class Clientes
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public required string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(40)]
        public required string Correo { get; set; }


        [Required]
        [StringLength(200)]
        public required string Dirección { get; set; }

        [StringLength(100)]
        public string Compañía { get; set; } = string.Empty;

        public string Nota { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}

