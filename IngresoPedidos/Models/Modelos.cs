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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modelos()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        [Key]
        public int IDModelo { get; set; }

        public int FK_IDProducto { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreModelo { get; set; }

        public virtual Productos Productos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }


    public class ModelosRepository
    {

        public ModelosRepository()
        {

        }

        private List<string> _modelosList;
        public List<string> GetModelos()
        {
            DataBaseContext db = new DataBaseContext();
            _modelosList = db.Modelos.Select(s => s.NombreModelo).ToList();
            return _modelosList;
        }

    }


}
