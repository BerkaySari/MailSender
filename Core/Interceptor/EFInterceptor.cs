using System;
using Castle.DynamicProxy;
using Core.UoW;
using Microsoft.EntityFrameworkCore;

namespace Core.Interceptor
{
    public class EFInterceptor : IInterceptor
    {
        private readonly DbContext _dbContext;
        public EFInterceptor(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Intercept(IInvocation invocation)
        {
            UnitOfWork.Current = new UnitOfWork(_dbContext);
            UnitOfWork.Current.BeginTransaction();

            try
            {
                invocation.Proceed();
                UnitOfWork.Current.Commit();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
