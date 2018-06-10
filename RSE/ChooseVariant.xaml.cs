using RSE.Core;
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
    /// Логика взаимодействия для choose_variant.xaml
    /// </summary>
    public partial class ChooseVariant : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();

        public ChooseVariant()
        {
            InitializeComponent();
        }

        internal void OpenVariant(int variantId)
        {
            TaskWindow taskWindow = new TaskWindow ();
            taskWindow.InitializeComponent();
            taskWindow.Show();
        }
    }
}
