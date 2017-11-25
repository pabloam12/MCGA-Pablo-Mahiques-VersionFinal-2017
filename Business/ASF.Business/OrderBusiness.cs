using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderBusiness : AuditBusiness
    {

        public Order Add ( Order Order )
        {
            var OrderDac = new OrderDAC();
            Order.CreatedBy = CreatedBy;
            Order.CreatedOn = CreatedOn;
            Order.ChangedBy = ChangedBy;
            Order.ChangedOn = ChangedOn;
            return OrderDac.Create( Order );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove ( int id )
        {
            var OrderDac = new OrderDAC();
            OrderDac.DeleteById( id );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> All ()
        {
            var OrderDac = new OrderDAC();
            var result = OrderDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order Find ( int id )
        {
            var OrderDac = new OrderDAC();
            var result = OrderDac.SelectById( id );
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Order"></param>
        public void Edit ( Order Order )
        {
            var OrderDac = new OrderDAC();
            OrderDac.UpdateById( Order );
        }
    }
}
