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
        List<Exercise> Exercises;
        private int _currentExerciseId = 1;
        private Answer Answer { get; set; }
        private List<Answer> Answers { get; set; }

        public TaskWindow(Variant CurrentVariant)
        {
            InitializeComponent();

            if (CurrentVariant != null)
            {
                Exercises = _repo.Exercises.Where(e => e.Variant.Id == CurrentVariant.Id).ToList();
                Answers = new List<Answer>();
                UpdateWindow();
            }
        }

        public void UpdateAnswers(Exercise currentExercise)
        {
            var userAnswer = TextBoxAnswer.Text;

            if (userAnswer != "")
            {
                var ans = new Answer
                {
                    ExerciseId = currentExercise.Id,
                    UserAnswer = userAnswer,
                    CorrectAnswer = currentExercise.Answer.ToString()
                };

                Answers.Add(ans);
                TextBoxAnswer.Text = "";
            }
        }

        public void UpdateWindow()
        {
            var currentExercise = Exercises.FirstOrDefault(e => e.Number == _currentExerciseId);

            UpdateAnswers(currentExercise);
            TextBoxDesc.Text = currentExercise.Description;
        }

        private void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
            FinishWindow variantFinished = new FinishWindow(Answers);
            variantFinished.Show();
            Hide();
        }

        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow();

            if (_currentExerciseId == 1) _currentExerciseId = 5;
            else _currentExerciseId--;
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow();

            if (_currentExerciseId == 5) _currentExerciseId = 1;
            else _currentExerciseId++;
        }
    }
}
