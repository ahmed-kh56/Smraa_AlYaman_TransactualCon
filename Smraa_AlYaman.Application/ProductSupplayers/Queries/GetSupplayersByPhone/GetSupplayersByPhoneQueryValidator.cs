using FluentValidation;

namespace Smraa_AlYaman.Application.ProductSupplayers.Queries.GetSupplayersByPhone
{
    public class GetSupplayersByPhoneQueryValidator:AbstractValidator<GetSupplayersByPhoneQuery>
    {
        public GetSupplayersByPhoneQueryValidator()
        {
            RuleFor(q=>q.PhoneNumLike).MinimumLength(3).MaximumLength(16).When(q=>q.PhoneNumLike?.Length>0);
        }

    }


}
