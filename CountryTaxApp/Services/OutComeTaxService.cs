using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Services
{
    public class OutComeTaxService : ITaxEvaluator
    {

        private InternationalCountryRegistration _InternationalRegistration;
        public OutComeTaxService(InternationalCountryRegistration internationalRegistration)
        {
            _InternationalRegistration = internationalRegistration;
        }
        public List<Tax> TaxEvaluate(Company exporter, Company consignee)
        {
            // aynı ülke sınırları içerisindeler değiler ise
            if (!exporter.Country.Name.Equals(consignee.Country.Name))
            {
                if(_InternationalRegistration.IsInternational(exporter,consignee))
                {
                    throw new Exception($"Hizmet veren {exporter.Name} ile hizmet alan {consignee.Name} arasında uluslararası bir sözleşme bulunmaktadır. Bu vergilendirme sistemini uygulayamazsınız !");
                }
                else
                {
                    return exporter.Country.Taxes.Where(x => x.Type == TaxType.OutCome).ToList();
                }
            }
            else
            {
                throw new Exception($"Hizmet veren {exporter.Name} ile hizmet alan {consignee.Name} Income vergilendirme uygulanabilir. Outcome vergilendirme uygulayamazsınız !");
            }
        }
    }
}
