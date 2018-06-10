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
using RSE.Core.Models;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для Task1.xaml
    /// </summary>
    public partial class Task1 : Window
    {
        Variant variant;
        int curTaskId = 0;
        Exercise curTask;
        static bool[] answers = new bool[12];
        public Task1(int variantId)
        {
            var repo = Factory.Instance.GetRepository();
            variant = repo.Variants.FirstOrDefault(v => v.Id == variantId);
            if (variant == null)
            {
                //Something gone very bad
            }
            InitializeComponent();
        }

        private void answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            //logic in NextTask
        }

        private void InitTask()
        {
            curTask = variant.Exercises.Find(e => e.Number == curTaskId);
            task.ContentStringFormat = curTask.Description;
            answer.Text = String.Empty;
        }

        private void NextTask()
        {
            if (curTaskId >= 11)
            {
                return;
            }
            if (curTaskId >= 0)
            {
                checkAnswer();
            }
            curTaskId++;
            InitTask();
        }

        public void PrevTask()
        {
            if (curTaskId <= 0)
            {
                return;
            }
            if (curTaskId < 12)
            {
                checkAnswer();
            }
            curTaskId--;
            InitTask();
        }

        private void checkAnswer()
        {
            int ans;
            if (!int.TryParse(answer.Text, out ans))
            {
                answers[curTaskId] = false;
                return;
            }
            answers[curTaskId] = ans == curTask.Answer;
        }

        private void FinishTask()
        {
            if (curTaskId >= 0 && curTaskId < 12)
            {
                checkAnswer();
            }
            Finish finish = new Finish(answers);
            finish.InitializeComponent();
            finish.Show();
        }
    }
}
