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
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<PermisoUsuario> PermisoUsuario { get; set; }
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

            modelBuilder.Entity<Estado>()
                .Property(e => e.NombreEstado)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.FK_IDEstadoPedido);

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

            modelBuilder.Entity<Permiso>()
                .Property(e => e.NombrePermiso)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .HasMany(e => e.PermisoUsuario)
                .WithRequired(e => e.Permiso)
                .HasForeignKey(e => e.FK_IDPermiso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Modelo)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.FK_IDProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.LegajoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ApellidoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Contraseña)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.PermisoUsuario)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.FK_IDUsuario)
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
