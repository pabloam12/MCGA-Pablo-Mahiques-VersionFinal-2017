using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace ASF.Entities
{
    [Serializable]
    [DataContract]
    public class CartItemDTO : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Cart Id")]
        public int CartId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Price")]
        public double Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created By")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed On")]
        public DateTime ChangedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed By")]
        public int? ChangedBy { get; set; }

    }
}
