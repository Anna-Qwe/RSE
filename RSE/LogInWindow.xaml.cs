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

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            Hide();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_repo.Authorize(TextBox_Login.Text, PasswordBox_Password.Password))
            {
                ChooseVariant chooseVariant = new ChooseVariant();
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect login/password");
            }
        }
    }
}

