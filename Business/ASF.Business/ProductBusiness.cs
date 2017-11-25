using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{      
    public class ProductBusiness : AuditBusiness
    {  
            /// <summary>
            /// Add method. 
            /// </summary>
            /// <param name="Product"></param>
            /// <returns></returns>
            public Product Add(Product Product)
            {
                var ProductDac = new ProductDac();
                Product.CreatedBy = CreatedBy;
                Product.CreatedOn = CreatedOn;
                Product.ChangedBy = ChangedBy;
                Product.ChangedOn = ChangedOn;
                return ProductDac.Create(Product);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            public void Remove(int id)
            {
                var ProductDac = new ProductDac();
                ProductDac.DeleteById(id);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public List<Product> All()
            {
                var ProductDac = new ProductDac();
                var result = ProductDac.Select();
                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public Product Find(int id)
            {
                var ProductDac = new ProductDac();
                var result = ProductDac.SelectById(id);
                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Product"></param>
            public void Edit(Product Product)
            {
                var ProductDac = new ProductDac();
                ProductDac.UpdateById(Product);
            }
        }
}
