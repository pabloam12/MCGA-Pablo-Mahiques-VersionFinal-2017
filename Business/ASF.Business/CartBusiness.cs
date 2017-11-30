using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CartBusiness : AuditBusiness
    {
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="CartItemDTO"></param>
        /// <returns></returns>
        public CartItemDTO Add(CartItemDTO CartItemDTO)
        {
            var CartDAC = new CartDAC();
            CartItemDTO.CreatedBy = CreatedBy;
            CartItemDTO.CreatedOn = CreatedOn;
            CartItemDTO.ChangedBy = ChangedBy;
            CartItemDTO.ChangedOn = ChangedOn;
            return CartDAC.Create(CartItemDTO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var CartDAC = new CartDAC();
            CartDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItemDTO> All()
        {
            var CartDAC = new CartDAC();
            var result = CartDAC.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CartItemDTO Find(int id)
        {
            var CartDAC = new CartDAC();
            var result = CartDAC.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CartItemDTO"></param>
        public void Edit(CartItemDTO CartItemDTO)
        {
            var CartDAC = new CartDAC();
            CartDAC.UpdateById(CartItemDTO);
        }
    }
}