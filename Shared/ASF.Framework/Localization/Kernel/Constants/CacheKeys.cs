namespace ASF.Framework.Localization.Kernel.Constants
{
    public static class CacheKeys
    {
        public const string Domain = "ThisDomain";

        
        public static class Language
        {
            public const string StartsWith = "Language.";
        }
        public static class Settings
        {
            public const string StartsWith = "Settings.";
            public static string Main = string.Concat(StartsWith, "mainsettings");
        }
    }
}
