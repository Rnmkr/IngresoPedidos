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

        private List<string> _productosList;

        internal List<string> GetProductos(string sm)
        {
            DataBaseContext db = new DataBaseContext();
            int idp = db.Modelos.Where(w => w.NombreModelo == sm).Select(s => s.FK_IDProducto).SingleOrDefault();
            _productosList = db.Productos.Where(w=>w.IDProducto == idp).Select(s => s.NombreProducto).ToList();
            return _productosList;
        }

        public List<string> GetProductos()
        {
            DataBaseContext db = new DataBaseContext();
            _productosList = db.Productos.Select(s => s.NombreProducto).ToList();
            return _productosList;
        }

    }
}
