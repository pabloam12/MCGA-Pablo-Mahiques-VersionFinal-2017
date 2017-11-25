using System.Web;

namespace ASF.Framework.Localization.Kernel.Constants
{
    public enum UrlType
    {
        Category,
        Member,
        Tag
    }
    public static class UrlTypes
    {
        public static string GenerateFileUrl(string filePath)
        {
            return VirtualPathUtility.ToAbsolute(filePath);
        }
    }
}