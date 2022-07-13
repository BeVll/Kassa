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
    /// Логика взаимодействия для Regis.xaml
    /// </summary>
    public partial class Regis : Window
    {
        
        public Regis()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Controller controller = new Controller();
            if (login.Text.Length < 3)
                MessageBox.Show("Слишком короткий логин!", "Ошибка", MessageBoxButton.OK);
            else if (pass.Password.Length < 6)
                MessageBox.Show("Пароль меньше 6 символов!", "Ошибка", MessageBoxButton.OK);
            else if (pass.Password != pass2.Password)
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK);
            else
            {
                if (controller.Register(login.Text, pass.Password) == true)
                {
                    Log log = new Log();
                    log.Show();
                    Close();

                }
                else
                {
                    MessageBox.Show("Логин уже занят!", "Ошибка", MessageBoxButton.OK);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Log log = new Log();
            log.Show();
            Close();

        }
    }
}
