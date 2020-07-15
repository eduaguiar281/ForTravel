using System;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Core.Data
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> Commit();
    }
}