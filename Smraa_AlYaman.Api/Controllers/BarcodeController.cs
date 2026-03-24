using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Api.Requestes;
using Smraa_AlYaman.Application.Barcodes.Commands.DeleteBarcode;
using Smraa_AlYaman.Application.Barcodes.Commands.RecoverBarcode;
using Smraa_AlYaman.Application.Barcodes.Queries.GetProductBarcodes;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : MappingController
    {

        private readonly ISender _sender;
        public BarcodeController(ISender sender)
        {
            _sender = sender;
        }


        #region Barcode default CRUD oprations
        [HttpGet]
        public async Task<IActionResult> GetBarcodesForProduct([FromQuery] int productId)
        {
            var query = new GetBarcodesByProductIdQuery(productId);

            var result = await _sender.Send(query);

            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }


        [HttpPost]
        public async Task<IActionResult> CreateBarcode(
            [FromQuery] int productId,
            [FromBody] BarcodeCreateRequest request)
        {
            var command = request.ToCreateCommand(productId);

            var result = await _sender.Send(command);

            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }



        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateBarcode(
            [FromRoute] string code,
            [FromBody] BarcodeUpdateRequest request)
        {
            var command = request.ToUpdateCommand(code);

            var result = await _sender.Send(command);

            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }



        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteBarcode([FromRoute] string code)
        {
            var command = new DeleteBarcodeCommand(code);

            var result = await _sender.Send(command);

            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }


        #endregion




        #region   Barcode History
        [HttpGet("history")]
        public async Task<IActionResult> GetBarcodeHistory(
            [FromQuery] string? code,
            [FromQuery] int? productId,
            [FromQuery] HistoriesRequest request)
        {
            var query = request.ToGetBarcodeHistoryQuery(code, productId);

            var result = await _sender.Send(query);

            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }

        [HttpPost("audits/{auditId:guid}/recover")]
        public async Task<IActionResult> RecoverBarcode([FromRoute] Guid auditId)
        {
            var command = new RecoverBarcodeCommand(auditId);

            var result = await _sender.Send(command);

            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }


        #endregion



    }
}
