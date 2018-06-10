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
    public partial class choose_variant : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();

        public choose_variant()
        {
            InitializeComponent();
        }

        internal void OpenVariant(int variantId)
        {
            Task1 taskWindow = new Task1(variantId);
            taskWindow.InitializeComponent();
            taskWindow.Show();
        }
    }
}
