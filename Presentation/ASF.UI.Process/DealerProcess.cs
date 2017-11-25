using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;


namespace ASF.UI.Process
{
    public class DealerProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DealerDTO> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Dealer/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultDealerDTO;
        }

        public void insertDealer(Dealer Dealer)
        {

            ProcessComponent.HttpPost<Dealer>("rest/Dealer/Add", Dealer, MediaType.Json);
        }

        public Dealer findDealer(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            var response = HttpGet<FindResponse>("rest/Dealer/Find", dic, MediaType.Json);
            return response.ResultDealer;

        }

        public void editDealer(Dealer Dealer)
        {
            ProcessComponent.HttpPost<Dealer>("rest/Dealer/Edit", Dealer, MediaType.Json);
        }

        public void deleteDealer(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            ProcessComponent.HttpGet<DealerDTO>("rest/Dealer/Remove/{id}", dic, MediaType.Json);
        }
    }
}
