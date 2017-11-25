using System.Data.Entity.ModelConfiguration;
using ASF.Framework.Localization.Model.General.i18n;

namespace ASF.Framework.Localization.Kernel.Data.Mapping
{
    public class LocaleStringResourceMapping : EntityTypeConfiguration<LocaleStringResource>
    {
        public LocaleStringResourceMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.ResourceValue).IsRequired().HasMaxLength(1000);
        }
    }
}
