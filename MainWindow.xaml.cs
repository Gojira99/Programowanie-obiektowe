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
using System.Collections.ObjectModel;


namespace Restauracja
{

    public partial class MainWindow : Window
    {
        private ObservableCollection<Pracownik> Pracownicy { get; }
        private ObservableCollection<ZamowDanie> ZamowDania { get; }
        private ObservableCollection<Napoje> Napoj { get; }
        private ObservableCollection<StolikKawowy> Stolik { get; }

        public MainWindow()
        {
            InitializeComponent();
            Pracownicy = new ObservableCollection<Pracownik>();
            ZamowDania = new ObservableCollection<ZamowDanie>();
            Napoj = new ObservableCollection<Napoje>();
            Stolik = new ObservableCollection<StolikKawowy>();
            LSTPracownik.ItemsSource = Pracownicy;
            LSTMenu.ItemsSource = ZamowDania;
            LstNapoje.ItemsSource = Napoj;
            LSTStolikKawowy.ItemsSource = Stolik;
            DataContext = this;
            



        }

        public class Pracownik
        {
            public string Stanowisko { get; set; }
            public double Placa { get; set; }
            public double LiczbaGodzinPrzepracowana { get; set; }
            public double Wyplata { get; set; }
 

        }


       public abstract class Zamowienie
        {
            public string Nazwa { get; set; }
            public int Cena { get; set; }

            
        }

        public abstract class DaniaGlowne : Zamowienie
        {
            //Mozliwosc dodania Jedzenia dla wegetarian
            public string CzyWege { get; set; }
            
            
        }
        public abstract class Przystawka : DaniaGlowne
        {
            public string Rodzaj { get; set; }
            
        }
        public class ZamowDanie: Przystawka
        {
            public int Oblicz(int liczbaGosci)
            {
                return Cena * liczbaGosci;
            }

        }
        public class Napoje
        {
            public int Cena{ get; set; }
            public int LiczbaStolow { get; set; }
            public string Napoj { get; set; }
            public string Bar { get; set; }
            public string Brak { get; set; }
            public string AlkocholNaStole { get; set; }
            

   

        }
        public class StolikKawowy
        {
            public string Warwnik { get; set; }
            public string Express { get; set; }
            public string Ciasta { get; set; }
            public int Cena { get; set; }
            public string Brak { get; set; }
        }






        private void BTDodajPracownika_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy.Add(new Pracownik() { Stanowisko = CBStanowisko.Text, Placa = Convert.ToDouble(TBStawka.Text), LiczbaGodzinPrzepracowana = Convert.ToDouble(TBLiczbaGodzin.Text), Wyplata = Convert.ToDouble(TBLiczbaGodzin.Text) * Convert.ToDouble(TBStawka.Text) });
            TBLiczbaGodzin.Clear();
            TBStawka.Clear();
        }
        private void BTNNApojeICiasta_Click(object sender, RoutedEventArgs e)
        {
            // Zamowienia na dania główne, przystawki...
            if (CzyWege.SelectedItem == ITWegeNie)
            {
                if (CBDaniaGlowne.SelectedItem == IZestaw1)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 80 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
                else if (CBDaniaGlowne.SelectedItem == IZestaw2)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 100 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
                else if (CBDaniaGlowne.SelectedItem == IZestaw3)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 120 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
                else if (CBDaniaGlowne.SelectedItem == IZestaw4)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 160 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
            }
            else
            {
                if (CBDaniaGlowne.SelectedItem == IZestaw1)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 100 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
                else if (CBDaniaGlowne.SelectedItem == IZestaw2)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 120 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
                else if (CBDaniaGlowne.SelectedItem == IZestaw3)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 140 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
                else if (CBDaniaGlowne.SelectedItem == IZestaw4)
                {
                    ZamowDania.Add(new ZamowDanie() { Nazwa = CBDaniaGlowne.Text, Cena = 180 * Convert.ToInt32(TBliczbaGosci.Text), CzyWege = CzyWege.Text, Rodzaj = CBPrzystawki.Text });
                }
            }


            // NApoje i alkochole
            if (CBNapoje.SelectedItem == INNie && CBAlkochole.SelectedItem == IABrak)
            {
                Napoj.Add(new Napoje() { });
            }
            if (CBNapoje.SelectedItem == INNie && CBAlkochole.SelectedItem == IABar)
            {
                Napoj.Add(new Napoje() { Bar = CBAlkochole.Text, Cena = 450 +(20* Convert.ToInt32(TBliczbaGosci.Text))});
            }
            if (CBNapoje.SelectedItem == INNie && CBAlkochole.SelectedItem == IANaStole)
            {
                Napoj.Add(new Napoje() { AlkocholNaStole = CBAlkochole.Text, Cena = 25 * Convert.ToInt32(TBliczbaGosci.Text)});
            }
            if (CBNapoje.SelectedItem == INTAk && CBAlkochole.SelectedItem == IABar)
                Napoj.Add(new Napoje() { Napoj = CBNapoje.Text, Bar = CBAlkochole.Text, Cena = 6 * Convert.ToInt32(TBliczbaGosci.Text) + 450 + (20 * Convert.ToInt32(TBliczbaGosci.Text)) });
            if (CBNapoje.SelectedItem == INTAk && CBAlkochole.SelectedItem == IANaStole)
                Napoj.Add(new Napoje() { Napoj = CBNapoje.Text, AlkocholNaStole = CBAlkochole.Text, Cena = 6 * Convert.ToInt32(TBliczbaGosci.Text) + (25 * Convert.ToInt32(TBliczbaGosci.Text)) });
            if (CBNapoje.SelectedItem == INTAk && CBAlkochole.SelectedItem == IABrak)
                Napoj.Add(new Napoje() { Napoj = CBNapoje.Text, Brak = CBAlkochole.Text, Cena = 6 * Convert.ToInt32(TBliczbaGosci.Text)});

            //Stolik Kawowy
            if (CBSTolikKawowoy.SelectedItem == ISKCiasto)
                Stolik.Add(new StolikKawowy() { Ciasta = CBSTolikKawowoy.Text, Cena = 100});
            if (CBSTolikKawowoy.SelectedItem == ISKEkspress)
                Stolik.Add(new StolikKawowy() { Express = CBSTolikKawowoy.Text, Cena = 300 });
            if (CBSTolikKawowoy.SelectedItem == ISKWarwnik)
                Stolik.Add(new StolikKawowy() { Warwnik = CBSTolikKawowoy.Text, Cena = 70 });
            if (CBSTolikKawowoy.SelectedItem == ISKBrak)
                Stolik.Add(new StolikKawowy() { Brak = CBSTolikKawowoy.Text, Cena = 0 });




        }


