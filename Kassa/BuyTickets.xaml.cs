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
        private Controller controller;
        private User user;
        private string St;
        private string Ls;
        public BuyTickets()
        {
            InitializeComponent();
            controller = new Controller();
            dtpicker.DisplayDateStart = DateTime.Now;
            List<TrainUPD> trains = controller.SetTopTrains();
            toptrains.ItemsSource = trains;    
            StartPunkt.ItemsSource = controller.GetStations();
            StartPunkt.DisplayMemberPath = "Name";
            LastPunkt.ItemsSource = controller.GetStations();
            LastPunkt.DisplayMemberPath = "Name";
            dtpicker.SelectedDate = DateTime.Now;
        }

        public BuyTickets(User user)
        {
            this.user = user;
            InitializeComponent();
            controller = new Controller();
            dtpicker.DisplayDateStart = DateTime.Now;
            List<TrainUPD> trains = controller.SetTopTrains();
            toptrains.ItemsSource = trains;
            StartPunkt.ItemsSource = controller.GetStations();
           
            StartPunkt.DisplayMemberPath = "Name";
            LastPunkt.ItemsSource = controller.GetStations();
            LastPunkt.DisplayMemberPath = "Name";
            dtpicker.SelectedDate = DateTime.Now;
            Profile.Text = this.user.Login;
            Balance.Content = "Баланс: " + this.user.Balance.ToString();
        }
        public BuyTickets(User user, TrainUPD train, string st, string ls)
        {
            this.user = user;
            InitializeComponent();
            controller = new Controller();
            dtpicker.DisplayDateStart = DateTime.Now;
            List<TrainUPD> trains = controller.SetTopTrains();
            toptrains.ItemsSource = trains;
            StartPunkt.ItemsSource = controller.GetStations();
            StartPunkt.DisplayMemberPath = "Name";
            LastPunkt.ItemsSource = controller.GetStations();
            LastPunkt.DisplayMemberPath = "Name";
            Profile.Text = user.Login;
            StartPunkt.SelectedItem = controller.GetStations().Where(s => s.Name == st).FirstOrDefault();
            LastPunkt.SelectedItem = controller.GetStations().Where(s => s.Name == ls).FirstOrDefault();
            dtpicker.SelectedDate = train.Departure;
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
                NavigationService.Navigate(new Schedule(user));
            else if (MenuList.SelectedIndex == 4)
                NavigationService.Navigate(new Profile(user));
            else if (MenuList.SelectedIndex == 5)
                NavigationService.Navigate(new AdminWin(user));
            else if (MenuList.SelectedIndex == 6)
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

        private void StackPanel_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Schedule(user));
        }

        private void StackPanel_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Profile(user));
        }

        private void StackPanel_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminWin(user));
        }

        private void StackPanel_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }



        private void StackPanel_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainUser(user));
        }

        private void toptrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TrainUPD t = toptrains.SelectedItem as TrainUPD;
            List<Station> stations = controller.GetStations();
            Station st = stations.Where(s => s.Name == t.FirstStation).FirstOrDefault();
            Station st2 = stations.Where(s => s.Name == t.LastStation).FirstOrDefault();
            StartPunkt.SelectedItem = st;
            LastPunkt.SelectedItem= st2;
            dtpicker.SelectedDate = Convert.ToDateTime(t.Data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foundtrains.ItemsSource = new List<TrainUPD>();
            St = StartPunkt.Text;
            Ls = LastPunkt.Text;
            DateTime dt = Convert.ToDateTime(dtpicker.SelectedDate);
            foundtrains.ItemsSource = controller.GetFoundTrains(StartPunkt.Text, LastPunkt.Text, dt.ToShortDateString());
        }

        private void foundtrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            NavigationService.Navigate(new TrainBuy(user, foundtrains.SelectedItem as TrainUPD, St, Ls));
        }
    }
}
