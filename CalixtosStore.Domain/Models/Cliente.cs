using System;
using System.Collections.Generic;
using System.Text;

namespace CalixtosStore.Domain.Models
{
    public class Cliente : Entidade
    {
        public Cliente(Guid id, string nome, string email, DateTime dataDeNascimento)
        {
            Nome = nome;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            Id = id;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}