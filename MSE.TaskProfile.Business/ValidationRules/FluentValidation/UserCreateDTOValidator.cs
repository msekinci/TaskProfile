using FluentValidation;
using MSE.TestProfile.DTO.Concrete.UserDTOs;

namespace MSE.TaskProfile.Business.ValidationRules.FluentValidation
{
    class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("User must have name");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("User must have surname");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage("User must have birthday");
            RuleFor(x => x.Address).NotEmpty().WithMessage("User must have address");
        }
    }
}
