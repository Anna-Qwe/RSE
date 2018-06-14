using RSE.Core;
using RSE.Core.Interfaces;
using RSE.Core.Models;
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
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();
        Exercise task;
        public TaskWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            FinishWindow variantFinished = new FinishWindow();
            variantFinished.Show();
            Hide();
        }

        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            TextBoxDesc.Text = task.Description;

        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
