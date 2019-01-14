using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbFiltros.SelectedIndex = 2;
            //LabelPages.Text = DataGridPedidos.Items.Count.ToString();
        }

        private void DataGridPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPedidos.SelectedIndex > 0)
            {
                //DataGridPedidos.ScrollIntoView(DataGridPedidos.Items[DataGridPedidos.Items.Count - 1]); //scroll to last
                //DataGridPedidos.UpdateLayout();
                DataGridPedidos.ScrollIntoView(DataGridPedidos.SelectedItem);
            }
        }

        private void MenuItemClicked(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            if (menuItem.IsChecked)
            {
                foreach (var item in Helpers.MenuItemExtensions.ElementToGroupNames)
                {
                    if (item.Key != menuItem && item.Value == Helpers.MenuItemExtensions.GetGroupName(menuItem))
                    {
                        item.Key.IsChecked = false;
                    }
                }
            }
            else // it's not possible for the user to deselect an item
            {
                menuItem.IsChecked = true;
            }
        }

        //private void CheckBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (TextBoxComment.IsFocused)
        //    {

        //    }
        //}

        private void CheckBoxComment_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxComment.Focus();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Views.GridPagingWindow gpw = new Views.GridPagingWindow();
            gpw.Show();
        }

        private void DataGridPedidos_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataGridPedidos.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(DataGridPedidos, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
                DataGridPedidos.SelectedIndex = -1;
                DataGridPedidos.SelectedItem = null;
            }
        }

        private void CbFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}