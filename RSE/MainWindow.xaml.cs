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

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<User> users = new List<User>();
        public static int index = -1;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Programs.GetUsers(ref users);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login, password;
            login = Login.Text;
            password = Password.Password;
            for (int i = 0; i < users.Count; i++)
            {
                string log, pass;
                log = login;
                pass = password;
                if (login == log && password == pass)
                {
                    index = i;
                    ShowInfo showWindow = new ShowInfo();
                    showWindow.InitializeComponent();
                    showWindow.Show();
                    return;
                }
                else if (login == log)
                {
                    MessageBox.Show("Wrong password");
                    return;
                }
                else
                {
                    MessageBox.Show("No such user");
                    return;
                }

            }

        }

        private void RegistrationLabelB_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string loging = Login.Text;
            string password = Password.Password;

            if (loging.Length < 6 || password.Length < 6)
            {
                MessageBox.Show("Short login and password");
                return;
            }
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == loging)
                {
                    MessageBox.Show("such login was taken");
                    return;
                }
            }
            try
            {
                Programs.NewUser(loging, password, ref users);
                MessageBox.Show("New user was created");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
}
