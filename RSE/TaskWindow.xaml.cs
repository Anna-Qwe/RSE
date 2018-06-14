using RSE.Core;
using RSE.Core.Interfaces;
using RSE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        

        public void UpdateAnswers(int currentExerciseId, string UserAnswer)
        {
            var currentExercise = Exercises.FirstOrDefault(e => e.Number == currentExerciseId);
            var ans = Answers.FirstOrDefault(a => a.ExerciseId == currentExercise.Number);
                
            var addAnswer = false;
            if (ans == null)
            {
                ans = new Answer();
                addAnswer = true;
            }

            ans.ExerciseId = currentExercise.Number;
            ans.UserAnswer = UserAnswer;
            ans.CorrectAnswer = currentExercise.Answer.ToString();

            if(addAnswer) Answers.Add(ans);
        }
        
        public void UpdateWindow()
        {
            var nextExercise = Exercises.FirstOrDefault(e => e.Number == _currentExerciseId);
            var ans = Answers.FirstOrDefault(a => a.ExerciseId == nextExercise.Number);

            TextBlockDesc.Text = nextExercise.Description;

            if(nextExercise.ImgURL != "")
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(nextExercise.ImgURL);
                img.EndInit();
                DescURL.Source = img;
            }
            
            if (ans != null) TextBoxAnswer.Text = ans.UserAnswer;
            else TextBoxAnswer.Text = "";
        }

        private void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            var UserAnswer = TextBoxAnswer.Text;
            UpdateWindow();
            UpdateAnswers(_currentExerciseId, UserAnswer);
            FinishWindow variantFinished = new FinishWindow(Answers);
            variantFinished.Show();
            Hide();
        }

        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            var id = _currentExerciseId;
            var UserAnswer = TextBoxAnswer.Text;
            if (_currentExerciseId == 1) return;
            else _currentExerciseId--;

            UpdateWindow();
            UpdateAnswers(id, UserAnswer);
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            var id = _currentExerciseId;
            var UserAnswer = TextBoxAnswer.Text;
            if (_currentExerciseId == Exercises.Count) return;
            else _currentExerciseId++;

            UpdateWindow();
            UpdateAnswers(id, UserAnswer);
        }
    }
}
