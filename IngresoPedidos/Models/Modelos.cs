namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Modelos
    {
        [Key]
        public int IDModelo { get; set; }

        public int FK_IDProducto { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreModelo { get; set; }

        public virtual Productos Productos { get; set; }
    }

    public class ModelosRepository
    {
        public ModelosRepository()
        {

        }

        public List<Modelos> GetModelos()
        {
            DataBaseContext db = new DataBaseContext();
            return db.Modelos.Select(s => s).ToList();
        }
    }
}
