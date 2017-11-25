using System;

namespace ASF.Framework.Localization.Kernel.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ImageAttribute : Attribute
    {
        public string Image { get; set; }

        public ImageAttribute(string name)
        {
            Image = name;
        }
    }
}
