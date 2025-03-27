using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Infraestructure.Data;

namespace ControleEstoque.Infraestructure.Repositories
{
    class ProdutoRepository : IProdutoRepository
    {
        private readonly EstoqueDbContext _context;
        public ProdutoRepository(EstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetByIdAsynk(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsynk(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
