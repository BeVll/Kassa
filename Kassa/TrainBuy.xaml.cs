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
    /// Логика взаимодействия для TrainBuy.xaml
    /// </summary>
    public partial class TrainBuy : Page
    {
        private User User;
        private TrainUPD train;
        private TimeSpan totaltime;
        private string type;
        public TrainBuy()
        {
            InitializeComponent();
        }
        public TrainBuy(User user, TrainUPD trainUPD, string startst, string lastst)
        {
            train = trainUPD;
            User = user;
            
            InitializeComponent();
            TrainNum.Text = "#" + train.Number;
            FStat.Text = train.FirstStation;
            LStat.Text = train.LastStation;
            totaltime = train.Arrival - train.Departure;
            NomerTrain.Text = "Поїзд: " + train.Number;
            StartP.Text = "Пункт відправлення: " + startst;
            LastP.Text = "Пункт прибуття: " + lastst;
            TimeSt.Text = "Час відправлення: " + train.Departure.ToString();
            TimeLs.Text = "Час прибуття: " + train.Arrival.ToString();
            TimeTotal.Text = "Тривалість: " + totaltime.Hours.ToString() + ":" + totaltime.Minutes.ToString();
            Balance.Content = "Баланс: " + User.Balance.ToString();
            Diisnyi.Visibility = Visibility.Hidden;
            if (User.Type == "Cashier")
                BuyBut.Content = "Продати";
            else
                BuyBut.Content = "Купити";
            type = "Buy";
        }
        public TrainBuy(User user, TrainUPD trainUPD, string startst, string lastst, Sell sell)
        {
            train = trainUPD;
            User = user;
            InitializeComponent();
            TrainNum.Text = "#" + train.Number;
            FStat.Text = train.FirstStation;
            LStat.Text = train.LastStation;
            totaltime = sell.Arrival - sell.Departure;
            NomerTrain.Text = "Поїзд: " + train.Number;
            StartP.Text = "Пункт відправлення: " + startst;
            LastP.Text = "Пункт прибуття: " + lastst;
            TimeSt.Text = "Час відправлення: " + sell.Departure.ToString();
            TimeLs.Text = "Час прибуття: " + sell.Arrival.ToString();
            TimeTotal.Text = "Тривалість: " + totaltime.Hours.ToString() + ":" + totaltime.Minutes.ToString();
            Balance.Content = "Баланс: " + User.Balance.ToString();
            BuyBut.Visibility = Visibility.Collapsed;
            Plac.Text = sell.Plackart_Count.ToString();
            Kupe.Text = sell.Kupe_Count.ToString();
            Lux.Text = sell.Lux_Count.ToString();
            Plac.IsEnabled = false;
            Kupe.IsEnabled = false;
            Lux.IsEnabled = false;
            if (sell.Departure > DateTime.Now) {
                Diisnyi.Text = "Дійсний";
                Diisnyi.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Green);
            }
            else
            {
                Diisnyi.Text = "Недійсний";
                Diisnyi.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Red);
            }
            type = "ShowSell";
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
                NavigationService.Navigate(new MainUser(User));
            else if (MenuList.SelectedIndex == 1)
                NavigationService.Navigate(new BuyTickets(User));
            else if (MenuList.SelectedIndex == 2)
                NavigationService.Navigate(new TikcetsList(User));
            else if (MenuList.SelectedIndex == 3)
                NavigationService.Navigate(new Schedule(User));
            else if (MenuList.SelectedIndex == 4)
                NavigationService.Navigate(new Profile(User));
            else if (MenuList.SelectedIndex == 5)
                NavigationService.Navigate(new AdminWin(User));
            else if (MenuList.SelectedIndex == 6)
                System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }





        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BuyTickets(User));
        }

        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new TikcetsList(User));
        }

        private void StackPanel_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Schedule(User));
        }

        private void StackPanel_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Profile(User));
        }

        private void StackPanel_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminWin(User));
        }

        private void StackPanel_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/C start" + " " + "https://github.com/BeVll/Kassa");
        }



        private void StackPanel_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainUser(User));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double price = Convert.ToDouble(Summary.Text.Replace("грн", ""));
            if (User.Type != "Cashier")
            {
                
                if (User.Balance > price)
                {
                    Controller controller = new Controller();
                    string st = StartP.Text.Replace("Пункт відправлення: ", "");
                    string lt = LastP.Text.Replace("Пункт прибуття: ", "");
                    if (Plac.Text == string.Empty)
                        Plac.Text = "0";
                    if (Kupe.Text == string.Empty)
                        Kupe.Text = "0";
                    if (Lux.Text == string.Empty)
                        Lux.Text = "0";

                    if (controller.AddSell(Convert.ToInt32(Plac.Text), Convert.ToInt32(Kupe.Text), Convert.ToInt32(Lux.Text), User.Id, train.ID, st, lt, price, train.Departure, train.Arrival) == false)
                        MessageBox.Show("Недостатньо місць!");
                    else
                        NavigationService.Navigate(new BuyTickets(User, train, st, lt));
                }
                else
                    MessageBox.Show("Недостатньо на балансі!");
            }
            else
            {
                string st = StartP.Text.Replace("Пункт відправлення: ", "");
                string lt = LastP.Text.Replace("Пункт прибуття: ", "");
                Controller controller = new Controller();
                PrintDialog printDlg = new PrintDialog();
                if (Plac.Text == string.Empty)
                    Plac.Text = "0";
                if (Kupe.Text == string.Empty)
                    Kupe.Text = "0";
                if (Lux.Text == string.Empty)
                    Lux.Text = "0";

                if (controller.AddSell(Convert.ToInt32(Plac.Text), Convert.ToInt32(Kupe.Text), Convert.ToInt32(Lux.Text), User.Id, train.ID, st, lt, price, train.Departure, train.Arrival) == false)
                    MessageBox.Show("Недостатньо місць!");
                else
                {
                    BuyBut.Visibility = Visibility.Hidden;
                    
                    if (printDlg.ShowDialog() == true)
                    {
                        printDlg.PrintVisual(GripPrint, "Квиток");

                        NavigationService.Navigate(new BuyTickets(User, train, st, lt));

                    }
                }
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double price = 0;
            if (Plac != null && Kupe != null && Lux != null)
            {
                if (Plac.Text != String.Empty)
                    price += Convert.ToDouble(Plac.Text) * (totaltime.TotalMinutes * 0.7);
                if (Kupe.Text != String.Empty)
                    price += Convert.ToDouble(Kupe.Text) * 1.7 * (totaltime.TotalMinutes * 0.7);
                if (Lux.Text != String.Empty)
                    price += Convert.ToDouble(Lux.Text) * 2.8 * (totaltime.TotalMinutes * 0.7);
                Summary.Text = Convert.ToString(Math.Round(price, 2)) + "грн";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string st = StartP.Text.Replace("Пункт відправлення: ", "");
            string lt = LastP.Text.Replace("Пункт прибуття: ", "");
            if (type == "Buy")
                NavigationService.Navigate(new BuyTickets(User, train, st, lt));
            else
                NavigationService.Navigate(new TikcetsList(User));
        }
    }
}
