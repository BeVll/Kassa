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
    /// Логика взаимодействия для AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Page
    {
        private User user;
        private Controller controller;
        private List<StationUPD> stationUPDs1;
        public AdminWin()
        {
            InitializeComponent();
        }
        public AdminWin(User user)
        {
            
            controller = new Controller();
            this.user = user;
            InitializeComponent();
            Reset();
            Profile.Text = this.user.Login;
            Balance.Content = "Баланс: " + this.user.Balance.ToString();
        }

        private void Reset()
        {
            FirtsStat.ItemsSource = controller.GetStations();
            LastStat.ItemsSource = controller.GetStations();
            DateStart.DisplayDateStart = DateTime.Now;
            DateStart.SelectedDate = DateTime.Now;
            Plackart.Text = "0";
            Kupe.Text = "0";
            Lux.Text = "0";
            stat.ItemsSource = controller.GetStations();
            FirtsStat.DisplayMemberPath = "Name";
            LastStat.DisplayMemberPath = "Name";
            stat.DisplayMemberPath = "Name";
            FirtsStat.SelectedIndex = -1;
            LastStat.SelectedIndex = -1;
            stat.SelectedIndex = -1;
            stationUPDs1 = new List<StationUPD>();
            stationslist.Items.Clear();
            TrainNUm.Text = "";
            ArrivalTime.Text = "";
            DepartureTume.Text = "";
            UserName.ItemsSource = controller.GetUsers().Where(s => s.Type != "Admin");
            UserName.DisplayMemberPath = "Login";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private void StackPanel_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainUser(user));
        }

        private void Button_Click21(object sender, RoutedEventArgs e)
        {
            if (stat.SelectedIndex != -1 && ArrivalTime.Text != "" && DepartureTume.Text != "")
            {
                Station station = controller.GetStations().Where(s => s.Name == stat.Text).FirstOrDefault();
                DateTime dt1 = ArrivalTime.SelectedTime.Value;
                DateTime dt2 = DepartureTume.SelectedTime.Value;
                string time1 = dt1.Hour + ":" + dt1.Minute;
                string time2 = dt2.Hour + ":" + dt2.Minute;
                StationUPD stationUPD = new StationUPD(station.ID, station.Name, time1, time2, DateStart.SelectedDate.Value.ToShortDateString());
                stationUPDs1.Add(stationUPD);
                stationslist.Items.Add(stationUPD);

            }
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            if (TrainNUm.Text != string.Empty && FirtsStat.SelectedIndex != -1 && LastStat.SelectedIndex != -1 && Plackart.Text != string.Empty && Kupe.Text != string.Empty && Lux.Text != string.Empty && stationslist.Items.Count > 0)
            {
                Station stat1 = FirtsStat.SelectedItem as Station;
                Station stat2 = LastStat.SelectedItem as Station;

                TrainUPD train = new TrainUPD(TrainNUm.Text, stat1.Name, stat2.Name, stationUPDs1, DateStart.SelectedDate.Value.ToShortDateString(), Convert.ToInt32(Plackart.Text), Convert.ToInt32(Kupe.Text), Convert.ToInt32(Lux.Text), 0, DateTime.Now, DateTime.Now);
                Train train1 = controller.ToTrain(train);
                controller.AddTrain(train1);
                Reset();
            }
            else
                MessageBox.Show("Не всі поля заповнені!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (StationName.Text == string.Empty)
                MessageBox.Show("Пусте поле!");
            else
            {
                if(controller.AddStation(new Station(StationName.Text)) == false)
                    MessageBox.Show("Така станція вже існує!");
                else
                {
                    StationName.Text = string.Empty;
                }
            }
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            User user = UserName.SelectedItem as User;
            if (UserName.SelectedItem != null)
            {
                user.Type = "User";
                controller.ChangeTypeUser(user);

            }
            else
                MessageBox.Show("Оберіть користувача!");
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            User user = UserName.SelectedItem as User;
            if (UserName.SelectedItem != null)
            {
                user.Type = "Cashier";
                controller.ChangeTypeUser(user);

            }
            else
                MessageBox.Show("Оберіть користувача!");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
