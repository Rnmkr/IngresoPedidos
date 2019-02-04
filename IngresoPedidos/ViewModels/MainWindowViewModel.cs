using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IngresoPedidos.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {

        private Usuarios _usuario;
        private List<PedidosView> _listaPedidos;
        private List<Modelos> _listaModelos;
        private List<Productos> _listaProductos;
        private PedidosView _pedidoSeleccionado;
        private Modelos _modeloSeleccionado;
        private Productos _productoSeleccionado;
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

        public Usuarios Usuario
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

        public List<PedidosView> ListaPedidos
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

        public List<Modelos> ListaModelos
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

        public List<Productos> ListaProductos
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

        public PedidosView PedidoSeleccionado
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

        public Modelos ModeloSeleccionado
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

        public Productos ProductoSeleccionado
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

