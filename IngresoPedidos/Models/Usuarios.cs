using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace IngresoPedidos.Models
{

    public partial class Usuarios
    {
        [Key]
        public int IDUsuario { get; set; }

        [Required]
        [StringLength(6)]
        public string LegajoUsuario { get; set; }

        [Required]
        [StringLength(25)]
        public string ApellidoUsuario { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreUsuario { get; set; }

        [StringLength(11)]
        public string HashedRFID { get; set; }

        [StringLength(48)]
        public string HashedPassword { get; set; }
    }
}
