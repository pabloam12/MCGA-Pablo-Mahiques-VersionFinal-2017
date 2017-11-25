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
    public class CountryProcess : ProcessComponent
    {
        public List<Country> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Country/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultCountry;
        }

        public void insertCountry(Country Country)
        {

            ProcessComponent.HttpPost<Country>("rest/Country/Add", Country, MediaType.Json);
        }

        public Country findCountry(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            var response = HttpGet<FindResponse>("rest/Country/Find", dic, MediaType.Json);
            return response.ResultCountry;

        }

        public void editCountry(Country Country)
        {
            ProcessComponent.HttpPost<Country>("rest/Country/Edit", Country, MediaType.Json);
        }

        public void deleteCountry(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            ProcessComponent.HttpGet<Country>("rest/Country/Remove/{id}", dic, MediaType.Json);
        }
    }
}
