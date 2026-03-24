using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Api.Requestes;
using Smraa_AlYaman.Application.Branches.Commands.RecoverBranch;
using Smraa_AlYaman.Application.Branches.Queries.GetBranches;
using Smraa_AlYaman.Application.Branches.Queries.GetBranchHistory;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController(
        ISender _sender)
        : MappingController
    {

        [HttpPost]
        public async Task<IActionResult> CreateBrnache(
            [FromBody] BrancheRequest request)
        {
            var query = request.ToCreateCommand();
            var resuelt = await _sender.Send(query);
            return resuelt.Match(
                (value, status)=> Success(value,status),
                errors=> Problem(errors));
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBrnache(
            [FromRoute] int id,
            [FromBody] BrancheRequest request)
        {
            var query = request.ToUpdateCommand(id);
            var resuelt = await _sender.Send(query);
            return resuelt.Match(
                (value, status)=> Success(value,status),
                errors=> Problem(errors));
        }
        [HttpPost("audits/{auditId:guid}/recover")]
        public async Task<IActionResult> RecoverAudit(
            [FromRoute] Guid auditId)
        {
            var command = new RecoverBranchCommand(auditId);
            var resuelt = await _sender.Send(command);
            return resuelt.Match(
                (value, status)=> Success(value,status),
                errors=> Problem(errors));
        }
        [HttpGet("history")]
        public async Task<IActionResult> GetBrnachesHistory(
            [FromQuery] int? id = null,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 12)
        {
            var query = new GetBranchHistoryQuery(id, page, pageSize);
            var resuelt = await _sender.Send(query);
            return resuelt.Match(
                (value, status)=> Success(value,status),
                errors=> Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetBrnaches()
        {
            var query = new GetBranchesQuery();
            var resuelt = await _sender.Send(query);
            return resuelt.Match(
                (value, status) => Success(value, status),
                errors => Problem(errors));
        }
    }
}
