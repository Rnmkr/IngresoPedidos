using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using IngresoPedidos.Helpers;

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
        }

        private void DataGridPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPedidos.SelectedIndex == -1)
            {
                DataGridPedidos.SelectedIndex = -1;
                DataGridPedidos.ScrollIntoView(DataGridPedidos.Items[DataGridPedidos.Items.Count - 1]);
                DataGridPedidos.SelectedIndex = 3;
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

        private void CheckBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBoxComment.IsEnabled = CheckBoxAddComment.IsEnabled;
        }
    }
}