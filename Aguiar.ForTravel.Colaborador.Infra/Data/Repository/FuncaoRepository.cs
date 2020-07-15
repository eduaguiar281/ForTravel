using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Aguiar.ForTravel.Colaborador.Infra.Data.Context;
using Aguiar.ForTravel.Core.Data;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Repository
{
    public class FuncaoRepository: EfRepository<Funcao>, IFuncaoRepository
    {
        public FuncaoRepository(IDataContext db, IUnitOfWork uow) : base(db, uow)
        {

        }

    }
}
