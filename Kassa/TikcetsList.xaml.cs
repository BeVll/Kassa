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
    /// Логика взаимодействия для TikcetsList.xaml
    /// </summary>
    public partial class TikcetsList : Page
    {
        private User _user;
        private Controller Controller;
        public TikcetsList()
        {
            InitializeComponent();
        }

        public TikcetsList(User user)
        {
            Controller = new Controller();
            _user = user;
            InitializeComponent();
            Profile.Text = _user.Login;
            Balance.Content = "Баланс: " + _user.Balance.ToString();
            if (_user.Type == "Cashier")
                MyTickets.Text = "Мої продажі";
            List<Sell> sells = Controller.GetSellsForUser(_user);
            var top = sells.OrderByDescending(s => s.Departure);
            listtickets.ItemsSource = top;
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
                NavigationService.Navigate(new MainUser(_user));
            else if (MenuList.SelectedIndex == 1)
                NavigationService.Navigate(new BuyTickets(_user));
            else if (MenuList.SelectedIndex == 2)
                NavigationService.Navigate(new TikcetsList(_user));
            else if (MenuList.SelectedIndex == 3)
                NavigationService.Navigate(new Schedule(_user));
            else if (MenuList.SelectedIndex == 4)
                NavigationService.Navigate(new Profile(_user));
            else if (MenuList.SelectedIndex == 5)
                NavigationService.Navigate(new AdminWin(_user));
            else if (MenuList.SelectedIndex == 6)
                System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }





        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BuyTickets(_user));
        }

        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new TikcetsList(_user));
        }

        private void StackPanel_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Schedule(_user));
        }

        private void StackPanel_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Profile(_user));
        }

        private void StackPanel_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminWin(_user));
        }

        private void StackPanel_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }



        private void StackPanel_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainUser(_user));
        }

        private void foundtrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sell sell = listtickets.SelectedItem as Sell;
            Train train = Controller.GetTrains().Where(s => s.ID == sell.Train_ID).FirstOrDefault();
            TrainUPD trainUPD = Controller.ToTrainUPD(train);
            NavigationService.Navigate(new TrainBuy(_user, trainUPD, sell.StartStat, sell.LastStat, sell));
        }
    }
}
