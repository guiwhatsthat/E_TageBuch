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
    /// Interaction logic for frmHauptSeite.xaml
    /// </summary>
    public partial class frmHauptSeite : Window
    {
        MainWindow Startfenster;
        public MainWindow.Eintrag NeuerEintrag;

        public frmHauptSeite(MainWindow t_Hauptfenster)
        {
            Startfenster = t_Hauptfenster;
            InitializeComponent();
        }


        private void BntEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        public void BntNew_Click(object sender, RoutedEventArgs e)
        {
            NeuerEintrag = this.Startfenster.CurrentTagebuch.erstelle_Eintrag("Test", "test");
            frmEditor Editor = new frmEditor(this);
            Editor.Show();
        }

        public void Update_Listview()
        {
            //Entferene alle aktuelle Inhalte der Listview, welche die Einträge anzeigt
            lvwView.Items.Clear();
            foreach (var EintragToAdd in this.Startfenster.CurrentTagebuch.Eintraege)
            {
                //Add Einträge zu Listview
                var row = new { Name = EintragToAdd.Name, Datum = EintragToAdd.Datum, Domaene = EintragToAdd.Domaene, Text = EintragToAdd.Text, Bildpfad = EintragToAdd.Bildpfad };
                lvwView.Items.Add(row);

            }
        }
    }
}
