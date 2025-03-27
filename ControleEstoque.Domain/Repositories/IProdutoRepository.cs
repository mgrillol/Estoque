using ControleEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Repositories
{
    public interface IProdutoRepository
    {
        public Task<Produto> GetByIdAsynk(Guid id);
        public Task AddAsync(Produto produto);
        public Task UpdateAsynk(Produto produto);
    }
}
