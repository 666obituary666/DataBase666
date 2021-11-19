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

namespace DataBase666
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DataClass db = new DataClass();
        public Window1()
        {
            InitializeComponent();
            db.CreateConnectionString();
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {   
          int answer = db.LoginUser(TxtBoxLogin.Text, TxtBoxPassWord.Password);
            if (answer > 0)
            {
                MessageBox.Show("Авторизация прошла успешно");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Введён неверный логин или пароль");
            }
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
