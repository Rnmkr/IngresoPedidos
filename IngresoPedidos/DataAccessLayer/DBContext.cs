namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using IngresoPedidos.Helpers;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base(StaticData.ConnectionString)
        {
        }

        public virtual DbSet<Contraseña> Contraseña { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ReprocesoPedido> ReprocesoPedido { get; set; }
        public virtual DbSet<PedidoView> PedidoView { get; set; }
        public virtual DbSet<PermisoView> PermisoView { get; set; }
        public virtual DbSet<UsuarioView> UsuarioView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contraseña>()
                .Property(e => e.HashedRFID)
                .IsUnicode(false);

            modelBuilder.Entity<Contraseña>()
                .Property(e => e.HashedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .Property(e => e.NombreModelo)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Modelo)
                .HasForeignKey(e => e.FK_IDModelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.NumeroPedido)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.NumeroArticulo)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .HasOptional(e => e.ReprocesoPedido)
                .WithRequired(e => e.Pedido);

            modelBuilder.Entity<Producto>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Modelo)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.FK_IDProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PedidoView>()
                .Property(e => e.NumeroPedido)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoView>()
                .Property(e => e.NumeroArticulo)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoView>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoView>()
                .Property(e => e.NombreModelo)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoView>()
                .Property(e => e.NombreEstado)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoView>()
                .Property(e => e.NumeroPedidoAnterior)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoView>()
                .Property(e => e.NumeroPedidoSucesor)
                .IsUnicode(false);

            modelBuilder.Entity<PermisoView>()
                .Property(e => e.NombreAplicacion)
                .IsUnicode(false);

            modelBuilder.Entity<PermisoView>()
                .Property(e => e.NombrePermiso)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.LegajoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.ApellidoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.HashedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.HashedRFID)
                .IsUnicode(false);
        }
    }
}
