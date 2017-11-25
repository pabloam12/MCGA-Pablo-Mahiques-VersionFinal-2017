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
    public class ProductProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Product/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultProduct;
        }

        public void insertProduct(Product Product)
        {

            ProcessComponent.HttpPost<Product>("rest/Product/Add", Product, MediaType.Json);
        }

        public Product findProduct(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            var response = HttpGet<FindResponse>("rest/Product/Find", dic, MediaType.Json);
            return response.ResultProduct;

        }

        public void editProduct(Product Product)
        {
            ProcessComponent.HttpPost<Product>("rest/Product/Edit", Product, MediaType.Json);
        }

        public void deleteProduct(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            ProcessComponent.HttpGet<Product>("rest/Product/Remove/{id}", dic, MediaType.Json);
        }
    }
}
