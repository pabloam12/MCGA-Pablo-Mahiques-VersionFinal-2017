//using Glimpse.Mvc.AlternateType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.WbSite.Constants;
using ASF.UI.Process;


namespace ASF.UI.WbSite.Services.Cache
{
   public class DataCache
    {
        #region singleton
        private static DataCache _instance;
        private static readonly object InstanceLock = new object();
        public static DataCache Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (InstanceLock)
                    {
                        _instance = new DataCache();
                    }
                }
                return _instance;
            }
        }
        #endregion

        private readonly ICacheService _cacheServices;
        private DataCache()
        {
            _cacheServices = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> CategoryList()
        {
            //_cacheServices.Remove(DataCacheSetting.Category.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Category.Key,
                () =>
                {
                    var cp = new CategoryProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Category.SlidingExpiration);
            return lista;

        }

        public void CategoryListRemove()
        {
            _cacheServices.Remove(DataCacheSetting.Category.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Category.Key,
                () =>
                {
                    var cp = new CategoryProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Category.SlidingExpiration);
        }

        public List<Country> CountryList()
        {
            //_cacheServices.Remove(DataCacheSetting.Country.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Country.Key,
                () =>
                {
                    var cp = new CountryProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Country.SlidingExpiration);
            return lista;

        }

        public void CountryListRemove()
        {
            _cacheServices.Remove(DataCacheSetting.Country.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Country.Key,
                () =>
                {
                    var cp = new CountryProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Country.SlidingExpiration);
        }

        //public List<DealerDTO> DealerList()
        //{
        //    //_cacheServices.Remove(DataCacheSetting.Dealer.Key);

        //    var lista = _cacheServices.GetOrAdd(
        //        DataCacheSetting.Dealer.Key,
        //        () =>
        //        {
        //            var dp = new DealerProcess();
        //            return dp.SelectList();
        //        },
        //        DataCacheSetting.Dealer.SlidingExpiration);
        //    return lista;

        //}

        public List<DealerDTO> DealerListDTO()
        {
            //_cacheServices.Remove(DataCacheSetting.Dealer.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.DealerDTO.Key,
                () =>
                {
                    var dp = new DealerProcess();
                    return dp.SelectList();
                },
                DataCacheSetting.DealerDTO.SlidingExpiration);
            return lista;

        }

        //public void DealerListRemove()
        //{
        //    _cacheServices.Remove(DataCacheSetting.Dealer.Key);

        //    var lista = _cacheServices.GetOrAdd(
        //        DataCacheSetting.Dealer.Key,
        //        () =>
        //        {
        //            var dp = new DealerProcess();
        //            return dp.SelectList();
        //        },
        //        DataCacheSetting.Dealer.SlidingExpiration);
        //}

        public void DealerListRemoveDTO ()
        {
            _cacheServices.Remove( DataCacheSetting.DealerDTO.Key );

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.DealerDTO.Key,
                () =>
                {
                    var dp = new DealerProcess();
                    return dp.SelectList();
                },
                DataCacheSetting.DealerDTO.SlidingExpiration );
        }

        public List<Order> OrderList ()
        {
                var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Order.Key,
                () =>
                {
                    var op = new OrderProcess();
                    return op.SelectList();
                },
                DataCacheSetting.Order.SlidingExpiration );
            return lista;

        }

        public void OrderListRemove ()
        {
            _cacheServices.Remove( DataCacheSetting.Order.Key );

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Order.Key,
                () =>
                {
                    var op = new OrderProcess();
                    return op.SelectList();
                },
                DataCacheSetting.Order.SlidingExpiration );
        }

        public List<Client> ClientList ()
        {
            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Client.Key,
                () =>
                {
                    var cp = new ClientProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Client.SlidingExpiration );
            return lista;

        }

        public void ClientListRemove ()
        {
            _cacheServices.Remove( DataCacheSetting.Client.Key );

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Client.Key,
                () =>
                {
                    var cp = new ClientProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Client.SlidingExpiration );
        }

        public List<Product> ProductList()
        {
            //_cacheServices.Remove(DataCacheSetting.Product.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Product.Key,
                () =>
                {
                    var cp = new ProductProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Product.SlidingExpiration);
            return lista;

        }

        public void ProductListRemove()
        {
            _cacheServices.Remove(DataCacheSetting.Product.Key);

            var lista = _cacheServices.GetOrAdd(
                DataCacheSetting.Product.Key,
                () =>
                {
                    var cp = new ProductProcess();
                    return cp.SelectList();
                },
                DataCacheSetting.Product.SlidingExpiration);
        }
    }
}
