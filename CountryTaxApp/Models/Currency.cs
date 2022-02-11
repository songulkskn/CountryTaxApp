using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Models
{
    public class Currency
    {
        public string Name { get; private set; } // Dolar
        public string Symbol { get; private set; } // $

        public Currency(string name,string symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
        }


    }
}
