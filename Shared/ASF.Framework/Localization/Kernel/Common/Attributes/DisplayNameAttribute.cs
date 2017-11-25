using System;
using System.Web.Mvc;
using ASF.Framework.Localization.Kernel.Interfaces.Services;

namespace ASF.Framework.Localization.Kernel.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DisplayNameAttribute : Attribute
    {
        private readonly ILocalizationService _localizationService;
        public string DisplayName { get; set; }

        public DisplayNameAttribute(string desc)
        {
            if (_localizationService == null)
            {
                _localizationService = DependencyResolver.Current.GetService<ILocalizationService>();
            }
            DisplayName = _localizationService.GetResourceString(desc.Trim());
        }
    }
}
