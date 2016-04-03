using System;
using System.Threading.Tasks;
using IEP.BusinessLogic.Entities;

namespace IEP.BusinessLogic.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        EntityModel Context { get; }

        void Commit();

        Task CommitAsync();
    }
}
