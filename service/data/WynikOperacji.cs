using System;
using System.Collections.Generic;
using System.Text;

namespace data
{
    public class WynikOperacji
    {
        public bool WynikPoprawny 
        { 
            get 
            { 
                return Komunikat.Trim().Length == 0; 
            } 
        }

        public string Komunikat { get; set; }
    }
}
