using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Models
{
    public class Country
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        public Currency Currency { get; private set; }

        // HashSet ile çalışıyorsak IReadOnlySet interface kullanmalıyız.
        public IReadOnlySet<Tax> Taxes => taxes;

        // aynı vergi eklenemesin
        // vergiler unique olsun
        private HashSet<Tax> taxes = new HashSet<Tax>();

        public Country(string name,string code, Currency currency)
        {
            this.Name = name;
            this.Code = code;
            this.SetCurreny(currency);
        }

        /// <summary>
        /// ülkenin vergi mükellefliği
        /// </summary>
        /// <param name="tax"></param>
        public void AddTax(Tax tax)
        {
            taxes.Add(tax);
        }

        /// <summary>
        /// Ülkenin vergi muafiyet
        /// </summary>
        /// <param name="tax"></param>
        public void RemoveTax(Tax tax)
        {
            taxes.Remove(tax);
        }

        /// <summary>
        /// Currency değişirse diye yaptık
        /// </summary>
        /// <param name="currency"></param>
        public void SetCurreny(Currency currency)
        {
            this.Currency = currency;
        }
    }
}
