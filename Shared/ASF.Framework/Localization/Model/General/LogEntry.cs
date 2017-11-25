using System;

namespace ASF.Framework.Localization.Model.General
{
    public partial class LogEntry
    {
        public DateTime Date { get; set; }
        public string Module { get; set;}
        public string Method { get; set; }
        public string DeclaringType { get; set; }
        public string LineNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}
