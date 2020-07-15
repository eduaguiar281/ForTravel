using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Application.ViewModels
{
    public class TipoPagamentoViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo descrição é Obrigatório!")]
        [MinLength(2, ErrorMessage = "O Campo descrição deve possuir no mínimo 2 caracteres")]
        [MaxLength(150, ErrorMessage = "O Campo descrição deve possuir no máximo 150 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public bool RequerDadosCartao { get; set; }
        public bool EhCartaoCorporativo { get; set; }
        public bool RequerDadosConta { get; set; }

    }
}
