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
using RSE.Core;
using RSE.Core.Interfaces;
using RSE.Core.Models;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для Finish.xaml
    /// </summary>
    public partial class FinishWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();

        public FinishWindow(Answer[] answers)
        {
            InitializeComponent();
            dataGridAnswer.ItemsSource = answers;

            var correctAnswers = 0;

            foreach (var ans in answers)
            {
                if (ans.UserAnswer.ToString() == ans.CorrectAnswer.ToString()) correctAnswers++;
            }

            CorrectAnswers.Text = correctAnswers.ToString();
        }
    }
}
