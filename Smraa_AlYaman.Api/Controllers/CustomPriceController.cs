using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Api.Requestes;
using Smraa_AlYaman.Application.Prices.Commands.DeleteCustomPrice;
using Smraa_AlYaman.Application.Prices.Commands.RecoverCustomPrice;
using Smraa_AlYaman.Application.Prices.Queries.GetAllCustomPrices;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomPriceController : MappingController
    {
        private readonly ISender _sender;

        public CustomPriceController(ISender sender)
        {
            _sender = sender;
        }


        #region Custom Price CRUD operations
        [HttpPost]
        public async Task<IActionResult> CreateCustomPrice([FromBody] CustomPriceCreateRequest request)
        {
            var command = request.ToCreateCommand();
            var result = await _sender.Send(command);
            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }

        [HttpPatch("{code}/branches/{branchId:int}")]
        public async Task<IActionResult> UpdateCustomPrice(
            [FromRoute] string code,
            [FromRoute] int branchId,
            [FromBody] CustomPriceUpdateRequest request)
        {
            var command = request.ToUpdateCommand(code, branchId);

            var result = await _sender.Send(command);

            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }


        [HttpDelete("{code}/branches/{branchId:int}")]
        public async Task<IActionResult> DeleteCustomPrice(
            [FromRoute] string code,
            [FromRoute] int branchId)
        {
            var command = new DeletePriceCommand(code, branchId);

            var result = await _sender.Send(command);

            return result.Match(
                (success, status) => Success(success, status),
                error => Problem(error));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomPrices(
            [FromQuery] string? code,
            [FromQuery] int? branchId,
            [FromQuery] int? productId)
        {
            var query = new GetAllCustomPricesQuery(code, branchId, productId);

            var result = await _sender.Send(query);

            return result.Match(
                (customPrices, status) => Success(customPrices, status),
                error => Problem(error));
        }

        #endregion

        [HttpGet("history")]
        public async Task<IActionResult> GetPriceHistory(
            [FromQuery] string? code,
            [FromQuery] int? branchId,
            [FromQuery] HistoriesRequest request)
        {
            var query = request.ToGetPriceHistoryQuery(code, branchId);
            var result = await _sender.Send(query);
            return result.Match(
                (priceHistories,status) => Success(priceHistories,status),
                error => Problem(error));
        }
        [HttpPost("audits/{auditId:guid}/recover")]
        public async Task<IActionResult> RecoverPriceAudit(Guid auditId)
        {
            var command = new RecoverCustomPriceCommand(auditId);
            var result = await _sender.Send(command);
            return result.Match(
                (priceHistories,status) => Success(priceHistories,status),
                error => Problem(error));
        }



    }
}
