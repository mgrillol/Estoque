using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Application.Queries
{
    public record GetProdutoPorIdQuery(Guid id) : IRequest<Produto?>;
    public class GetProdutoPorIdHandler : IRequestHandler<GetProdutoPorIdQuery, Produto?>
    {
        private readonly IProdutoRepository _repository;
        public GetProdutoPorIdHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto?> Handle(GetProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsynk(request.id);
        }
    }
}
