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
    public class CartProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItemDTO> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/CartItemDTO/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultCartItemDTO;
        }

        public void insertCartItemDTO(CartItemDTO CartItemDTO)
        {

            ProcessComponent.HttpPost<CartItemDTO>("rest/CartItemDTO/Add", CartItemDTO, MediaType.Json);

        }

        public CartItemDTO findCartItemDTO(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            var response = HttpGet<FindResponse>("rest/CartItemDTO/Find", dic, MediaType.Json);
            return response.ResultCartItemDTO;

        }

        public void editCartItemDTO(CartItemDTO CartItemDTO)
        {
            ProcessComponent.HttpPost<CartItemDTO>("rest/CartItemDTO/Edit", CartItemDTO, MediaType.Json);
        }

        public void deleteCartItemDTO(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            ProcessComponent.HttpGet<CartItemDTO>("rest/CartItemDTO/Remove/{id}", dic, MediaType.Json);
        }
    }
}
