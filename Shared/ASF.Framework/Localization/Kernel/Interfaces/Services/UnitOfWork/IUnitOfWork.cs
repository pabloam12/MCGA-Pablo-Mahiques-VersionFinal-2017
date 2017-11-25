using System;
using System.Collections.Generic;

namespace ASF.Framework.Localization.Kernel.Interfaces.Services.UnitOfWork
{
    public partial interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Commit(List<string> cacheStartsWithToClear, ICacheService cacheService);
        void Rollback();
        void SaveChanges();
        void AutoDetectChangesEnabled(bool option);
        void LazyLoadingEnabled(bool option);
    }
}
