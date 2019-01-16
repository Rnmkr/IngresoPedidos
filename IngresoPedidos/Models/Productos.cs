namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            Modelos = new HashSet<Modelos>();
        }

        [Key]
        public int IDProducto { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Modelos> Modelos { get; set; }
    }

    public class ProductosRepository
    {
        public ProductosRepository()
        {

        }

        public List<Productos> GetProductos(int modelo)
        {
            DataBaseContext db = new DataBaseContext();
            return db.Productos.Where(w => w.IDProducto == modelo).Select(s => s).ToList();
        }

    }
}
