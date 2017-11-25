using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ClientBusiness : AuditBusiness
    {

        public Client Add ( Client Client )
        {
            var ClientDac = new ClientDAC();
            Client.CreatedBy = CreatedBy;
            Client.CreatedOn = CreatedOn;
            Client.ChangedBy = ChangedBy;
            Client.ChangedOn = ChangedOn;
            return ClientDac.Create( Client );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove ( int id )
        {
            var ClientDac = new ClientDAC();
            ClientDac.DeleteById( id );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Client> All ()
        {
            var ClientDac = new ClientDAC();
            var result = ClientDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client Find ( int id )
        {
            var ClientDac = new ClientDAC();
            var result = ClientDac.SelectById( id );
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Client"></param>
        public void Edit ( Client Client )
        {
            var ClientDac = new ClientDAC();
            ClientDac.UpdateById( Client );
        }
    }
}
