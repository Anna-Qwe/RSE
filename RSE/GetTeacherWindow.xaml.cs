using RSE.Core;
using RSE.Core.Interfaces;
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
using RSE.Core.Helpers;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для GetTeacherWindow.xaml
    /// </summary>
    public partial class GetTeacherWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();
        public GetTeacherWindow()
        {
            InitializeComponent();
        }
        public event Action GetCallFinish;

        private void ButtonDontWant_Click(object sender, RoutedEventArgs e)
        {
            GetCallFinish?.Invoke();
            Close();
        }

        private void ButtonCall_Click(object sender, RoutedEventArgs e)
        {
            var email = textBoxEmail.ToString();
            var name = textBoxName.ToString();
            if (!UserInfoHelper.CheckUser(email, name))
            {
                MessageBox.Show("Invalid email or name");
                return;
            }
            _repo.SaveUserInfo(email, name);
        }

        private void Close()
        {
            throw new NotImplementedException();
        }
    }
}
