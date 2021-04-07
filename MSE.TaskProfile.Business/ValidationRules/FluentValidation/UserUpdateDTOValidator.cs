using FluentValidation;
using MSE.TestProfile.DTO.Concrete.UserDTOs;

namespace MSE.TaskProfile.Business.ValidationRules.FluentValidation
{
    class UserUpdateDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateDTOValidator()
        {
            RuleFor(x => x.ID).InclusiveBetween(10000000000, 99999999999).WithMessage("Invalid identifier");
            RuleFor(x => x.ID).NotEmpty().WithMessage("User must have id");
            RuleFor(x => x.Name).NotEmpty().WithMessage("User must have name");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("User must have surname");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage("User must have birthday");
            RuleFor(x => x.Address).NotEmpty().WithMessage("User must have address");
        }
    }
}
