﻿using System;
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
            //Es ist im Tool noch nicht möglich das Tagebuch zu ändern. Auch wenn dies die Klassen ermöglichen würden
            txtTagebuch.Text = Startfenster.CurrentTagebuch.Titel;
        }


        private void BntEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        public void BntNew_Click(object sender, RoutedEventArgs e)
        {
            NeuerEintrag = this.Startfenster.CurrentTagebuch.erstelle_Eintrag("Test", "Nicht definiert");
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

        private void BntShow_Click(object sender, RoutedEventArgs e)
        {
            List<MainWindow.Eintrag> Gefundeneintraege = new List<MainWindow.Eintrag>();
            if (!string.IsNullOrEmpty(txtSuche.Text))
            {
                Gefundeneintraege = this.Startfenster.CurrentTagebuch.suche_Eintrag("Text", txtSuche.Text);
            }
            else if (chkDate.IsChecked == true)
            {
                Gefundeneintraege = this.Startfenster.CurrentTagebuch.suche_Eintrag("Datum", dpSearchDate.Text);
            }
            else if (chkdateSince.IsChecked == true)
            {
                Gefundeneintraege = this.Startfenster.CurrentTagebuch.suche_Eintrag("Datum", dpRangeDate.Text);
            }
            else if (chkType.IsChecked == true)
            {
                Gefundeneintraege = this.Startfenster.CurrentTagebuch.suche_Eintrag("Domaene", cmbType.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }

            lvwView.Items.Clear();
            foreach (var EintragToAdd in Gefundeneintraege)
            {
                //Add Einträge zu Listview
                var row = new { Name = EintragToAdd.Name, Datum = EintragToAdd.Datum, Domaene = EintragToAdd.Domaene, Text = EintragToAdd.Text, Bildpfad = EintragToAdd.Bildpfad };
                lvwView.Items.Add(row);

            }
        }

        private void ChkDate_Checked(object sender, RoutedEventArgs e)
        {
            if (chkDate.IsChecked == true)
            {
                chkdateSince.IsChecked = false;
                chkType.IsChecked = false;
                txtSuche.Text = "";
            }
        }

        private void ChkType_Checked(object sender, RoutedEventArgs e)
        {
            if (chkType.IsChecked == true)
            {
                chkDate.IsChecked = false;
                chkdateSince.IsChecked = false;
                txtSuche.Text = "";
            }
        }

        private void ChkdateSince_Checked(object sender, RoutedEventArgs e)
        {
            if (chkdateSince.IsChecked == true)
            {
                chkDate.IsChecked = false;
                chkType.IsChecked = false;
                txtSuche.Text = "";
            }
        }

        private void TxtSuche_TextChanged(object sender, TextChangedEventArgs e)
        {
            chkDate.IsChecked = false;
            chkType.IsChecked = false;
            chkdateSince.IsChecked = false;
        }
    }
}
