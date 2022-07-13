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
using System.Windows.Shapes;

namespace Kassa
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        private Controller controller;
        public Log()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regis reg = new Regis();
            reg.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User user = controller.Login(login.Text, pass.Password);
            if (user == null)
                MessageBox.Show("Логин или пароль неверный!", "Ошибка", MessageBoxButton.OK);
            else
            {
                if(user.Type == "User")
                {
                    WindowUser wu = new WindowUser(user);
                    wu.Show();
                    Close();
                }
            }

        }
    }
}
