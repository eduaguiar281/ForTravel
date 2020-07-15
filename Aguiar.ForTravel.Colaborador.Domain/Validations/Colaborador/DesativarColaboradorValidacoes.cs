﻿using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador
{
    public class DesativarColaboradorValidacoes: ColaboradorValidacoes<DesativarColaboradorCommand>
    {
        public DesativarColaboradorValidacoes()
        {
            ValidarId();
        }
    }
}
