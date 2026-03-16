using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class ServicoUpdateDTO
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double? Preco { get; set; }
        public bool? Ativo { get; set; }

        public ServicoUpdateDTO()
        {
            
        }

        public ServicoUpdateDTO(string? nome, string? descricao, double? preco, bool? ativo)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
