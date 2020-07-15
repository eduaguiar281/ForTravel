using Aguiar.ForTravel.Colaborador.Domain.Command.Funcao;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Funcao
{
    public class RemoverFuncaoValidacoes : FuncaoValidacoes<RemoverFuncaoCommand>
    {
        public RemoverFuncaoValidacoes()
        {
            ValidarId();
        }
    }
}