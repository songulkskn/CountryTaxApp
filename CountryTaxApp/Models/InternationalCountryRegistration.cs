using CountryTaxApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Models
{
    // NYBUY International Tax Authority
    public class InternationalCountryRegistration
    {
        // uluslar arası anlaşmaların hangi ülkelerin dahil edildiği bilgisini tutan sınıf
        public InternationalCountryRegistration()
        {

        }

        public IReadOnlySet<Country> Countries => countries;
        private HashSet<Country> countries = new HashSet<Country>();
       
        /// <summary>
        /// Uluslararası vergilendirmenin uygulanaması için bu sisteme ülkenin register olması gerekir. Bu method ile registeration süreçlerini yönetebiliriz.
        /// </summary>
        /// <param name="country"></param>
        public void Register(Country country)
        {
            countries.Add(country);
        }

        /// <summary>
        /// Uluslararası vergilendirmenin uygulanamasından ayrılmak istyen ülkeler bu method ile sistemden çıkabilecekler
        /// </summary>
        /// <param name="country"></param>
        public void UnRegister(Country country)
        {
            countries.Remove(country);
        }

        public bool IsInternational(Company exporter, Company consignee)
        {
            var internationalCountryRepository = new InternationalCountryRepository();
            var internationalCountries = internationalCountryRepository.GetData();
            //Zaten uluslararası ülkelerin verisini getirdiğinden foreach ile atıyoruz.
            return internationalCountries.Any((x => x.Name == exporter.Country.Name && x.Name == consignee.Country.Name));

            // return Countries.Any(x => x.Name == exporter.Country.Name && x.Name == consignee.Country.Name);
        }
    }
}
