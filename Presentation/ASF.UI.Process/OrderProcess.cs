using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.UI.Process
{
    public class OrderProcess : ProcessComponent
    {

        public List<Order> SelectList ()
        {
            var response = HttpGet<AllResponse>( "rest/Order/All", new Dictionary<string, object>(), MediaType.Json );
            return response.ResultOrder;
        }

        public void insertOrder ( Order Order )
        {

            ProcessComponent.HttpPost<Order>( "rest/Order/Add", Order, MediaType.Json );
        }

        public Order findOrder ( int id )
        {
            var dic = new Dictionary<string, object>();
            dic.Add( "Id", id );
            var response = HttpGet<FindResponse>( "rest/Order/Find", dic, MediaType.Json );
            return response.ResultOrder;

        }

        public void editOrder ( Order Order )
        {
            ProcessComponent.HttpPost<Order>( "rest/Order/Edit", Order, MediaType.Json );
        }

        public void deleteOrder ( int id )
        {
            var dic = new Dictionary<string, object>();
            dic.Add( "Id", id );
            ProcessComponent.HttpGet<Order>( "rest/Order/Remove/{id}", dic, MediaType.Json );
        }
    }
}
