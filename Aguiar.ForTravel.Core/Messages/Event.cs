using MediatR;
using System;

namespace Aguiar.ForTravel.Core.Messages
{
    public abstract class Event : Message, INotification 
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }

    }
}