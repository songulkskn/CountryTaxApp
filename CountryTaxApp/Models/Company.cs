using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Models
{
    // value Object
    // kendi başına bir anlam ifade etmeyen başka bir nesen içerisinde bir anlam ifade eden yapılar için struct kullanırız. Struct ramdeki stack bölgesinde yaşıyan valutype bir değerdir. classlar ise heap de yaşalar. bu sebep ile bibirlerinden farklı yapılara sahiptirler.

    // Struct içerisinde class kullanmamız lazım. Çünkü biri (class) reference type (struct) value type çalışır. Ramde farklı bölgelerde çalışırlar.
    public struct Address
    {
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
    }

    public class Company
    {
        public string Name { get; private set; }
        public string TaxNumber { get; private set; }
        public Country Country { get; private set; }
        public Address Address { get; private set; }
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Şirket adı ve Vergi Numarası önemli
        /// </summary>
        /// <param name="name"></param>
        /// <param name="taxNumber"></param>
        public Company(string name,string taxNumber)
        {
            this.Name = name;
            this.TaxNumber = taxNumber;
        }

        /// <summary>
        /// Yeni telefon numarası için kullandık
        /// </summary>
        /// <param name="phoneNumber"></param>
        public void SetPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// şirketin lokasyon değişikliği durumunda güncel ülke lokasyonu için kullandık veya şirketin ülke bilgisini tanımlamak için kullandık
        /// </summary>
        /// <param name="country"></param>
        public void SetCountry(Country country)
        {
            this.Country = country;
        }

        /// <summary>
        /// adres değişikliğinde güncel adres bilgilerini girebilmek için kullandık veya address tanımlaması yapmak için kullandık.
        /// </summary>
        /// <param name="address"></param>
        public void SetAddress(Address address)
        {
            this.Address = address;
        }

    }
}
