using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Microsoft.Win32;
using MessageBox = System.Windows.MessageBox;

namespace zam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Zamowienie> ZamowienieList { get; set; }
        public Ustawienia ustawienia;





        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            ZamowienieList = new ObservableCollection<Zamowienie>();

            this.ustawienia = new Ustawienia();
            this.Ilosc.DataContext = ustawienia;

            this.TypWagi.ItemsSource = Enum.GetValues(typeof (TypWagi)); //obsługa list rozwijanych
            this.TypWagi.SelectedIndex = 0;

            this.RodzajWagi.ItemsSource = Enum.GetValues(typeof (RodzajWagi));
            this.RodzajWagi.SelectedIndex = 0;

            this.Status.ItemsSource = Enum.GetValues(typeof (StatusZaawansowania));
            this.Status.SelectedIndex = 0;


        }



        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ilosc = int.Parse(this.Ilosc.Text);
                string odbiorca = this.Odbiorca.Text;
                TypWagi typ = (TypWagi) Enum.Parse(typeof (TypWagi), this.TypWagi.Text);
                RodzajWagi rodzaj = (RodzajWagi) Enum.Parse(typeof (RodzajWagi), this.RodzajWagi.Text);
                StatusZaawansowania status =
                    (StatusZaawansowania) Enum.Parse(typeof (StatusZaawansowania), this.Status.Text);
                string DataZamowienia = this.DataZamowienia.Text;
                Zamowienie zamowienie = new Zamowienie(ilosc, odbiorca, typ, rodzaj, DataZamowienia, status);
                ZamowienieList.Add(zamowienie);
            }
            catch (Exception)
            {
                MessageBox.Show("Pole Ilość Sztuk musi zawierać cyfry i nie może być puste", "Usun");
            }
        }


        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ZamowienieList.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Najpierw zaznacz aby usunąć", "Usun");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Zamowienie";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML dockument (.xml|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;
                ListToXmlFile(filePath);
            }
        }

        private void ListToXmlFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath)) //piszemy bitowo do pliku
            {
                var serializer = new XmlSerializer(typeof (ObservableCollection<Zamowienie>));
                serializer.Serialize(sw, ZamowienieList);
            }
        }

        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
            }
            if (File.Exists(filename))
            {
                XmlFileToList(filename);
            }

        }

        public void XmlFileToList(string filename)
        {
            try
            {
                using (var sr = new StreamReader(filename))
                {
                    var deserializer = new XmlSerializer(typeof (ObservableCollection<Zamowienie>));
                    ObservableCollection<Zamowienie> tmpList =
                        (ObservableCollection<Zamowienie>) deserializer.Deserialize(sr); //z pliku prosto na listę
                    

                    foreach (var item in tmpList)
                    {
                        ZamowienieList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zły format pliku lub nazwa");

            }

        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            ustawienia.Ilosc--;

        }

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            ustawienia.Ilosc++;

        }

        private void Ilosc_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TypWagi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }





    }
}
