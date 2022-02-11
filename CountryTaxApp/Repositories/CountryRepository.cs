using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Repositories
{
    // Country verisini döndürür.
    public class CountryRepository : IRepository<Country>
    {
        private HashSet<Country> countries = new HashSet<Country>();
        public CountryRepository()
        {
            var international1 = new Models.Tax(name: "International-TAX-001", rate: 0.45F, taxType: Models.TaxType.International);

            var international2 = new Models.Tax(name: "International-TAX-002", rate: 0.35F, taxType: Models.TaxType.International);

            // Currency list oluşturuldu
            var currencyRepo = new CurrencyRepository();
            var currencyList = currencyRepo.GetData();

            // Türkiye

            var tr = new Country(name: "Türkiye", code: "TR", currencyList.Find(x=> x.Symbol =="₺"));
            tr.AddTax(new Models.Tax(name: "KDV", rate: 0.18F, taxType: Models.TaxType.InCome));
            tr.AddTax(new Models.Tax(name: "Stopaj", rate: 0.4F, taxType: Models.TaxType.InCome));
            tr.AddTax(new Models.Tax(name: "ÖTV", rate: 0.45F, taxType: Models.TaxType.OutCome));
            tr.AddTax(international1);
            tr.AddTax(international2);

            // Ingiltere

            var en = new Country(name: "İngiltere", code: "EN", currencyList.Find(x => x.Symbol == "£"));
            en.AddTax(new Models.Tax(name: "ABS", rate: 0.12F, taxType: Models.TaxType.InCome));
            en.AddTax(new Models.Tax(name: "VBS", rate: 0.14F, taxType: Models.TaxType.InCome));
            en.AddTax(new Models.Tax(name: "TTS", rate: 0.08F, taxType: Models.TaxType.OutCome));
            en.AddTax(international1);

            // Amerika

            var usa = new Country(name: "Amerika", code: "USA", currencyList.Find(x => x.Symbol == "$"));
            usa.AddTax(new Models.Tax(name: "USBS", rate: 0.07F, taxType: Models.TaxType.InCome));
            usa.AddTax(new Models.Tax(name: "USVS", rate: 0.34F, taxType: Models.TaxType.InCome));
            usa.AddTax(new Models.Tax(name: "UTTS", rate: 0.001F, taxType: Models.TaxType.OutCome));
            usa.AddTax(international1);
            usa.AddTax(international1);

            countries.Add(tr);
            countries.Add(en);
            countries.Add(usa);

        }

        public List<Country> GetData()
        {
            return this.countries.ToList();
        }


       
    }
}
