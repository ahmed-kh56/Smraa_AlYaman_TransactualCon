using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Application.ProductSupplayers.Commands.CreateProductSupplayer;
using Smraa_AlYaman.Application.ProductSupplayers.Commands.DeleteProductSupplayer;
using Smraa_AlYaman.Application.Supplayers.Commands.CreateSupplyer;
using Smraa_AlYaman.Application.Supplayers.Commands.DeleteSupplayer;
using Smraa_AlYaman.Application.Supplayers.Commands.UpdateSupplyer;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplayerController : MappingController
    {
        private readonly ISender _sender;

        public SupplayerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplayer(
            string name,
            string Phone,
            int scope)
        {
            var command = new CreateSupplayerCommand(name, Phone, scope);
            var result = await _sender.Send(command);
            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSupplayer(
            [FromRoute]int id,
            string? name = null,
            string? Phone = null,
            int? scope = null)
        {
            var command = new UpdateSupplayerCommand(id,name, Phone, scope);
            var result = await _sender.Send(command);
            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSupplayer([FromRoute] int id)
        {
            var command = new DeleteSupplayerCommand(id);
            var result = await _sender.Send(command);
            return result.Match(
                (succ, status) => Success(succ, status),
                error => Problem(error));
        }



    }
}
