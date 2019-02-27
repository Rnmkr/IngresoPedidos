using System.Windows;
using IngresoPedidos.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using IngresoPedidos.Helpers;
using System.Windows.Input;
using System.Threading;
using static IngresoPedidos.SplashScreenCustom;
using System.Reflection;
using System.Data;
using ClosedXML.Excel;
using System.Windows.Controls;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly RoutedCommand NuevoPedidoCommand = new RoutedCommand();

        //public static ISplashScreen splashScreen;
        //private ManualResetEvent ResetSplashCreated;
        //private Thread SplashThread;
        public MainWindow()
        {
            InitializeComponent();
            lblNombreUsuario.Content = "USUARIO: " + StaticData.Usuario.ApellidoUsuario + " " + StaticData.Usuario.NombreUsuario;

            StaticData.FiltroSeleccionado = "INGRESADO";
            StaticData.ListaPrincipal = StaticData.DataBaseContext.PedidoView.Where(w => w.NombreEstado == StaticData.FiltroSeleccionado).Select(s => s).ToList();
            dgPedidos.ItemsSource = StaticData.ListaPrincipal;
        }

        private void NuevoPedidoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (UserRightValidation.CanExecute("IngresarPedido"))
            {
                FormularioPedidoWindow fpv = new FormularioPedidoWindow();
                fpv.Owner = this;
                fpv.ShowDialog();

            }
        }
            

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult exitApp = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (exitApp == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open();//Implementation of open file");
        }

        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("SaveAs();//Implementation of saveAs");
        }

        private void btnNuevoPedido_Click(object sender, RoutedEventArgs e)
        {
            if (UserRightValidation.CanExecute("Ingresar Nuevo Pedido"))
            {
                FormularioPedidoWindow fpv = new FormularioPedidoWindow();
                fpv.Owner = this;
                fpv.ShowDialog();

            }
        }

        private void btnBuscarPedido_Click(object sender, RoutedEventArgs e)
        {
            dgw ddddddd = new dgw();
            ddddddd.ShowDialog();
            return;
            BusquedaWindow bw = new BusquedaWindow();
            bw.Owner = this;
            bw.ShowDialog();
            dgPedidos.ItemsSource = null;
            dgPedidos.ItemsSource = StaticData.ListaPrincipal;
        }

        private void btnCambiarContraseña_Click(object sender, RoutedEventArgs e)
        {
            CambiarContraseñaWindow ccw = new CambiarContraseñaWindow();
            ccw.Owner = this;
            ccw.ShowDialog();
        }

        private void btnFiltrarLista_Click(object sender, RoutedEventArgs e)
        {
            FiltroListaWindow flw = new FiltroListaWindow();
            flw.Owner = this;
            flw.ShowDialog();
            dgPedidos.ItemsSource = null;
            dgPedidos.ItemsSource = StaticData.ListaPrincipal;
        }

        private void CtxmnuEditar_Click(object sender, RoutedEventArgs e)
        {
            if (UserRightValidation.CanExecute("Editar Pedido"))
            {
                PedidoView pedidoSeleccionado = (PedidoView)dgPedidos.SelectedItem;
                FormularioPedidoWindow fpv = new FormularioPedidoWindow(pedidoSeleccionado);
                fpv.Owner = this;
                fpv.ShowDialog();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AgregarObservacion ao = new AgregarObservacion();
            ao.Owner = this;
            ao.ShowDialog();
        }

        private void HyperlinkAnterior_Click(object sender, RoutedEventArgs e)
        {
            var pedidoSeleccionado = dgPedidos.SelectedItem as PedidoView;
            var pedidoAnterior = StaticData.ListaPrincipal.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoAnterior).SingleOrDefault();

            if (pedidoAnterior == null)
            {
                pedidoAnterior = StaticData.DataBaseContext.PedidoView.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoAnterior).SingleOrDefault();
                MostrarPedidoPopupWindow mostrarPedidoPopUp = new MostrarPedidoPopupWindow("ANTERIOR", pedidoSeleccionado, pedidoAnterior);
                mostrarPedidoPopUp.Owner = this;
                mostrarPedidoPopUp.ShowDialog();
                if (mostrarPedidoPopUp.DialogResult == true)
                {
                    StaticData.ListaPrincipal.Add(pedidoAnterior);
                    dgPedidos.ItemsSource = null;
                    dgPedidos.ItemsSource = StaticData.ListaPrincipal;
                    dgPedidos.SelectedItem = pedidoAnterior;
                    dgPedidos.UpdateLayout();
                    dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                    dgPedidos.Focus();
                }
            }
            else
            {
                MostrarPedidoPopupWindow mostrarPedidoPopUp = new MostrarPedidoPopupWindow("ANTERIOR", pedidoSeleccionado, pedidoAnterior);
                mostrarPedidoPopUp.Owner = this;
                mostrarPedidoPopUp.ShowDialog();
                if (mostrarPedidoPopUp.DialogResult == true)
                {
                    dgPedidos.SelectedItem = pedidoAnterior;
                    dgPedidos.UpdateLayout();
                    dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                    dgPedidos.Focus();
                }
            }
        }

        private void HyperlinkSucesor_Click(object sender, RoutedEventArgs e)
        {
            var pedidoSeleccionado = dgPedidos.SelectedItem as PedidoView;
            var pedidoSucesor = StaticData.ListaPrincipal.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoSucesor).SingleOrDefault();

            if (pedidoSucesor == null)
            {
                pedidoSucesor = StaticData.DataBaseContext.PedidoView.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoSucesor).SingleOrDefault();
                MostrarPedidoPopupWindow mostrarPedidoPopUp = new MostrarPedidoPopupWindow("SUCESOR", pedidoSeleccionado, pedidoSucesor);
                mostrarPedidoPopUp.Owner = this;
                mostrarPedidoPopUp.ShowDialog();
                if (mostrarPedidoPopUp.DialogResult == true)
                {
                    StaticData.ListaPrincipal.Add(pedidoSucesor);
                    dgPedidos.ItemsSource = null;
                    dgPedidos.ItemsSource = StaticData.ListaPrincipal;
                    dgPedidos.SelectedItem = pedidoSucesor;
                    dgPedidos.UpdateLayout();
                    dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                    dgPedidos.Focus();
                }
            }
            else
            {
                MostrarPedidoPopupWindow mostrarPedidoPopUp = new MostrarPedidoPopupWindow("SUCESOR", pedidoSeleccionado, pedidoSucesor);
                mostrarPedidoPopUp.Owner = this;
                mostrarPedidoPopUp.ShowDialog();
                if (mostrarPedidoPopUp.DialogResult == true)
                {
                    dgPedidos.SelectedItem = pedidoSucesor;
                    dgPedidos.UpdateLayout();
                    dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                    dgPedidos.Focus();
                }
            }
        }

        private void OcultarMenu()
        {
            if (StaticData.FiltroSeleccionado == "PERSONALIZADA")
            {
                miAgregarPersonalizada.Visibility = Visibility.Collapsed;
                miAgregarPersonalizada.IsEnabled = false;
                miQuitarPersonalizada.Visibility = Visibility.Visible;
            }
            else
            {
                miQuitarPersonalizada.Visibility = Visibility.Collapsed;
                miQuitarPersonalizada.IsEnabled = false;
                miAgregarPersonalizada.Visibility = Visibility.Visible;
            }
        }

        private void BtnExportarPlanilla_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Lista de Pedidos"; // Default file name
            dlg.DefaultExt = ".xslx"; // Default file extension
            dlg.Filter = "Documentos Excel (.xlsx)|*.xlsx"; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;

                try
                {
                    ExportDataSet(filename);
                    MessageBox.Show("El archivo se guardó en: " + Environment.NewLine + filename, "Exportando a Excel", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("Error guardando el archivo: " + Environment.NewLine + filename, "Exportando a Excel", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void ExportDataSet(string destination)
        {
            var workbook = new XLWorkbook();
            DataTable dt;


            dt = LINQToDataTable(StaticData.ListaPrincipal.AsQueryable());


            var worksheet = workbook.Worksheets.Add("Lista Personalizada");
            worksheet.Cell(1, 1).InsertTable(dt);
            worksheet.Columns().AdjustToContents();
            worksheet.Columns(1, 1).Delete();
            workbook.SaveAs(destination);
            workbook.Dispose();
        }

        private DataTable LINQToDataTable<T>(IQueryable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));

                    }
                }
                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (UserRightValidation.CanExecute("Agregar Observacion"))
            {
                AgregarObservacion ao = new AgregarObservacion();
                ao.Owner = this;
                ao.ShowDialog();

            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (UserRightValidation.CanExecute("Ver Registro de Eventos"))
            {
                RegistroEventosWindow re = new RegistroEventosWindow();
                re.Owner = this;
                re.ShowDialog();

            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MostrarImagenWindow mi = new MostrarImagenWindow();
            mi.Owner = this;
            mi.ShowDialog();
        }
    }
}