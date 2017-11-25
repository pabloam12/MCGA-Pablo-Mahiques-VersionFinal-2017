﻿using System.Data.Entity.ModelConfiguration;
using ASF.Framework.Localization.Model.General;

namespace ASF.Framework.Localization.Kernel.Data.Mapping
{
    public class EmailMapping : EntityTypeConfiguration<Email>
    {
        public EmailMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.EmailTo).IsRequired().HasMaxLength(100);
            Property(x => x.Body).IsRequired();
            Property(x => x.Subject).IsRequired().HasMaxLength(200);
            Property(x => x.NameTo).IsRequired().HasMaxLength(100);
            Property(x => x.DateCreated).IsRequired();
        }
    }
}
