using CalixtosStore.Domain.Core.Commands;
using System;

namespace CalixtosStore.Domain.Commands
{
    public abstract class ClienteCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataDeNascimento { get; protected set; }
    }
}