

using ECOM.Domain.Interfaces.Repositories;
using ECOM.Infra.Data.Contexto;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Data.Entity;

namespace ECOM.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork  , IDisposable
    {
        private  DbContext _context;

        public void BeginTransaction()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            _context = contextManager.Context; 
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        

    }
}
