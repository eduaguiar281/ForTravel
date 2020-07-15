using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _dataContext;

        public UnitOfWork(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Commit()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
