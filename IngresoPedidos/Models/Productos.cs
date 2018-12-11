using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace IngresoPedidos.Models
{
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

        private List<string> _productosList;
        public List<string> GetProductos(string m)
        {
            DataBaseContext db = new DataBaseContext();
            _productosList = db.Productos.Where(w => w.NombreProducto == m).Select(s => s.NombreProducto).ToList();
            return _productosList;
        }

    }
}
