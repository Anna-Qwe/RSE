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
using System.Data;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для Finish.xaml
    /// </summary>
    public partial class FinishWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();

        public FinishWindow(List<Answer> answers)
        {
            InitializeComponent();
            DataTable table = new DataTable();

            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "User Answer";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Correct Answer";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);


            var correctAnswers = 0;

            foreach (var ans in answers)
            {
                row = table.NewRow();
                row["id"] = ans.ExerciseId;
                row["User Answer"] = ans.UserAnswer;
                row["Correct Answer"] = ans.CorrectAnswer;
                table.Rows.Add(row);

                if (ans.UserAnswer.ToString() == ans.CorrectAnswer.ToString()) correctAnswers++;
            }
            dataGridAnswer.DataContext = table.DefaultView;

            TextBlockCorrectAns.Text = correctAnswers.ToString();
        }
        
        private void ButtonAnotherVariant_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void ButtonFindTeacher_Click(object sender, RoutedEventArgs e)
        {
            var window = new GetTeacherWindow();
            window.Show();

            Hide();
        }
    }
}
