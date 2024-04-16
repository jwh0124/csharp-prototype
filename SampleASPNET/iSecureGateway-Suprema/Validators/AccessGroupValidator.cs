using FluentValidation;
using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.DTO;

namespace iSecureGateway_Suprema.Validators
{
    public class AccessGroupValidator : AbstractValidator<AccessGroupDto>
    {
        public AccessLevelContextHandler accessLevelContextHandler;

        public AccessGroupValidator(AccessLevelContextHandler accessLevelContextHandler)
        {
            this.accessLevelContextHandler = accessLevelContextHandler;

            RuleFor(x => x.Code).NotNull().WithMessage("AccessGroup code is required");
            RuleForEach(x => x.AccessLevels).MustAsync(async (accessLevel, cancellation) =>
            {
                bool exist = await accessLevelContextHandler.FindByCondition(x => x.Code.Equals(accessLevel.Code)) == null;
                return !exist;
            }).WithMessage("Not found access level");
        }
    }
}
