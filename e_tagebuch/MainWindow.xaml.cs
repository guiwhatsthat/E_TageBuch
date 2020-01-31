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

		class Tagebuch {
			public string Titel;
			List<Eintrag> Eintraege;

			public Tagebuch(string t_Titel)
			{
				Titel = t_Titel;
			}

			public Eintrag erstelle_Eintrag(string t_Name, string t_Domaene) 
			{
				Eintrag Initial_Eintrag = new Eintrag(t_Name, t_Domaene);
				Eintraege.Add(Initial_Eintrag);
				return Initial_Eintrag;
			}

			public void suche_Eintrag(string t_Suchkriterium) 
			{
				//Suchen muss noch gemacht werden. Sollte am Schluss einen Eintrag oder mehrere zurückgeben
			}

		}

		class Eintrag {
			public string Name;
			DateTime Datum;
			public string Domaene;
			public string Text;
			public string Bildpfad;

			public Eintrag(string t_Name, string t_Domaene) {
				Name = t_Name;
				Domaene = t_Domaene;
				Datum = DateTime.Now;
			}
		}

		private void bntLogin_Click(object sender, RoutedEventArgs e)
		{
			Benutzer aktueller_Benutzer = new Benutzer(txtUsername.Text, PWBox.Password);
			if (aktueller_Benutzer.check_Berechtigung() == true)
			{
				//Lade tagebücher von der Disk
				//Wenn keine gefunden werden, dann eines erstellen

				Tagebuch Erstes_Tagebuch = new Tagebuch("Erstes Tagebuch");
				frmHauptSeite HauptSeite = new frmHauptSeite();
				HauptSeite.Show();
			}


		}
	}
}
