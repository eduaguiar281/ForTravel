using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Core.DomainObjects
{
    public interface ICopiavel<T> where T:Entity
    {
        void Copiar(T Origem);
    }
}
