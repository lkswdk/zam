using System.ComponentModel;
using PropertyChanged;

namespace zam
{
    [ImplementPropertyChanged]
    public class Ustawienia//: INotifyPropertyChanged
    {
        public int Ilosc { get; set; } = 1;

        /*private int _ilosc = 1;

        public int Ilosc
        {
            get { return this._ilosc; }
            set
            {
                if (_ilosc != value)
                    this._ilosc = value;
                    this.NotifyPropertyChanged("Ilosc"); //przerysowanie interfejsu po zmianach
            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }*/
    }
}