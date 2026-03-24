using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Application.Availablty.Commands.ChangeProductAvailablty;
using Smraa_AlYaman.Application.Availablty.Common;
using Smraa_AlYaman.Application.Availablty.Queries.GetAvailablty;
using Smraa_AlYaman.Application.Availablty.Queries.GetAvailabltyhistory;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabltyController(
        ISender _sender)
        : MappingController
    {

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetAvailability(int productId)

        {
            var query = new GetProductAvailabltyQuery(productId);
            var result = await _sender.Send(query);

            return result.Match(
                onValue: (value, status) => Success(value,status),
                onError: errors => Problem(errors));
        }
        [HttpGet("{productId:int}/history")]
        public async Task<IActionResult> GetAvailabilityHistory(
            int productId,
            [FromQuery] int? branchId)

        {
            var query = new GetAvailabltyHiestoryQuery(productId,branchId);
            var result = await _sender.Send(query);
            return result.Match(
                onValue: (value, status) => Success(value,status),
                onError: errors => Problem(errors));
        }
        [HttpPut]
        public async Task<IActionResult> ChangeAvailablty(
            [FromBody] List<ProductBrancheChangeDto> updatedAvailablty)
        {
            var command = new ChangeProductAvailabltyCommand(updatedAvailablty);
            var result = await _sender.Send(command);

            return result.Match(
                onValue: (value, status) => Success(value,status),
                onError: errors => Problem(errors));
        }




    }
}
