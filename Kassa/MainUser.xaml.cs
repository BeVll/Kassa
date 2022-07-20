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
using System.ServiceProcess;

namespace Kassa
{
    /// <summary>
    /// Логика взаимодействия для MainUser.xaml
    /// </summary>
    public partial class MainUser : Page
    {
        private User _user;
        public MainUser()
        {
            InitializeComponent();
        }
        public MainUser(User user)
        {
            _user = user;
            InitializeComponent();
            Profile.Text = _user.Login;
            Balance.Content = "Баланс: " + _user.Balance.ToString();
            if (_user.Type != "Admin")
            {
                Admin.Visibility = Visibility.Hidden;
                Admin.IsEnabled = false;
            }
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

        private void ListBoxItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BuyTickets());
        }

        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuList.SelectedIndex == 0)
                NavigationService.Navigate(new MainUser(_user));
            else if (MenuList.SelectedIndex == 1)
                NavigationService.Navigate(new BuyTickets(_user));
            else if (MenuList.SelectedIndex == 2)
                NavigationService.Navigate(new TikcetsList(_user));
            else if (MenuList.SelectedIndex == 3)
                NavigationService.Navigate(new Profile(_user));
            else if (MenuList.SelectedIndex == 4 && _user.Type == "Admin")
                NavigationService.Navigate(new AdminWin(_user));
            else if (MenuList.SelectedIndex == 5)
                System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }


        private void Balance_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Type != "Cashier")
            {
                NavigationService.Navigate(new Balance(_user));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile(_user));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TikcetsList(_user));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BuyTickets(_user));
        }

        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new TikcetsList(_user));
        }


        private void StackPanel_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Profile(_user));
        }

        private void StackPanel_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            if (_user.Type == "Admin")
            {
                NavigationService.Navigate(new AdminWin(_user));
            }
        }

        private void StackPanel_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }

     

        private void StackPanel_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainUser(_user));
        }
    }
}
