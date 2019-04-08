namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("data source=VM-FORREST;initial catalog=PRODUCCION;persist security info=True;user id=FORREST;password=12345678;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<Aplicacion> Aplicacion { get; set; }
        public virtual DbSet<Autorizacion> Autorizacion { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Componente> Componente { get; set; }
        public virtual DbSet<Despacho> Despacho { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Falla> Falla { get; set; }
        public virtual DbSet<Imagen> Imagen { get; set; }
        public virtual DbSet<Insumo> Insumo { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Observacion> Observacion { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Password> Password { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Reparacion> Reparacion { get; set; }
        public virtual DbSet<ReprocesoPedido> ReprocesoPedido { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<PermisoUsuario> PermisoUsuario { get; set; }
        public virtual DbSet<Version> Version { get; set; }
        public virtual DbSet<PedidoView> PedidoView { get; set; }
        public virtual DbSet<PermisoView> PermisoView { get; set; }
        public virtual DbSet<UsuarioView> UsuarioView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacion>()
                .Property(e => e.NombreAplicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicacion>()
                .HasMany(e => e.Permiso)
                .WithRequired(e => e.Aplicacion)
                .HasForeignKey(e => e.FK_IDAplicacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Autorizacion>()
                .HasOptional(e => e.Observacion)
                .WithRequired(e => e.Autorizacion);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.NombreCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.CodigoCategoria)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Componente)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.FK_IDCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Falla)
                .WithMany(e => e.Categoria)
                .Map(m => m.ToTable("CategoriaFalla").MapLeftKey("FK_IDCategoria").MapRightKey("FK_IDFalla"));

            modelBuilder.Entity<Componente>()
                .Property(e => e.ArticuloComponente)
                .IsUnicode(false);

            modelBuilder.Entity<Componente>()
                .Property(e => e.NombreComponente)
                .IsUnicode(false);

            modelBuilder.Entity<Componente>()
                .HasMany(e => e.Autorizacion)
                .WithRequired(e => e.Componente)
                .HasForeignKey(e => e.FK_IDComponente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Componente>()
                .HasOptional(e => e.Despacho)
                .WithRequired(e => e.Componente);

            modelBuilder.Entity<Componente>()
                .HasMany(e => e.Reparacion)
                .WithRequired(e => e.Componente)
                .HasForeignKey(e => e.FK_IDComponente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Componente>()
                .HasMany(e => e.Version)
                .WithRequired(e => e.Componente)
                .HasForeignKey(e => e.FK_IDComponente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Componente>()
                .HasMany(e => e.Modelo)
                .WithMany(e => e.Componente)
                .Map(m => m.ToTable("ModeloComponente").MapLeftKey("FK_IDComponente").MapRightKey("FK_IDModelo"));

            modelBuilder.Entity<Componente>()
                .HasMany(e => e.Orden)
                .WithMany(e => e.Componente)
                .Map(m => m.ToTable("OrdenComponente").MapLeftKey("FK_IDComponente").MapRightKey("FK_IDOrden"));

            modelBuilder.Entity<Despacho>()
                .Property(e => e.CoordenadaUbicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.NombreEstado)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.FK_IDEstadoPedido);

            modelBuilder.Entity<Falla>()
                .Property(e => e.DescripcionFalla)
                .IsUnicode(false);

            modelBuilder.Entity<Falla>()
                .HasMany(e => e.Autorizacion)
                .WithRequired(e => e.Falla)
                .HasForeignKey(e => e.FK_IDFalla)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Falla>()
                .HasMany(e => e.Reparacion)
                .WithRequired(e => e.Falla)
                .HasForeignKey(e => e.FK_IDFalla)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.CodigoImagen)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.SistemaOperativo)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.VersionSistemaOperativo)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.TamañoUnidad)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.VersionOffice)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.DetallesImagen)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.ModoDeployment)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.GestorDeployment)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.VersionGestorDeployment)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.BootMode)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.ArquitecturaSistemaOperativo)
                .IsUnicode(false);

            modelBuilder.Entity<Imagen>()
                .Property(e => e.CompilaciónSistemaOperativo)
                .IsUnicode(false);

            modelBuilder.Entity<Insumo>()
                .Property(e => e.DescripcionInsumo)
                .IsUnicode(false);

            modelBuilder.Entity<Insumo>()
                .Property(e => e.CoordenadaUbicacionInsumo)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .Property(e => e.NombreModelo)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Modelo)
                .HasForeignKey(e => e.FK_IDModelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Observacion>()
                .Property(e => e.ObservacionAutorizacion)
                .IsUnicode(false);

            modelBuilder.Entity<Orden>()
                .Property(e => e.CodigoOrden)
                .IsUnicode(false);

            modelBuilder.Entity<Password>()
                .Property(e => e.HashedRFID)
                .IsUnicode(false);

            modelBuilder.Entity<Password>()
                .Property(e => e.HashedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Password>()
                .Property(e => e.HashSalt)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.NumeroPedido)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.NumeroArticulo)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Autorizacion)
                .WithRequired(e => e.Pedido)
                .HasForeignKey(e => e.FK_IDPedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pedido>()
                .HasOptional(e => e.ReprocesoPedido)
                .WithRequired(e => e.Pedido);

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

            modelBuilder.Entity<Reparacion>()
                .Property(e => e.NumeroSerieEquipo)
                .IsUnicode(false);

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
                .HasMany(e => e.Autorizacion)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.FK_IDUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Password)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Reparacion)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.FK_IDUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.PermisoUsuario)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.FK_IDUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Version>()
                .Property(e => e.VersionComponente)
                .IsUnicode(false);

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
