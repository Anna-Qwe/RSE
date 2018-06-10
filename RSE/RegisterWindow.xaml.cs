using RSE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RSE.Core.Helpers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RSE.Core.Interfaces;
using RSE.Core;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();
        public RegisterWindow()
        {
            InitializeComponent();
        }
        public event Action RegistrationFinished;
        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {

            var user = new User
            {
                Name = textBoxName.Text,
                Email = textBoxEmail.Text,
                Login = textBoxLogin.Text,
                Password = PasswordHelper.GetHash(passwordBox.Password)
            };
            try
            {
                _repo.RegisterUser(user);
                RegistrationFinished?.Invoke();
                Close();
            }
            catch
            {
                MessageBox.Show("An error occured trying to save new user");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            RegistrationFinished?.Invoke();
            Close();
        }
    }
}
