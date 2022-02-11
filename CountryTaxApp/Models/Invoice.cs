using CountryTaxApp.Repositories;
using CountryTaxApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Models
{
    /// <summary>
    /// Faturanın doğru bir formatta oluşması için Fatura kesen şirketlerin adress ve country bilgilerin set edilmiş olması gerekir.
    /// </summary>
    public class Invoice
    {
        public  Company Exporter { get; private set; } // hizmet sunan
        public Company Consignee { get; private set; } // Hizmet alan

        public string InvoiceNumber { get; private set; }
        public string FormattedInvoiceDate { get; private set; }

        public decimal TotalPrice { get; private set; }
        public decimal ItemTotalPrice { get; private set; } // CommondityItems total price alanı için kullandık. Vergileri bu fiyata ekleyip InvoicePrice yani total Price bulacağız. Veriglendirmelerin vergi oranlarına göre fiyat karşılıkları bu alan üzerinden hesaplanır.


        private List<Commondity> commondities = new List<Commondity>();
        public IReadOnlyList<Commondity> Commondities => commondities;

        private List<InvoiceTax> invoiceTaxes = new List<InvoiceTax>();
        public IReadOnlyList<InvoiceTax> InvoiceTaxes => invoiceTaxes;

        

        /// <summary>
        /// Fatura oluşturmak için gerekli zorunlu alanlar
        /// </summary>
        /// <param name="exporter"></param>
        /// <param name="consignee"></param>
        public Invoice(Company exporter, Company consignee)
        {
            this.ValidateCompanyInformation(exporter);
            this.ValidateCompanyInformation(consignee);
            this.Exporter = exporter;
            this.Consignee = consignee;
            this.InvoiceNumber = Guid.NewGuid().ToString();
            this.FormattedInvoiceDate = DateTime.Now.ToShortDateString();
            
        }

        /// <summary>
        /// Fatura kesen ülkenin ulgulaması gereken vergiler.
        /// </summary>
        /// <param name="taxType"></param>
        private void SetCountryTaxes(TaxType taxType)
        {
            var internationalRegisteration = new InternationalCountryRegistration();
            ITaxEvaluator taxService = null;
            //Zaten uluslararası ülkelerin verisini getirdiğinden foreach ile atıyoruz.
            /*internationalCountrys.ForEach(country =>
            {
                internationalRegisteration.Register(country);
            });
            */

            //İngiltere -Amerika arasında international, Türkiye-Türkiye Income Türkiye - İngiltere OutCome vergilendirme yapılır.
            #region EskiKod

            #endregion
            //var internationalRegisteration = new InternationalCountryRegistration();
            //internationalRegisteration.Register(

            //    new Country(
            //        name: "Türkiye", 
            //        code: "TR", 
            //        currency: new Currency(name:"Türk Lirası",symbol:"₺")));
            //internationalRegisteration.Register(
            //    new Country(
            //        name: "Almanya", 
            //        code: "DEU",
            //        currency: new Currency(name:"Euro",symbol:"€")
            //        ));



            switch (taxType)
            {
                case TaxType.International:
                    taxService = new InternationalTaxService(internationalRegisteration);
                    break;
                case TaxType.InCome:
                    taxService = new InComeTaxService();
                    break;
                case TaxType.OutCome:
                    taxService = new OutComeTaxService(internationalRegisteration);
                    break;
                default:
                    break;
            }

            var countryTaxes = taxService.TaxEvaluate(this.Exporter, this.Consignee);

            TotalPrice = ItemTotalPrice;

            countryTaxes.ForEach(a =>
            {
                var invoiceTax = new InvoiceTax(name: a.Name, taxRate: a.Rate, itemTotalPrice: ItemTotalPrice);
                invoiceTaxes.Add(invoiceTax);
               
                TotalPrice += invoiceTax.TaxValue;
            });
        }

        private void ValidateCompanyInformation(Company company)
        {
            if(company != null)
            {
                if (company.Address.Equals(default(Address)))
                {
                    throw new Exception("Adres bilgilerini girmeden fatura kesemezsiniz");
                }

                if(company.Country == null)
                {
                    throw new Exception("şirkete ait ülke bilgisi girilmeden fatura kesemezsiniz");
                }
            }
            else
            {
                throw new Exception("şirket bilgisi tanımlamalısınız");
            } 
        }

        public void AddCommodityItem(Commondity commondity)
        {
            commondity.SetSequenceNumber(commondities.Count + 1);
            commondities.Add(commondity);
            this.ItemTotalPrice += commondity.ListPrice;
        }

        public void CalculateInvoice(TaxType taxType)
        {
            this.SetCountryTaxes(taxType);
        }
    }
}
