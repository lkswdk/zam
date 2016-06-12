using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace zam
{
    /// <summary>
    /// Interaction logic for ProdWindow.xaml
    /// </summary>
    public partial class ProdWindow : Window
    {
        public ObservableCollection<Zamowienie> ZamowienieList { get; set; }

        public ProdWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ZamowienieList = new ObservableCollection<Zamowienie>();

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
                var serializer = new XmlSerializer(typeof(ObservableCollection<Zamowienie>));
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
                    var deserializer = new XmlSerializer(typeof(ObservableCollection<Zamowienie>));
                    ObservableCollection<Zamowienie> tmpList =
                        (ObservableCollection<Zamowienie>)deserializer.Deserialize(sr); //z pliku prosto na listę


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

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }


    }
}
