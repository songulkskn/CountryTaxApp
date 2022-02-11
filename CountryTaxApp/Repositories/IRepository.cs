using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Repositories
{
    // Generic class çalışacağımız class tipini bilmediğimiz durumlarda kullanılır
    // where T:class, new() T class olsun ve new ile instance alınabilsin
    // T struct,interface, abstract olmaz bunların hiç biri newlenemez.
    public interface IRepository<T> where T:class
    {
        
        List<T> GetData();
    }
}
