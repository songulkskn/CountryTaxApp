using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Repositories
{
    // Uluslararası anlaşması olan ülkeler
    // verileri repository kullanarak merkezileştirme yaptık
    public class InternationalCountryRepository : IRepository<Country>
    {
      
        public List<Country> GetData()
        {
            var countryRepo = new CountryRepository();
            var countryList = countryRepo.GetData();
            var internationalCountry = new InternationalCountryRegistration();
            // burada ülkleri sisteme tanımladık
            internationalCountry.Register(country: countryList.Find(x => x.Code == "USA"));
            internationalCountry.Register(country: countryList.Find(x => x.Code == "EN"));
            return internationalCountry.Countries.ToList();
          
        }
    }
}
