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
        int curTaskId = -1;
        Exercise curTask;
        static int[] answers = new int[12];
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
        }

        private void NextTask()
        {
            curTaskId++;
            curTask = variant.Exercises.Find(e => e.Number == curTaskId);
            task.ContentStringFormat = curTask.Description;
        }
    }
}
