using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Api.Requestes;
using Smraa_AlYaman.Application.Prices.Commands.DeleteCustomPrice;
using Smraa_AlYaman.Application.Prices.Commands.RecoverCustomPrice;
using Smraa_AlYaman.Application.Prices.Queries.GetAllCustomPrices;
using Smraa_AlYaman.Application.ProductSupplayers.Commands.CreateProductSupplayer;
using Smraa_AlYaman.Application.ProductSupplayers.Commands.DeleteProductSupplayer;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSupplayerController : MappingController
    {
        private readonly ISender _sender;

        public ProductSupplayerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductSupplayer(
            [FromQuery] int productId,
            [FromQuery] int supplayerId)
        {
            var command = new CreateProductSupplayerCommand(productId,supplayerId);
            var result = await _sender.Send(command);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductSupplayer(
            [FromQuery] int productId,
            [FromQuery] int supplayerId)
        {
            var command = new DeleteProductSupplayerCommand(productId, supplayerId);
            var result = await _sender.Send(command);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchForProductSupplayer(
            [FromQuery] int? productId,
            [FromQuery] string? phone,
            [FromQuery] string? name)
        {
            var query = new GetSupplayersByPhoneQuery(productId, phone,name);
            var result = await _sender.Send(query);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }

    }
}
