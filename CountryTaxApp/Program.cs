using CountryTaxApp.Models;
using CountryTaxApp.Repositories;
using System;

namespace CountryTaxApp
{
    // Domain Driven Desing Nedir (Entity,ValueObject,Aggregate, Anemic Model, Domain Nedir?)
    // Data Driven Design Nedir
    class Program
    {
        static void Main(string[] args)
        {
            // repository kullanımı
            //var cRepo = new CountryRepository();
            //var countryList = cRepo.GetData();

            var companyRepo = new CompanyRepository();
            var exporterCompany = companyRepo.GetData().Find(x => x.Name == "Hepsi Burada");
            var consigneeCompany = companyRepo.GetData().Find(x => x.Name == "Trendyol");

            //var companyList = companyRepo.GetData();

            //var currencyRepo = new CurrencyRepository();
            //var currencyList = currencyRepo.GetData();

            //var iRepo = new InternationalCountryRepository();
            //var internationCountries = iRepo.GetData();
            // Türkiyeden Türkiye fatura kestik
            var invoice = new Invoice(exporter: exporterCompany, consignee: consigneeCompany);

            var commondity1 = new Commondity(description: "Yazılım Hizmet Bedeli", 1, 12000, ServiceUnit.Monthly);
            invoice.AddCommodityItem(commondity1);
            invoice.CalculateInvoice(taxType: TaxType.InCome);

            // 2. test case
            // İlk ülke İngilitere (Getir ingiltere) ikinci Amerika (NY Times) olsun
            // Income,OutCome, International vergileri test ederek invoice oluşturalım

            //3. test case
            // ilk ülke Türkiye (Trendyol) ikinci ülke USA (NY Times)
            // Income,OutCome, International vergileri test ederek invoice oluşturalım

            // 4. test case exporterCompany yada consigneeCompany birini null gönderelim ne olduğuna bakalım

            // 5. test case Company adres alanını boş bırakıp ne olduğunu gözlemleyeliyelim. 1 adet yedterli


            Console.WriteLine("Hello World!");
        }
    }
}
