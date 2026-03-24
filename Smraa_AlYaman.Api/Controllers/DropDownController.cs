using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smraa_AlYaman.Application.DropDowns.GetBrands;
using Smraa_AlYaman.Application.DropDowns.GetCatagories;
using Smraa_AlYaman.Application.DropDowns.GetCountries;
using Smraa_AlYaman.Application.DropDowns.GetGroup;

namespace Smraa_AlYaman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : MappingController
    {
        private readonly ISender sender;

        public DropDownController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCatagoriesDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                catagories => Ok(catagories),
                error => Problem(error)
            );
        }
        [HttpGet("Brands")]
        public async Task<IActionResult> GetBrands()
        {
            var query = new GetBrandDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                catagories => Ok(catagories),
                error => Problem(error)
            );
        }
        [HttpGet("Countries")]
        public async Task<IActionResult> GetCountries()
        {
            var query = new GetCountriesDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                catagories => Ok(catagories),
                error => Problem(error)
            );
        }



        [HttpGet("Groups")]
        public async Task<IActionResult> GetGroups()
        {
            var query = new GetGroupDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                g => Ok(g),
                error => Problem(error));
        }


    }
}
