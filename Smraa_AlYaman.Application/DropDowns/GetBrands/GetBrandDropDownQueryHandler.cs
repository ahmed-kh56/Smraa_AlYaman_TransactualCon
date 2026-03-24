using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.DropDowns.GetBrands
{
    public class GetBrandDropDownQueryHandler 
        (IBrandRepository _brandRepository)
        : IRequestHandler<GetBrandDropDownQuery, ResultOf<IEnumerable<Brand>>>
    {
        public async Task<ResultOf<IEnumerable<Brand>>> Handle(GetBrandDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var brands = await _brandRepository.GetBrandsAsync();
                if (brands == null)
                {
                    return Error.NotFound(description: "No brands found.");
                }
                return brands.AsDone();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }
        }
    }
}
