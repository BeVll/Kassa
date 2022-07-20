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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private User user;
        public Profile()
        {
            InitializeComponent();
        }
        public Profile(User user)
        {
            this.user = user;
            InitializeComponent();
            lchange.Text = this.user.Login;
            pchange.Text = this.user.Password;
            Profile1.Text = this.user.Login;
            Balance.Content = "Баланс: " + this.user.Balance.ToString();
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

        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuList.SelectedIndex == 0)
                NavigationService.Navigate(new MainUser(user));
            else if (MenuList.SelectedIndex == 1)
                NavigationService.Navigate(new BuyTickets(user));
            else if (MenuList.SelectedIndex == 2)
                NavigationService.Navigate(new TikcetsList(user));
            else if (MenuList.SelectedIndex == 3)
                NavigationService.Navigate(new Profile(user));
            else if (MenuList.SelectedIndex == 4 && user.Type == "Admin")
                NavigationService.Navigate(new AdminWin(user));
            else if (MenuList.SelectedIndex == 5)
                System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }





        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BuyTickets(user));
        }

        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new TikcetsList(user));
        }



        private void StackPanel_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Profile(user));
        }

        private void StackPanel_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            if (user.Type == "Admin")
            {
                NavigationService.Navigate(new AdminWin(user));
            }
        }

        private void StackPanel_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }



        private void StackPanel_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainUser(user));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lchange.IsEnabled == false)
            {
                lchange.IsEnabled = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (pchange.IsEnabled == false)
            {
                pchange.IsEnabled = true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            lchange.IsEnabled = false;
            pchange.IsEnabled = false;
            Controller controller = new Controller();
            if (lchange.Text.Length < 3)
                MessageBox.Show("Дуже короткий логін!", "Помилка", MessageBoxButton.OK);
            else if (controller.RegistrationCheck(lchange.Text) == false)
                MessageBox.Show("Логін вже занятий!", "Помилка", MessageBoxButton.OK);
            else if (pchange.Text.Length < 6)
                MessageBox.Show("Пароль менше 6 символів!", "Помилка", MessageBoxButton.OK);
            else
            {
                user.Login = lchange.Text;
                user.Password = pchange.Text;
                Profile1.Text = user.Login;
               
                controller.ChangeTypeUser(user);
            }
            lchange.IsEnabled = false;
            pchange.IsEnabled = false;
        }

        private void Balance_Click(object sender, RoutedEventArgs e)
        {
            if (user.Type != "Cashier")
            {
                NavigationService.Navigate(new Balance(user));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile(user));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TikcetsList(user));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
