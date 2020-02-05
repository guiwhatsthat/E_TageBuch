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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace e_tagebuch
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        public Tagebuch CurrentTagebuch;
		public MainWindow()
		{
			InitializeComponent();
		}

		//Benutzer class
		class Benutzer
		{
			public string Benutzername;
			Boolean Angemeldet = false;
			string PW;
			public List<Tagebuch> Tagebuecher;
			public Tagebuch aktuelles_Tagebuch;
			public Benutzer (string t_Benutzername, string t_PW) {
				Benutzername = t_Benutzername;
				PW = t_PW;
			}
			public Boolean check_Berechtigung () {
				if (Benutzername == "User" && PW == "Password")
				{
					Angemeldet = true;
				}
				else 
				{
					Angemeldet = false;
				}
				return Angemeldet;
			}

			public Tagebuch erstelle_Tagebuch(string t_titel) {
				Tagebuch Initial_Tagebuch = new Tagebuch("Hier den aus dem Feld vom GUI");
				Tagebuecher.Add(Initial_Tagebuch);
				return Initial_Tagebuch;
			}
		}

		public class Tagebuch {
			public string Titel;
			public List<Eintrag> Eintraege;

			public Tagebuch(string t_Titel)
			{
				Titel = t_Titel;
                Eintraege = new List<Eintrag>();
			}

			public Eintrag erstelle_Eintrag(string t_Name, string t_Domaene) 
			{
				Eintrag Initial_Eintrag = new Eintrag(t_Name, t_Domaene);
				Eintraege.Add(Initial_Eintrag);
				return Initial_Eintrag;
			}

			public List<Eintrag> suche_Eintrag(string t_Suchkriterium, string t_SuchWert) 
			{
                //Suchen muss noch gemacht werden. Sollte am Schluss einen Eintrag oder mehrere zurückgeben
                List<Eintrag> GefundeneEintraege = new List<Eintrag>();
                if (t_Suchkriterium == "Text")
                {
                    GefundeneEintraege = new List<Eintrag>(Eintraege.FindAll(Item => Item.Name.Contains(t_SuchWert)));

                }
                else if (t_Suchkriterium == "Datum")
                {
                    DateTime SucheDatum = DateTime.Parse(t_SuchWert);
                    GefundeneEintraege = new List<Eintrag>(Eintraege.FindAll(Item => Item.Datum.Date == SucheDatum.Date));
                }
                else if (t_Suchkriterium == "Domaene")
                {
                    GefundeneEintraege = new List<Eintrag>(Eintraege.FindAll(Item => Item.Domaene.Contains(t_SuchWert)));
                }
                else if (t_Suchkriterium == "Leer")
                {
                    DateTime SucheDatum = DateTime.Parse(t_SuchWert);

                    //Date range (Aus dem Internet: https://stackoverflow.com/questions/1847580/how-do-i-loop-through-a-date-range)
                    IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
                    {
                        for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                            yield return day;
                    }
                    foreach (DateTime Tag in EachDay(SucheDatum, DateTime.Now)) {
                        if ((Eintraege.FindAll(Item => Item.Datum.Date == Tag.Date).Count == 0)) {
                            GefundeneEintraege.Add(new Eintrag("Leerer Tag", "Keine", Tag));
                        }
                    }
                }
                //Gefundene Einträge zurückgeben
                return GefundeneEintraege;
            }

		}

		public class Eintrag {
			public string Name;
			public DateTime Datum;
			public string Domaene;
			public string Text;
			public string Bildpfad;

			public Eintrag(string t_Name, string t_Domaene) {
				Name = t_Name;
				Domaene = t_Domaene;
				Datum = DateTime.Now;
			}
            public Eintrag(string t_Name, string t_Domaene, DateTime t_Date)
            {
                Name = t_Name;
                Domaene = t_Domaene;
                Datum = t_Date;
            }
        }

		private void bntLogin_Click(object sender, RoutedEventArgs e)
		{
			Benutzer aktueller_Benutzer = new Benutzer(txtUsername.Text, PWBox.Password);
			if (aktueller_Benutzer.check_Berechtigung() == true)
			{
				//Lade tagebücher von der Disk
				//Wenn keine gefunden werden, dann eines erstellen

				CurrentTagebuch = new Tagebuch("Erstes Tagebuch");
				frmHauptSeite HauptSeite = new frmHauptSeite(this);
				HauptSeite.Show();
                this.Hide();
			}


		}
	}
}
