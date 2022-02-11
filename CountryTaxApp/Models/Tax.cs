namespace CountryTaxApp.Models
{
    public enum TaxType
    {
        International = 1,
        InCome = 2,
        OutCome = 3
    }

    public class Tax
    {
        public string Name { get; private set; }
        public float Rate { get; private set; } // Vergi oranı
        public string Description { get; set; }
        public TaxType Type { get; private set; }

        public Tax(string name,float rate, TaxType taxType)
        {
            this.Name = name;
            this.Rate = rate;
            this.Type = taxType;
        }




    }
}