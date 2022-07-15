using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kassa
{
    /// <summary>
    /// Логика взаимодействия для BuyTickets.xaml
    /// </summary>
    public partial class BuyTickets : Page
    {
        public BuyTickets()
        {
            InitializeComponent();
        }
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            MenuOpen.Visibility = Visibility.Collapsed;
            MenuClose.Visibility = Visibility.Visible;
        }

        private void MenuClose_Click(object sender, RoutedEventArgs e)
        {
            MenuOpen.Visibility = Visibility.Visible;
            MenuClose.Visibility = Visibility.Collapsed;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuList.SelectedIndex == 0)
                NavigationService.Navigate(new MainUser());
        }
    }
}
