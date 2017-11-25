using System.Collections.Generic;

namespace ASF.Framework.Localization.Kernel.Interfaces.Services
{

    public partial interface IConfigService
    {
        Dictionary<string, string> GetKunturConfig();
        Dictionary<string, string> GetTypes();
    }
}
