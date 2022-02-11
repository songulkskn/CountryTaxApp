using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Models
{
    public class InvoiceTax
    {
        public string Name { get; private set; } // verginin adı
        public float TaxRate { get; private set; } // vergi oranı
        public decimal TaxValue { get; private set; } // vergi oranı yansıltılmış değer

       


        public InvoiceTax(string name,float taxRate, decimal itemTotalPrice)
        {
            this.Name = name;
            this.TaxRate = taxRate;
            this.CalculateTaxValue(itemTotalPrice);
        }

        /// <summary>
        /// Verginin tutarını bulduk.
        /// </summary>
        /// <param name="itemTotalPrice"></param>
        private void CalculateTaxValue(decimal itemTotalPrice)
        {
            // 1000 TL'nin 20 % sini bulduk
            this.TaxValue = itemTotalPrice * (decimal)TaxRate;
        }




    }
}
