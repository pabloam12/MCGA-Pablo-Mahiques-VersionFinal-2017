using System;

namespace ASF.Framework.Localization.Kernel.Interfaces.Services.UnitOfWork
{
    public partial interface IUnitOfWorkManager : IDisposable
    {
        //IUnitOfWork NewUnitOfWork(bool isReadyOnly);     
        IUnitOfWork NewUnitOfWork();
    }
}
