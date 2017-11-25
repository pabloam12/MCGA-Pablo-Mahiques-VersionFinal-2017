using System;
using System.Collections.Generic;
using ASF.Framework.Utilities;

namespace ASF.Framework.Localization.Model.General.i18n
{
    public partial class LocaleResourceKey : Entity
    {
        public LocaleResourceKey()
        {
            Id = GuidComb.GenerateComb();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual IList<LocaleStringResource> LocaleStringResources { get; set; }
    }
}
