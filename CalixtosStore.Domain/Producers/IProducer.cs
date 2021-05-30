using CalixtosStore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalixtosStore.Domain.Producers
{
    public interface IProducer<T> where T : Mensagem
    {
        void SendMensage(T mensagem);
    }
}