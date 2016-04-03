using System.Threading.Tasks;
using IEP.BusinessLogic.Contracts;
using IEP.BusinessLogic.Entities;

namespace IEP.BusinessLogic.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public EntityModel Context { get; }

        public UnitOfWork()
        {
            Context = new EntityModel();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public Task CommitAsync()
        {
            return Context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
