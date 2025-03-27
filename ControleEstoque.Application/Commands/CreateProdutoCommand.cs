using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Application.Commands
{
    public record CreateProdutoCommand(string nome, string? descricao, int quantidade) : IRequest<Guid>;
    public class CreateProdutoHandler : IRequestHandler<CreateProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _repository;
        public CreateProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.nome, request.descricao, request.quantidade);
            await _repository.AddAsync(produto);
            return produto.Id;
        }
    }
}
