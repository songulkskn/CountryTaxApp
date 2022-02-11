using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Repositories
{
    class CurrencyRepository : IRepository<Currency>
    {
        private HashSet<Currency> _currencies = new HashSet<Currency>();
        public List<Currency> GetData()
        {
            var currency1 = new Currency(name: "Türk Lirası",symbol:"₺");
            _currencies.Add(currency1);
            var currency2 = new Currency(name: "Dolar", symbol: "$");
            _currencies.Add(currency2);
            var currency3 = new Currency(name: "Euro", symbol: "€");
            _currencies.Add(currency3);
            var currency4 = new Currency(name: "Sterlin", symbol: "£");
            _currencies.Add(currency4);

            return _currencies.ToList();
        }

        
    }
}
