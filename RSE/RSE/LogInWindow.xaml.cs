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
using RSE.Core;
using RSE.Core.Helpers;
using RSE.Core.Interfaces;
using RSE.Core.Models;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();
        public event Action RegistrationFinished;

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Login = TextBox_Login.Text,
                Password = PasswordHelper.GetHash(PasswordBox_Password.Password)
            };

            try
            {
                _repo.RegisterUser(user);          
                ChooseVariant chooseVariant = new ChooseVariant();
                chooseVariant.Show();
                Hide();
            }
            catch
            {
                MessageBox.Show("An error occured trying to save new user");
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_repo.Authorize(TextBox_Login.Text, PasswordBox_Password.Password))
            {
                ChooseVariant chooseVariant = new ChooseVariant();
                chooseVariant.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Incorrect login/password");
            }
        }
    }
}

