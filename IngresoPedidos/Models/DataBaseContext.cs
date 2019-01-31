namespace IngresoPedidos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBaseContext : DbContext
    {
        //private static string casa = "data source=DESKTOP;initial catalog=PRODUCCION;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private static string exo = "data source=VM-FORREST;initial catalog=PRODUCCION;persist security info=True;user id=FORREST;password=12345678;MultipleActiveResultSets=True;App=EntityFramework";

        public DataBaseContext()
            : base(exo)
        {
        }

        public virtual DbSet<Modelos> Modelos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<PedidosView> PedidosView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modelos>()
                .Property(e => e.NombreModelo)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.Modelos)
                .WithRequired(e => e.Productos)
                .HasForeignKey(e => e.FK_IDProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.LegajoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.ApellidoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.HashedRFID)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.HashedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosView>()
                .Property(e => e.NumeroPedido)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosView>()
                .Property(e => e.NombreModelo)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosView>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosView>()
                .Property(e => e.Articulo)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosView>()
                .Property(e => e.EstadoPedido)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosView>()
                .Property(e => e.NumeroReproceso)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosView>()
                .Property(e => e.NumeroOriginal)
                .IsUnicode(false);
        }
    }
}
