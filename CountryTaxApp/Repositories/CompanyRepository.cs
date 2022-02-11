using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        // private değişkenler önüne _koyarak hangisinin field hangisinin property olduğunun anlarız.
        private List<Company> _companies = new List<Company>();
        public List<Company> GetData()
        {

            var countryRepo = new CountryRepository();
            var clist = countryRepo.GetData();

            // Hepsi Burada Türkiye
            var company1 = new Company(name: "Hepsi Burada", taxNumber: "09039324");

            company1.SetAddress(new Address
            {
                CityName = "İstanbul",
                StreetName = "Bağdat Çaddesi",
                ZipCode = "34500"
            });

           // liste içerisinden tek kayıt bulmak için find kullandık
            var tr = clist.Find(x => x.Code == "TR");
            company1.SetCountry(country:tr);

            // Ingiltere
            
            var company2 = new Company(name: "Getir ingiltere", taxNumber: "EN-34324324");

            company2.SetAddress(new Address
            {
                CityName = "Londra",
                StreetName = "Seaside Avenue",
                ZipCode = "L-TYR78"
            });

            var en = clist.Find(x => x.Code == "EN");
            company2.SetCountry(country:en);


            var company3 = new Company(name: "Trendyol", taxNumber: "09039378");

            company3.SetAddress(new Address
            {
                CityName = "İstanbul",
                StreetName = "Avcılar",
                ZipCode = "34600"
            });

            company3.SetCountry(country:tr);


            // amerika

            var company4 = new Company(name: "NY Times", taxNumber: "USA-34327324");

            company4.SetAddress(new Address
            {
                CityName = "New York",
                StreetName = "Wall Street",
                ZipCode = "NY-TYR78"
            });

            var usa = clist.Find(x => x.Code == "USA");
            company4.SetCountry(country:usa);

            _companies.Add(company1);
            _companies.Add(company2);
            _companies.Add(company3);
            _companies.Add(company4);

            return _companies;
        }
    }
}