        private void CBDaniaGlowne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
        }

        private void BTPokarzPracownikow_Click(object sender, RoutedEventArgs e)
        {
            lb1.Visibility = Visibility.Visible;
            lb2.Visibility = Visibility.Visible;
            lb3.Visibility = Visibility.Visible;
            TBStawka.Visibility = Visibility.Visible;
            TBLiczbaGodzin.Visibility = Visibility.Visible;
            BTDodajPracownika.Visibility = Visibility.Visible;
            LSTPracownik.Visibility = Visibility.Visible;
            CBStanowisko.Visibility = Visibility.Visible;
            SPMenuDG.Visibility = Visibility.Hidden;
            SPMEnuWybor.Visibility = Visibility.Hidden;
        }

        private void BTSchowajPracownikow_Click(object sender, RoutedEventArgs e)
        {
            lb1.Visibility = Visibility.Hidden;
            lb2.Visibility = Visibility.Hidden;
            TBStawka.Visibility = Visibility.Hidden;
            TBLiczbaGodzin.Visibility = Visibility.Hidden;
            BTDodajPracownika.Visibility = Visibility.Hidden;
            LSTPracownik.Visibility = Visibility.Hidden;
            CBStanowisko.Visibility = Visibility.Hidden;
            lb3.Visibility = Visibility.Hidden;

        }

        private void BTNMEnuPokarz_Click(object sender, RoutedEventArgs e)
        {
            SPMenuDG.Visibility = Visibility.Visible;
            SPMEnuWybor.Visibility = Visibility.Visible;
            lb1.Visibility = Visibility.Hidden;
            lb2.Visibility = Visibility.Hidden;
            TBStawka.Visibility = Visibility.Hidden;
            TBLiczbaGodzin.Visibility = Visibility.Hidden;
            BTDodajPracownika.Visibility = Visibility.Hidden;
            LSTPracownik.Visibility = Visibility.Hidden;
            CBStanowisko.Visibility = Visibility.Hidden;
            lb3.Visibility = Visibility.Hidden;
        }

        private void BTNMEnuSchowaj_Click(object sender, RoutedEventArgs e)
        {
            SPMenuDG.Visibility = Visibility.Hidden;
            SPMEnuWybor.Visibility = Visibility.Hidden;
        }

        private void GridViewColumn_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void BTNReset_Click(object sender, RoutedEventArgs e)
        {
            CBAlkochole.Text = string.Empty;
            CBDaniaGlowne.Text = string.Empty;
            CBNapoje.Text = string.Empty;
            CBPrzystawki.Text = string.Empty;
            CzyWege.Text = string.Empty;
            CBSTolikKawowoy.Text = string.Empty;
        }

        private void TBliczbaGosci_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}