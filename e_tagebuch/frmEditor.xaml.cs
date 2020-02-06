using Microsoft.Win32;
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
        public frmHauptSeite HauptSeite;
        public frmEditor(frmHauptSeite t_HauptSeite)
        {
            HauptSeite = t_HauptSeite;
            InitializeComponent();
            HauptSeite.Hide();
            this.txtName.Text = HauptSeite.NeuerEintrag.Name;
            this.dpDatepicker.DisplayDate = HauptSeite.NeuerEintrag.Datum;
            this.lblPicPath.Content = HauptSeite.NeuerEintrag.Bildpfad;
        }

        private void BntClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            this.HauptSeite.Show();
        }

        private void BntSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Add current settings to current eintrag
                this.HauptSeite.NeuerEintrag.Name = txtName.Text;
                if (lblPicPath.Content != null)
                {
                    this.HauptSeite.NeuerEintrag.Bildpfad = lblPicPath.Content.ToString();
                }
                this.HauptSeite.NeuerEintrag.Text = txtMain.Text;
                if (dpDatepicker.Text == null)
                {
                    this.HauptSeite.NeuerEintrag.Datum = DateTime.Now.Date;
                }
                else
                {
                    this.HauptSeite.NeuerEintrag.Datum = DateTime.Parse(dpDatepicker.Text).Date;
                }
                
                //Update Listview -> Anzeige aller Eintr$ge
                this.HauptSeite.Update_Listview();
            }
            catch
            {
                MessageBox.Show("Etwas lief schief bei speicher.\nÜberprüfe deine Angaben", "e_Tagenbuch", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BntChoosePic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                lblPicPath.Content = openFileDialog.FileName;
            }
        }

        private void BntChoose_Click(object sender, RoutedEventArgs e)
        {
            frmDomaene frmDomaeneWaehlen = new frmDomaene(this);
            frmDomaeneWaehlen.Show();
        }
    }
}
