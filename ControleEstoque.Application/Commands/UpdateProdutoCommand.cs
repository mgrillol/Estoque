using ControleEstoque.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Application.Commands
{
    public record UpdateProdutoCommand(Guid Id, int quantidade) : IRequest<bool>;
    public class UpdateProdutoHandler : IRequestHandler<UpdateProdutoCommand, bool>
    {
        private readonly IProdutoRepository _repository;
        public UpdateProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsynk(request.Id);

            if (produto == null)
                return false;

            produto.AtualizaQuantidade(request.quantidade);
            await _repository.UpdateAsynk(produto);
            return true;
        }
    }
}
