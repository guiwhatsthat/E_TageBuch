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
    /// Interaction logic for frmDomaene.xaml
    /// </summary>
    public partial class frmDomaene : Window
    {
        frmEditor Editor;
        public frmDomaene(frmEditor t_Editor)
        {
            Editor = t_Editor;
            InitializeComponent();

            //Bereitsausgewählte Domänen anwählen
            string AktuelleDomaene = this.Editor.HauptSeite.NeuerEintrag.Domaene;
            List<CheckBox> AlleDomaenen = new List<CheckBox>();
            foreach (CheckBox CheckBoxDomaene in GridCheckBox.Children)
            {
                AlleDomaenen.Add(CheckBoxDomaene);
            }

            foreach (string Domaene in AktuelleDomaene.Split(',')) {
                foreach (CheckBox CheckBoxDomaene in GridCheckBox.Children) {
                    if ((AlleDomaenen.FindAll(Box => Box.Name == Domaene)).Count > 0)
                    {
                        CheckBoxDomaene.IsChecked = true;
                    }
                }
            }
            
        }

        //Wird benötigt um zu verhindern, dass mehr als 3 Checkboxes ausgewählt werden
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox ClickedCheckbox = (CheckBox)sender;
            List<CheckBox> AlleDomaenen = new List<CheckBox>();
            foreach (CheckBox CheckBoxDomaene in GridCheckBox.Children)
            {
                AlleDomaenen.Add(CheckBoxDomaene);
            }
            if ((AlleDomaenen.FindAll(Box => Box.IsChecked == true)).Count > 3)
            {
                ClickedCheckbox.IsChecked = false;
                MessageBox.Show("Es können nicht mehr als 3 Domänen gewählt werden", "e_Tagenbuch", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ClickedCheckbox.IsChecked = true;
            }
        }

        private void BntOk_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.ArrayList Gewaehlte = new System.Collections.ArrayList();
            foreach (CheckBox CheckBoxDomaene in GridCheckBox.Children)
            {
                if (CheckBoxDomaene.IsChecked == true)
                {
                    Gewaehlte.Add(CheckBoxDomaene.Content);
                }
            }

            this.Editor.HauptSeite.NeuerEintrag.Domaene = string.Join(",", Gewaehlte.ToArray());

            this.Close();
            Editor.Show();

        }
    }
}
