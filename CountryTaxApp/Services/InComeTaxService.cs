using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Services
{
    public class InComeTaxService : ITaxEvaluator
    {
        public List<Tax> TaxEvaluate(Company exporter, Company consignee)
        {
            // aynı ülke sınırları içerisinde fatura kesiliyorsa
            if (exporter.Country.Name.Equals(consignee.Country.Name))
            {
                // where ile filtereleme işlemi yaptık
                // kuşul taxtType Income TaxType.InCome
                return exporter.Country.Taxes.Where(x => x.Type == TaxType.InCome).ToList();
            }
            else
            {
                throw new Exception($"Hizmet veren {exporter.Country.Name} ile hizmet alan {consignee.Country.Name} aynı ülke sınırları içerisinde değildir. Bu Income vergilendirme uygulanamaz !");
            }
        }
    }
}
