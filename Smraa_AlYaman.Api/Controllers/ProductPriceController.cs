using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Api.Requestes;
using Smraa_AlYaman.Application.Prices.Commands.RecoverProductPrice;
using Smraa_AlYaman.Application.Prices.Queries.GetProductPriceHistory;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : MappingController
    {
        private readonly ISender _mediator;
        public ProductPriceController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("History")]
        public async Task<IActionResult> GetProductPriceHistoryId(
            int? productId,
            int pageNum = 0,
            int pageSize = 12)
        {
            var query = new GetProductPriceHistoryQuery(productId,pageSize,pageNum);
            var result = await _mediator.Send(query);
            return result.Match(
                (val, status) => Success(val, status),
                errors => Problem(errors));
        }
        [HttpPost("{productId:int}")]
        public async Task<IActionResult> CreatePriceByProductId(
            [FromRoute] int productId,
            [FromBody] ProductPriceCreateRequest request)
        {
            var query = request.ToCommand(productId);
            var result = await _mediator.Send(query);
            return result.Match(
                (val, status) => Success(val, status),
                errors => Problem(errors));
        }
        [HttpPut("{productId:int}")]
        public async Task<IActionResult> UpdateProductPriceByProductId(
            [FromRoute] int productId,
            [FromBody] ProductPriceUpdateRequest request)
        {
            var query = request.ToCommand(productId);
            var result = await _mediator.Send(query);
            return result.Match(
                (val, status) => Success(val, status),
                errors => Problem(errors));
        }
        [HttpPost("{auditId:guid}/Recover")]
        public async Task<IActionResult> UpdateProductPriceByProductId(
            [FromRoute] Guid auditId)
        {
            var query = new RecoverProductPriceCommand(auditId);
            var result = await _mediator.Send(query);
            return result.Match(
                (val, status) => Success(val, status),
                errors => Problem(errors));
        }
    }
}
