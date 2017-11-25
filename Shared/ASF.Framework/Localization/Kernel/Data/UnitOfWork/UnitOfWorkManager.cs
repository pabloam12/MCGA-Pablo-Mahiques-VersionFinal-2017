using System.Data.Entity;
using ASF.Framework.Localization.Kernel.Constants;
using ASF.Framework.Localization.Kernel.Data.Context;
using ASF.Framework.Localization.Kernel.Interfaces.Services;
using ASF.Framework.Localization.Kernel.Interfaces.Services.UnitOfWork;

namespace ASF.Framework.Localization.Kernel.Data.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private bool _isDisposed;
        private readonly KunturContext _context;

        public UnitOfWorkManager(IKunturContext context)
        {
            //http://www.entityframeworktutorial.net/code-first/automated-migration-in-code-first.aspx
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KunturContext, Configuration>(SiteConstants.Instance.MvcKunturContext));
            _context = context as KunturContext;
        }

        /// <summary>
        /// Provides an instance of a unit of work. This wrapping in the manager
        /// class helps keep concerns separated
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork NewUnitOfWork()
        {
            return new UnitOfWork(_context);
        }

        /// <summary>
        /// Make sure there are no open sessions.
        /// In the web app this will be called when the injected UnitOfWork manager
        /// is disposed at the end of a request.
        /// </summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _context.Dispose();
                _isDisposed = true;
            }
        }
    }
}
