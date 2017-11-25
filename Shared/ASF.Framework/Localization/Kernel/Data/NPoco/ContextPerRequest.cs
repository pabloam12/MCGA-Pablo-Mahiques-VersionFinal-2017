using System.Web;
using ASF.Framework.Localization.Kernel.Constants;
using NPoco;

namespace ASF.Framework.Localization.Kernel.Data.NPoco
{
    internal static class ContextPerRequest
    {
        internal static IDatabase Current
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(SiteConstants.Instance.MvcKunturContext))
                {
                    HttpContext.Current.Items.Add(SiteConstants.Instance.MvcKunturContext, new Database(SiteConstants.Instance.MvcKunturContext));
                }
                return HttpContext.Current.Items[SiteConstants.Instance.MvcKunturContext] as IDatabase;
            }
        }
    }
}
