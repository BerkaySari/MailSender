using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.UoW
{
    class UnitOfWork : IUnitOfWork
    {
        public static UnitOfWork Current { get; set; }

        public readonly DbContext DbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void BeginTransaction()
        {
            //_transaction = DbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            DbContext.SaveChanges();
            //_transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
