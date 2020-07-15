using Aguiar.ForTravel.Colaborador.Domain.Command.Funcao;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Funcao
{
    public class AlterarFuncaoValidacoes : FuncaoValidacoes<AlterarFuncaoCommand>
    {
        public AlterarFuncaoValidacoes()
        {
            ValidarId();
            ValidarDescricao();
            ValidarLimiteOrcamento();
        }
    }
}