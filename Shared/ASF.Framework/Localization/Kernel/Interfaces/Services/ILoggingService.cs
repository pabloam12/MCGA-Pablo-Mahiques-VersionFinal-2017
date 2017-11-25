using System;
using System.Collections.Generic;
using ASF.Framework.Localization.Model.General;

namespace ASF.Framework.Localization.Kernel.Interfaces.Services
{
    public partial interface ILoggingService
    {
        void Error(string message);
        void Error(Exception ex);
        void Initialise(int maxLogSize);
        IList<LogEntry> ListLogFile();
        void Recycle();
        void ClearLogFiles();
    }
}
