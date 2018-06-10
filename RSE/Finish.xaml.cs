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
using RSE.Core.Models;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для Finish.xaml
    /// </summary>
    public partial class Finish : Window
    {
        public Finish(bool[] correctAnswers)
        {
            InitializeComponent();
            TextBox_Answer.Text = correctAnswers.Where(a => a).Count().ToString();
        }
    }
}
