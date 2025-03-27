using ControleEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infraestructure.Data
{
    class EstoqueDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options) { }
    }
}
