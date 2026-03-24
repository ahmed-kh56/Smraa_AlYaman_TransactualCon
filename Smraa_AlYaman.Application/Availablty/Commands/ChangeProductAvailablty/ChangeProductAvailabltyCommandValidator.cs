using FluentValidation;

namespace Smraa_AlYaman.Application.Availablty.Commands.ChangeProductAvailablty
{
    public class ChangeProductAvailabltyCommandValidator:AbstractValidator<ChangeProductAvailabltyCommand>
    {
        public ChangeProductAvailabltyCommandValidator()
        {
            RuleForEach(x => x.ChangeDtos).ChildRules(changeDto =>
            {
                changeDto.RuleFor(x => x.ProductId).GreaterThan(0);
                changeDto.RuleFor(x => x.BrancheId).GreaterThan(0);
            });
            RuleFor(x => x.ChangeDtos).NotNull().Must(l=>l.Any());
        }
    }



}
