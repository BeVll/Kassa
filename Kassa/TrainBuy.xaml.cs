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
        public TrainBuy()
        {
            InitializeComponent();
        }
        public TrainBuy(User user, TrainUPD trainUPD, string startst, string lastst)
        {
            train = trainUPD;
            User = user;
            User.Balance = 5000;
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuList.SelectedIndex == 0)
                NavigationService.Navigate(new MainUser());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double price = Convert.ToInt32(Summary.Text.Replace("грн", ""));
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
                controller.AddSell(Convert.ToInt32(Plac.Text), Convert.ToInt32(Kupe.Text), Convert.ToInt32(Lux.Text), User.Id, train.ID, st, lt);
                NavigationService.Navigate(new BuyTickets(User, train));
            }
            else
                MessageBox.Show("Недостатньо на балансі!");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double price = 0;
            if (Plac != null && Kupe != null && Lux != null)
            {
                if (Plac.Text != String.Empty)
                    price += Convert.ToDouble(Plac.Text) * (totaltime.TotalMinutes * 0.6);
                if (Kupe.Text != String.Empty)
                    price += Convert.ToDouble(Kupe.Text) * 1.6 * (totaltime.TotalMinutes * 0.6);
                if (Lux.Text != String.Empty)
                    price += Convert.ToDouble(Lux.Text) * 2.4 * (totaltime.TotalMinutes * 0.6);
                Summary.Text = price.ToString() + "грн";
            }
        }
    }
}
