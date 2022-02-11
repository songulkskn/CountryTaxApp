using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Services
{
    public class InternationalTaxService : ITaxEvaluator
    {
        private InternationalCountryRegistration _InternationalCountryRegistration;

        public InternationalTaxService(InternationalCountryRegistration internationalCountryRegistration)
        {
            _InternationalCountryRegistration = internationalCountryRegistration;
        }


        /// <summary>
        /// her iki Şirket International Country Registration içerisinde var mı?
        /// Ülkeye tanımlanlanmış vergilerden International Type olanları filiterelemeliyiz.
        /// Bunun dışında aynı zamanda inCome vergileride ekletmemiz gerekiyor.
        /// </summary>
        /// <param name="exporter"></param>
        /// <param name="consignee"></param>
        /// <returns></returns>
        public List<Tax> TaxEvaluate(Company exporter, Company consignee)
        {
            // Any liste içerisindeki tüm koşullar sağlanırsa true döner.
            bool isInternationalCompanies = _InternationalCountryRegistration.IsInternational(exporter, consignee);

            if(exporter.Country.Name == consignee.Country.Name)
            {
                throw new Exception($"Hizmet veren: {exporter.Name} ile Hizmet alan {consignee.Name} şirketlerinden arasında Income vergilendirme uygulanabilir");
            }
            else if (isInternationalCompanies)
            {
                return exporter.Country.Taxes.Where(x => x.Type == TaxType.International && x.Type == TaxType.InCome).ToList();
            }
            else
            {
                throw new Exception($"Hizmet veren: {exporter.Name} yada Hizmet alan {consignee.Name} şirketlerinden birisi uluslararası anlaşmaya kayıt olmamıştır!");
            }
            
        }
    }
}
