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

        private void toptrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TrainUPD t = toptrains.SelectedItem as TrainUPD;
            List<Station> stations = controller.GetStations();
            Station st = stations.Where(s => s.Name == t.FirstStation).FirstOrDefault();
            Station st2 = stations.Where(s => s.Name == t.LastStation).FirstOrDefault();
            StartPunkt.SelectedItem = st;
            LastPunkt.SelectedItem= st2;
            dtpicker.SelectedDate = Convert.ToDateTime(t.Data);

            

            //List<Station> sts = controller.GetStationsOnRoute(t.Stations);
            //List<Train> trs = controller.GetTrains();
            //List<List<Station>> trs_stations = new List<List<Station>>();
            //for (int i = 0; i < trs.Count; i++)
            //{
            //    trs_stations.Add(controller.GetStationsOnRoute(trs[i].Stations));
            //}
             

            //foreach(List<Station> stations1 in trs_stations)
            //{
            //    Station s = stations1.Find(s => s.Name == t.FirstStation);
            //    if (s != null)
            //    {
            //        int index = stations1.IndexOf(s);
            //        stations1.RemoveRange(0, index + 1);
            //        s = stations1.Find(s => s.Name == t.LastStation);
            //        if (s == null)
            //        {
            //            int i = trs_stations.IndexOf(stations1);
            //            trs_stations.RemoveAt(i);
            //        }
            //    }
            //    else
            //    {
            //        int i = trs_stations.IndexOf(stations1);
            //        trs.RemoveAt(i);
            //    }
            //}
            //foundtrains.ItemsSource = trs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foundtrains.ItemsSource = new List<TrainUPD>();

            DateTime dt = Convert.ToDateTime(dtpicker.SelectedDate);
            foundtrains.ItemsSource = controller.GetFoundTrains(StartPunkt.Text, LastPunkt.Text, dt.ToShortDateString());
        }
    }
}
