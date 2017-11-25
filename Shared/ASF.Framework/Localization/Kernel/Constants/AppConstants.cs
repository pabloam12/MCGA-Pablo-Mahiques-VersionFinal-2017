namespace ASF.Framework.Localization.Kernel.Constants
{

    public static class AppConstants
    {
        public const int SaltSize = 24;
        public const string EditorType = "kuntureditor";

        // Scheduled Tasks
        public const string DefaultTaskGroup = "KunturTaskGroup";

        // Cookie names
        public const string LanguageIdCookieName = "LanguageCulture";
        public const string MemberEmailConfirmationCookieName = "KunturEmailConfirmation";

        // Cache names
        //TODO - Move to cache keys
        public const string LocalisationCacheName = "Localization-";
        public static string LanguageStrings = string.Concat(LocalisationCacheName, "LangStrings-");

        // View Bag / Temp Data Constants
        public const string MessageViewBagName = "Message";
        public const string GlobalClass = "GlobalClass";
        public const string CurrentAction = "CurrentAction";
        public const string CurrentController = "CurrentController";

    }
}
