using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; }

        public Produto()
        {
            
        }

        public Produto(long id, string nome, string descricao, double valor, bool ativo)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Ativo = ativo;
        }
    }
}
