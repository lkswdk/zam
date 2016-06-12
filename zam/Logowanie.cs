using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace zam
{
    public enum User {kierownik, pracownik, spedytor}
    public class Logowanie
    {
         
        public User UserLog { get; set;}
    }
}