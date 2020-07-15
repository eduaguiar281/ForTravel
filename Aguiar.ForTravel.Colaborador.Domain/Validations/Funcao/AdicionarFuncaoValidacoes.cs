using Aguiar.ForTravel.Colaborador.Domain.Command.Funcao;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Funcao
{
    public class AdicionarFuncaoValidacoes: FuncaoValidacoes<AdicionarFuncaoCommand>
    {
        public AdicionarFuncaoValidacoes()
        {
            ValidarId();
            ValidarDescricao();
            ValidarLimiteOrcamento();
        }
        
    }
}