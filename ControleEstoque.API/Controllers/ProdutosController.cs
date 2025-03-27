using ControleEstoque.Application.Commands;
using ControleEstoque.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crate([FromBody] CreateProdutoCommand command)
        {
            var idProduto = await _mediator.Send(command);
            return CreatedAtAction(nameof(Crate), new { id = idProduto }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoPorId(Guid id)
        {
            var produto = await _mediator.Send(new GetProdutoPorIdQuery(id));
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(Guid id, [FromBody] int quantidade)
        {
            var status = await _mediator.Send(new UpdateProdutoCommand(id, quantidade));
            if (status == false)
                return NotFound();
            return NoContent();
        }
    }
}
