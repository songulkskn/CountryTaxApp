using CountryTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTaxApp.Services
{
    public interface ITaxEvaluator
    {
        /// <summary>
        /// Hizmet alan ve hizmet veren firmaları baz alarak hangi vergilendirme sistemin uygulanacağına ve şirketin hangi vergileri ödemesi gerektiğini bize sunan servis
        /// </summary>
        /// <param name="exporter"></param>
        /// <param name="consignee"></param>
        /// <returns></returns>
        List<Tax> TaxEvaluate(Company exporter, Company consignee);
    }
}
