using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class DealerBusiness : AuditBusiness
    {

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="Dealer"></param>
        /// <returns></returns>
        public Dealer Add(Dealer Dealer)
        {
            var DealerDac = new DealerDAC();
            Dealer.CreatedBy = CreatedBy;
            Dealer.CreatedOn = CreatedOn;
            Dealer.ChangedBy = ChangedBy;
            Dealer.ChangedOn = ChangedOn;
            return DealerDac.Create(Dealer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var DealerDac = new DealerDAC();
            DealerDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DealerDTO> All()
        {
            var DealerDac = new DealerDAC();
            var result = DealerDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dealer Find(int id)
        {
            var DealerDac = new DealerDAC();
            var result = DealerDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dealer"></param>
        public void Edit(Dealer Dealer)
        {
            var DealerDac = new DealerDAC();
            DealerDac.UpdateById(Dealer);
        }
    }
}
