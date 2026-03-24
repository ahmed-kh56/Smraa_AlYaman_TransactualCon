using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Api.Requestes;
using Smraa_AlYaman.Application.Products.Commands.DeleteProduct;
using Smraa_AlYaman.Application.Products.Commands.RecoverProduct;
using Smraa_AlYaman.Application.Products.Queries.GetProductData;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : MappingController
    {
        private readonly ISender _sender;
        public ProductController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(
            [FromBody]ProductCreateRequest request)
        {
            var command = request.ToCommand();
            var result = await _sender.Send(command);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }

        [HttpPut("{productId:int}")]
        public async Task<IActionResult> UpdateProduct(
            [FromBody] ProductUpdateRequest request,
            [FromRoute] int productId)
        {
            var command = request.ToCommand(productId);
            var result = await _sender.Send(command);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }
        [HttpGet]
        public async Task<IActionResult> GetProdcuts([FromQuery] ProductfFltrationRequest request)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }
        [HttpGet("{productId:int?}/History")]
        public async Task<IActionResult> GetProductsHistory(
            [FromRoute] int? productId,
            [FromQuery] ProductHistoryRequest request)
        {
            var query = request.ToQuery(productId);

            var result = await _sender.Send(query);

            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetById(
            [FromRoute]int productId)
        {
            var query = new GetProductDataQuery(productId);
            var result = await _sender.Send(query);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }
        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> DeleteProduct(
            [FromRoute]int productId)
        {
            var command = new DeleteProductCommand(productId);
            var result = await _sender.Send(command);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }
        [HttpPost("{auditId:guid}/recover")]
        public async Task<IActionResult> RecoverProduct([FromRoute]Guid auditId)
        {
            var command = new RecoverProductCommand(auditId);
            var result = await _sender.Send(command);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));

        }

    }
}
