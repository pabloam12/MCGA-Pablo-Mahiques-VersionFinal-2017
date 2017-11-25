using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASF.UI.WbSite.Constants
{
    public class DataCacheSetting
    {
        public static class Category
        {
            public const string Key = "Category";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromHours(1);
        }

        public static class Country
        {
            public const string Key = "Country";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromHours(1);
        }

        public static class Dealer
        {
            public const string Key = "Dealer";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromHours(1);
        }

        public static class DealerDTO
        {
            public const string Key = "DealerDTO";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromHours( 1 );
        }

        public static class Order
        {
            public const string Key = "Order";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromHours(1);
        }

        public static class Client
        {
            public const string Key = "Client";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromHours(1);
        }

        public static class Product
        {
            public const string Key = "Product";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromHours(1);
        }
    }
}