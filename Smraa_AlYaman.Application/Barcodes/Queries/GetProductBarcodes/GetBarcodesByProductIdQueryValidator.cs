using FluentValidation;

namespace Smraa_AlYaman.Application.Barcodes.Queries.GetProductBarcodes
{
    public class GetBarcodesByProductIdQueryValidator:AbstractValidator<GetBarcodesByProductIdQuery>
    {
        public GetBarcodesByProductIdQueryValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("BranchId must be greater than or equal to 0.");
        }
    }


}
