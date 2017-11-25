using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.UI.Process
{
    public class ClientProcess : ProcessComponent
    {

        public List<Client> SelectList ()
        {
            var response = HttpGet<AllResponse>( "rest/Client/All", new Dictionary<string, object>(), MediaType.Json );
            return response.ResultClient;
        }

        public void insertClient ( Client Client )
        {

            ProcessComponent.HttpPost<Client>( "rest/Client/Add", Client, MediaType.Json );
        }

        public Client findClient ( int id )
        {
            var dic = new Dictionary<string, object>();
            dic.Add( "Id", id );
            var response = HttpGet<FindResponse>( "rest/Client/Find", dic, MediaType.Json );
            return response.ResultClient;

        }

        public void editClient ( Client Client )
        {
            ProcessComponent.HttpPost<Client>( "rest/Client/Edit", Client, MediaType.Json );
        }

        public void deleteClient ( int id )
        {
            var dic = new Dictionary<string, object>();
            dic.Add( "Id", id );
            ProcessComponent.HttpGet<Client>( "rest/Client/Remove/{id}", dic, MediaType.Json );
        }
    }
}
