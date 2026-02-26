using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class ProdutoUpdateDTO
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double? Valor { get; set; }
        public bool? Ativo { get; set; }
        public long? CategoriaId { get; set; }

        public ProdutoUpdateDTO()
        {
            
        }

        public ProdutoUpdateDTO(string? nome, string? descricao, double? valor, bool? ativo, long? categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Ativo = ativo;
            CategoriaId = categoriaId;
        }
    }
}
