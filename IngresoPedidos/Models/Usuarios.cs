namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

    public class UsuariosRepository
    {
        public UsuariosRepository()
        {

        }

        public Usuarios GetUsuario(string legajo)
        {
            DataBaseContext db = new DataBaseContext();
            return db.Usuarios.Where(w => w.LegajoUsuario == legajo).Select(s => s).SingleOrDefault();
        }

        public List<Usuarios> GetListaUsuarios()
        {
            DataBaseContext db = new DataBaseContext();
            return db.Usuarios.Select(s => s).ToList();
        }

    }
}
