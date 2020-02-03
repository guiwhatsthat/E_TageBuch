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

namespace e_tagebuch
{
    /// <summary>
    /// Interaction logic for frmEditor.xaml
    /// </summary>
    public partial class frmEditor : Window
    {
        public frmEditor()
        {
            InitializeComponent();
        }

        private void BntClose_Click(object sender, RoutedEventArgs e)
        {
            frmHauptSeite HauptSeite = new frmHauptSeite();
            this.Close();
            HauptSeite.Show();
        }

        private void BntSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
