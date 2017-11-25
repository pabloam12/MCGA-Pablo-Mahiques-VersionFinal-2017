using System.Data.Entity.Migrations;
using System.Linq;
using ASF.Framework.Localization.Model.General.i18n;
using ASF.Framework.Utilities;

namespace ASF.Framework.Localization.Kernel.Data.Context
{
    internal sealed class Configuration : DbMigrationsConfiguration<KunturContext>
    {
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KunturContext context)
        {
            const string langCulture = "en-US";
            var language = context.Language.FirstOrDefault(x => x.LanguageCulture == langCulture);
            if (language == null)
            {
                var cultureInfo = LanguageUtils.GetCulture(langCulture);
                language = new Language
                {
                    Name = cultureInfo.EnglishName,
                    LanguageCulture = cultureInfo.Name,
                };
                context.Language.Add(language);
                context.SaveChanges();
            }


        }
    }
}