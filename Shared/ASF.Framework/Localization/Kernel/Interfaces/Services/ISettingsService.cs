using System;
using ASF.Framework.Localization.Model.General;

namespace ASF.Framework.Localization.Kernel.Interfaces.Services
{
    public partial interface ISettingsService
    {
        Settings GetSettings(bool useCache = true);
        Settings Add(Settings settings);
        Settings Get(Guid id);
    }
}
