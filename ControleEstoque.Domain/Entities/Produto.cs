using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public int Quantidade { get; private set; }

        public Produto(string nome, string descricao, int quantidade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
    }
}
