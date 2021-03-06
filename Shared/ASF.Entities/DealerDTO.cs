﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ASF.Entities
{
    /// <summary>
    /// Represents a row of entity data.
    /// </summary>
    [Serializable]
    [DataContract]
    public class DealerDTO : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Id" )]
        [Browsable( false )]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "First Name" )]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Last Name" )]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Category Id" )]
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Category Name" )]
        public string CategoryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Country Id" )]
        public int CountryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Country Name" )]
        public string CountryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Description" )]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Total Products" )]
        public int TotalProducts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Rowid" )]
        public Guid Rowid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Created On" )]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Created By" )]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Changed On" )]
        public DateTime ChangedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName( "Changed By" )]
        public int? ChangedBy { get; set; }
    }
}
