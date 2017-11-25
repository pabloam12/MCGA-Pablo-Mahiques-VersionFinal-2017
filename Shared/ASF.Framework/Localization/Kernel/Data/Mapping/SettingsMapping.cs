using System.Data.Entity.ModelConfiguration;
using ASF.Framework.Localization.Model.General;

namespace ASF.Framework.Localization.Kernel.Data.Mapping
{
    public class SettingsMapping : EntityTypeConfiguration<Settings>
    {
        public SettingsMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.WebSiteName).IsOptional().HasMaxLength(500);
            Property(x => x.WebSiteUrl).IsOptional().HasMaxLength(500);
            Property(x => x.NotificationReplyEmail).IsOptional().HasMaxLength(100);
            Property(x => x.SMTP).IsOptional().HasMaxLength(100);
            Property(x => x.SMTPUsername).IsOptional().HasMaxLength(100);
            Property(x => x.SMTPPort).IsOptional().HasMaxLength(10);
            Property(x => x.SMTPEnableSSL).IsOptional();
            Property(x => x.SMTPPassword).IsOptional().HasMaxLength(100);
            Property(x => x.Theme).IsOptional().HasMaxLength(100);
            Property(x => x.CurrentDatabaseVersion).IsOptional().HasMaxLength(10);
            Property(x => x.SuspendRegistration).IsOptional();
            Property(x => x.PageTitle).IsOptional().HasMaxLength(80);
            Property(x => x.CustomHeaderCode).IsOptional();
            Property(x => x.CustomFooterCode).IsOptional();
            HasRequired(x => x.DefaultLanguage)
                .WithOptional().Map(m => m.MapKey("DefaultLanguage_Id"));
        }
    }
}
