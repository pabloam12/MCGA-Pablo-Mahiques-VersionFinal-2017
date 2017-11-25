using System;

namespace ASF.Framework.Localization.Kernel.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FilePathAttribute : Attribute
    {
        public string FilePath { get; set; }

        public FilePathAttribute(string filePath)
        {
            FilePath = filePath;
        }
    }
}
