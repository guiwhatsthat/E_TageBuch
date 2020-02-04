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
        frmHauptSeite HauptSeite;
        public frmEditor(frmHauptSeite t_HauptSeite)
        {
            HauptSeite = t_HauptSeite;
            InitializeComponent();
            HauptSeite.Hide();
            this.txtName.Text = HauptSeite.NeuerEintrag.Name;
            this.txtType.Text = HauptSeite.NeuerEintrag.Domaene;

            
        }

        private void BntClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            this.HauptSeite.Show();
        }

        private void BntSave_Click(object sender, RoutedEventArgs e)
        {
            //Add current settings to current eintrag
            this.HauptSeite.NeuerEintrag.Name = txtName.Text;
            this.HauptSeite.NeuerEintrag.Domaene = txtType.Text;
            this.HauptSeite.NeuerEintrag.Bildpfad = lblPicPath.Content.ToString();
            this.HauptSeite.NeuerEintrag.Text = txtMain.Text;
            //Update Listview
            this.HauptSeite.Update_Listview();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
