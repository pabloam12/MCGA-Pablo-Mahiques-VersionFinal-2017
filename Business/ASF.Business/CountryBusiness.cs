using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CountryBusiness : AuditBusiness
    {
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        public Country Add(Country Country)
        {
            var CountryDac = new CountryDAC();
            Country.CreatedBy = CreatedBy;
            Country.CreatedOn = CreatedOn;
            Country.ChangedBy = ChangedBy;
            Country.ChangedOn = ChangedOn;
            return CountryDac.Create(Country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var CountryDac = new CountryDAC();
            CountryDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> All()
        {
            var CountryDac = new CountryDAC();
            var result = CountryDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country Find(int id)
        {
            var CountryDac = new CountryDAC();
            var result = CountryDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        public void Edit(Country Country)
        {
            var CountryDac = new CountryDAC();
            CountryDac.UpdateById(Country);
        }
    }
}
