using CalixtosStore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalixtosStore.Domain.Core.Notifications
{
    public class NotificacaoDominio : Evento
    {
        public Guid NotificacaoDominioId { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public int Versao { get; private set; }

        public NotificacaoDominio(string key, string value)
        {
            NotificacaoDominioId = Guid.NewGuid();
            Versao = 1;
            Chave = key;
            Valor = value;
        }
    }
}