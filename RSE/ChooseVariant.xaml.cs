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
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RSE
{
    /// <summary>
    /// Логика взаимодействия для choose_variant.xaml
    /// </summary>
    public partial class ChooseVariant : Window
    {

        IRepository _repo = Factory.Instance.GetRepository();

        public ChooseVariant()
        {
            InitializeComponent();
        }
        
        
 

        private void OpenVariant(Variant variant)
        {
            var taskWindow = new TaskWindow(variant);
           
            taskWindow.Show();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var selected = (int)ListBoxVariants.SelectedIndex;
            if (selected != -1)
            {
                var variant = _repo.Variants.FirstOrDefault(v => v.Name == selected + 1);

                if (variant != null) OpenVariant(variant);
            }
        }
    }
}

