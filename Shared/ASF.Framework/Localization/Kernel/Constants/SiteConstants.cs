using System;
using System.Web.Mvc;
using ASF.Framework.Localization.Kernel.Interfaces.Services;

namespace ASF.Framework.Localization.Kernel.Constants
{
    public class SiteConstants
    {
        #region Singleton
        private static SiteConstants _instance;
        private static readonly object InstanceLock = new object();
        private static IConfigService _configService;
        private SiteConstants(IConfigService configService)
        {
            _configService = configService;
        }

        public static SiteConstants Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            var configService = DependencyResolver.Current.GetService<IConfigService>();
                            _instance = new SiteConstants(configService);
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion

        #region Generic Get

        /// <summary>
        /// This is the generic get config method, you can use this to also get custom config items out
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfig(string key)
        {
            var dict = _configService.GetKunturConfig();
            if (!string.IsNullOrEmpty(key) && dict.ContainsKey(key))
            {
                return dict[key];
            }
            return string.Empty;
        }

        public string GetType(string key)
        {
            var dict = _configService.GetTypes();
            if (!string.IsNullOrEmpty(key) && dict.ContainsKey(key))
            {
                return dict[key];
            }
            return string.Empty;
        }


        #endregion

        public string MvcKunturVersion => GetConfig("KunturVersion");


        // This is just the initial standard role
        public string StandardMembers => GetConfig("StandardMembers");

        /// <summary>
        /// Social Login Keys
        /// </summary>
        public string FacebookAppId => GetConfig("FacebookAppId");
        public string FacebookAppSecret => GetConfig("FacebookAppSecret");
        public string MicrosoftAppId => GetConfig("MicrosoftAppId");
        public string MicrosoftAppSecret => GetConfig("MicrosoftAppSecret");
        public string GooglePlusAppId => GetConfig("GooglePlusAppId");
        public string GooglePlusAppSecret => GetConfig("GooglePlusAppSecret");

        /// <summary>
        /// File Upload Settings
        /// </summary>
        public int PagingGroupSize => Convert.ToInt32(GetConfig("PagingGroupSize"));
        public string FileUploadAllowedExtensions => GetConfig("FileUploadAllowedExtensions");
        public string FileUploadMaximumFileSizeInBytes => GetConfig("FileUploadMaximumFileSizeInBytes");
        public string UploadFolderPath => GetConfig("UploadFolderPath");
        public int PrivateMessageWarningAmountLessThanAllowedSize => Convert.ToInt32(GetConfig("PrivateMessageWarningAmountLessThanAllowedSize"));
        // Database Connection Key
        public string MvcKunturContext => GetConfig("KunturContext");
        // Default Storage Type
        public string StorageProviderType => GetType("StorageProviderType");
    }
}