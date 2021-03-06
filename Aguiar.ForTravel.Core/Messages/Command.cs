﻿using System;
using FluentValidation.Results;

namespace Aguiar.ForTravel.Core.Messages
{
    public abstract class Command: Message 
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
