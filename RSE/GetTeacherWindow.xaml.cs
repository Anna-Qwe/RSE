using RSE.Core;
using RSE.Core.Helpers;
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
using System.Windows.Shapes;

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
            this.Close();
        }



        private void ButtonCall_Click(object sender, RoutedEventArgs e)
        {
            var email = TextBox_Email.Text;
            var name = TextBox_Name.Text;
                if (!UserInfoHelper.CheckUser(email, name))
            {
                MessageBox.Show("Invalid email or name");
                return;
            }
            _repo.SaveUserInfo(email, name);

        }


    }
}

