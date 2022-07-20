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
using System.Text.RegularExpressions;

namespace Kassa
{
    /// <summary>
    /// Логика взаимодействия для Balance.xaml
    /// </summary>
    public partial class Balance : Page
    {
        private User user;
        public Balance()
        {
            InitializeComponent();
        }
        public Balance(User user)
        {
            this.user = user;
            InitializeComponent();
            Profile.Text = this.user.Login;
            Balance2.Content = "Баланс: " + this.user.Balance.ToString();
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

        private void CountMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(CountMoney.Text == string.Empty || CountMoney.Text == "0")
            {
                komis.Text = "0";
                Summary.Text = "0грн";
            }
            else
            {
                komis.Text = Convert.ToString(Convert.ToDouble(CountMoney.Text) * 0.05);
                Summary.Text = Convert.ToString(Convert.ToDouble(CountMoney.Text) * 1.05) + "грн";
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void CountMoney_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

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

        private void StackPanel_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainUser(user));
        }

        private void StackPanel_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Profile(user));
        }
        private void StackPanel_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }
        private void StackPanel_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            if (user.Type == "Admin")
            {
                NavigationService.Navigate(new AdminWin(user));
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double price = Convert.ToDouble(CountMoney.Text);
            price = Math.Round(price, 2);
            user.Balance += price;
            Controller controller = new Controller();
            controller.ChangeTypeUser(user);
            Balance2.Content = user.Balance.ToString(); 
        }
    }
}
