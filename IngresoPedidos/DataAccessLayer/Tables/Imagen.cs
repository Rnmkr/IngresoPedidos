namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Imagen")]
    public partial class Imagen
    {
        [Key]
        public int IDImagen { get; set; }

        [Required]
        [StringLength(50)]
        public string CodigoImagen { get; set; }

        [Required]
        [StringLength(25)]
        public string SistemaOperativo { get; set; }

        [Required]
        [StringLength(30)]
        public string VersionSistemaOperativo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [StringLength(6)]
        public string TamañoUnidad { get; set; }

        [Required]
        [StringLength(4)]
        public string VersionOffice { get; set; }

        public int FK_IDComponente { get; set; }

        public int FK_IDUsuario { get; set; }

        [Required]
        [StringLength(255)]
        public string DetallesImagen { get; set; }

        [Required]
        [StringLength(50)]
        public string ModoDeployment { get; set; }

        [Required]
        [StringLength(50)]
        public string GestorDeployment { get; set; }

        [Required]
        [StringLength(50)]
        public string VersionGestorDeployment { get; set; }

        public bool ImagenHabilitada { get; set; }

        [Required]
        [StringLength(50)]
        public string Cliente { get; set; }

        [StringLength(6)]
        public string BootMode { get; set; }

        [StringLength(6)]
        public string ArquitecturaSistemaOperativo { get; set; }

        [StringLength(10)]
        public string CompilaciónSistemaOperativo { get; set; }
    }
}
