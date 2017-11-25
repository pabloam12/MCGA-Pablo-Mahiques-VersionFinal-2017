using System;
using ASF.Framework.Utilities;

namespace ASF.Framework.Localization.Model.General.i18n
{
    public partial class LocaleStringResource : Entity
    {
        public LocaleStringResource()
        {
            Id = GuidComb.GenerateComb();
        }
        public Guid Id { get; set; }
        public virtual LocaleResourceKey LocaleResourceKey { get; set; }
        public string ResourceValue { get; set; }
        public virtual Language Language { get; set; }
    }
}
