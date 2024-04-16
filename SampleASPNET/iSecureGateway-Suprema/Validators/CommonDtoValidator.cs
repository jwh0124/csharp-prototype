using FluentValidation;
using iSecureGateway_Suprema.Commons.Http.Request;

namespace iSecureGateway_Suprema.Validators
{
    public class CommonDtoValidator : AbstractValidator<RequestInfoDto>
    {
        public CommonDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("RequestId is required");
            RuleFor(x => x.Operator).NotNull().WithMessage("Operator is required");
        }
    }
}
