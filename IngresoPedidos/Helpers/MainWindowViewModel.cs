using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IngresoPedidos.ViewModels

//        public class UsuariosRepository
//{
//    public UsuariosRepository()
//    {

//    }

//    public Usuarios GetUsuario(string legajo)
//    {
//        DataBaseContext db = new DataBaseContext();
//        return db.Usuarios.Where(w => w.LegajoUsuario == legajo).Select(s => s).SingleOrDefault();
//    }

//    public List<Usuarios> GetListaUsuarios()
//    {
//        DataBaseContext db = new DataBaseContext();
//        return db.Usuarios.Select(s => s).ToList();
//    }

//}

/////////////////////////////////////////


//public class ProductosRepository
//{
//    public ProductosRepository()
//    {

//    }

//    public List<Productos> GetProductos(int modelo)
//    {
//        DataBaseContext db = new DataBaseContext();
//        return db.Productos.Where(w => w.IDProducto == modelo).Select(s => s).ToList();
//    }

//}


/////////////////////////////////////////////



//public class PedidosViewRepository
//{
//    public PedidosViewRepository()
//    {

//    }

//    public List<PedidosView> GetPedidosView(string filtro)
//    {
//        DataBaseContext db = new DataBaseContext();

//        switch (filtro)
//        {

//            case "INGRESADO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "INGRESADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "COMPLETO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "COMPLETO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "INCOMPLETO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "INCOMPLETO").OrderByDescending(o => o.IDPedido).OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "AUTORIZADO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "AUTORIZADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "PRODUCCION":
//                return db.PedidosView.Where(w => w.EstadoPedido == "PRODUCCION").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "PAUSADO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "PAUSADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "CANCELADO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "CANCELADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "FINALIZADO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "FINALIZADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "REPROCESADO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "REPROCESADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "DESPACHADO":
//                return db.PedidosView.Where(w => w.EstadoPedido == "DESPACHADO").OrderByDescending(o => o.IDPedido).Take(10000).ToList();

//            case "SUCESORES":
//                return db.PedidosView.Where(w => w.NumeroOriginal != null).OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

//            case "PERSONALIZADA":
//                return null;

//            case "BUSQUEDA":
//                return null;

//            default:
//                return db.PedidosView.OrderByDescending(o => o.IDPedido).Take(10000).ToList();
//        }
//    }
//}

/////////////////////////////////////////////////


//public class ModelosRepository
//{
//    public ModelosRepository()
//    {

//    }

//    public List<Modelos> GetModelos()
//    {
//        DataBaseContext db = new DataBaseContext();
//        return db.Modelos.Select(s => s).ToList();
//    }
//}

///////////////////////////////////////////////////////

//private static string casa = "data source=DESKTOP;initial catalog=PRODUCCION;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
//private static string exo = "data source=VM-FORREST;initial catalog=PRODUCCION;persist security info=True;user id=FORREST;password=12345678;MultipleActiveResultSets=True;App=EntityFramework";


{
    class MainWindowViewModel : ViewModelBase
    {

        private Usuario _usuario;
        private List<PedidoView> _listaPedidos;
        private List<Modelo> _listaModelos;
        private List<Producto> _listaProductos;
        private PedidoView _pedidoSeleccionado;
        private Modelo _modeloSeleccionado;
        private Producto _productoSeleccionado;
        private string _filtroSeleccionado;
        public List<string> _listaEstados { get; } = new List<string> { "AUTORIZADO", "CANCELADO", "COMPLETO", "DESPACHADO", "FINALIZADO", "INCOMPLETO", "INGRESADO", "PAUSADO", "PRODUCCION" };
        public List<string> _listaFiltros { get; } = new List<string> { "AUTORIZADO", "CANCELADO", "COMPLETO", "DESPACHADO", "FINALIZADO", "INCOMPLETO", "INGRESADO", "PAUSADO", "PRODUCCION", "REPROCESADO", "SUCESORES", "ULTIMOS 10000", "PERSONALIZADA", "BUSQUEDA" };
        public string UsuarioActivo { get; set; }
        private UsuariosRepository _usuariosRepository = new UsuariosRepository();
        private PedidosViewRepository _pedidosViewRepository = new PedidosViewRepository();
        private ModelosRepository _modelosRepository = new ModelosRepository();
        private ProductosRepository _productosRepository = new ProductosRepository();

        public MainWindowViewModel()
        {
            App.splashScreen.AddMessage("Contactando al servidor...");
            Thread.Sleep(5000);
            App.splashScreen.AddMessage("Cargando...");
            ListaPedidos = _pedidosViewRepository.GetPedidosView("INGRESADO");
            UsuarioActivo = null;
            //This will probably never actually get seen
            App.splashScreen.AddMessage("Done!");
            App.splashScreen.LoadComplete();
            
        }

        public Usuario Usuario
        {
            get
            {

                return _usuario = _usuariosRepository.GetUsuario("925");
            }

            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged("Usuario");
                }
            }
        }

        public List<PedidoView> ListaPedidos
        {
            get
            {

                return _listaPedidos;
            }

            set
            {
                if (_listaPedidos != value)
                {
                    _listaPedidos = value;
                    OnPropertyChanged("ListaPedidos");
                }
            }
        }

        public List<Modelo> ListaModelos
        {
            get
            {
                return _listaModelos;
            }

            set
            {
                if (_listaModelos != value)
                {
                    _listaModelos = value;
                    OnPropertyChanged("ListaModelos");
                }
            }
        }

        public List<Producto> ListaProductos
        {
            get
            {
                return _listaProductos;
            }

            set
            {
                if (_listaProductos != value)
                {
                    _listaProductos = value;
                    OnPropertyChanged("ListaProductos");
                }
            }
        }

        public PedidoView PedidoSeleccionado
        {
            get
            {
                return _pedidoSeleccionado;
            }

            set
            {
                if (_pedidoSeleccionado != value)
                {
                    _pedidoSeleccionado = value;
                    OnPropertyChanged("PedidoSeleccionado");
                }
            }
        }

        public Modelo ModeloSeleccionado
        {
            get
            {
                return _modeloSeleccionado;
            }

            set
            {
                if (_modeloSeleccionado != value)
                {
                    _modeloSeleccionado = value;
                    OnPropertyChanged("ModeloSeleccionado");
                }
            }
        }

        public Producto ProductoSeleccionado
        {
            get
            {
                return _productoSeleccionado;
            }

            set
            {
                if (_productoSeleccionado != value)
                {
                    _productoSeleccionado = value;
                    OnPropertyChanged("ProductoSeleccionado");
                }
            }
        }

        public string FiltroSeleccionado
        {
            get
            {
                return _filtroSeleccionado;
            }
            set
            {
                _filtroSeleccionado = value;
                OnPropertyChanged("FiltroSeleccionado");
            }
        }
    }
}

