using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngresoPedidos.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        private Usuarios _usuario;
        private List<PedidosView> _listaPedidos;
        private List<Modelos> _listaModelos;
        private List<Productos> _listaProductos;
        private PedidosView _pedidoSeleccionado;
        private Modelos _modeloSeleccionado;
        private Productos _productoSeleccionado;
        public string FiltroSeleccionado { get; set; }
        public List<string> _listaEstados { get; } = new List<string> { "INGRESADO", "COMPLETO", "INCOMPLETO", "AUTORIZADO", "PRODUCCION", "PAUSADO", "CANCELADO", "REPROCESADO", "DESPACHADOS" };
        public List<string> _listaFiltros { get; } = new List<string> { "INGRESADO", "COMPLETO", "INCOMPLETO", "AUTORIZADO", "PRODUCCION", "PAUSADO", "CANCELADO", "REPROCESADO", "DESPACHADOS", "ULTIMOS" };
        public string UsuarioActivo { get; set; } = "pepe";
        private UsuariosRepository _usuariosRepository = new UsuariosRepository();
        private PedidosViewRepository _pedidosViewRepository = new PedidosViewRepository();
        private ModelosRepository _modelosRepository = new ModelosRepository();
        private ProductosRepository _productosRepository = new ProductosRepository();


        public MainViewModel()
        {

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

                return _listaPedidos = _pedidosViewRepository.GetPedidosView(null);
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

        
    }
}

