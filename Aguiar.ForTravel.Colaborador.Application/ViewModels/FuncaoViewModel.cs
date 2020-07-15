using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Application.ViewModels
{
    public partial class FuncaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo descrição é Obrigatório!")]
        [MinLength(2, ErrorMessage = "O Campo descrição deve possuir no mínimo 2 caracteres")]
        [MaxLength(150, ErrorMessage = "O Campo descrição deve possuir no máximo 150 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public bool PermitirAutorizarViagem { get; set; }
        public bool PermitirCriarViagem { get; set; }

        [DisplayName("Limite de Orçamento")]
        public decimal? LimiteOrcamentoViagem { get; set; }

    }
}
