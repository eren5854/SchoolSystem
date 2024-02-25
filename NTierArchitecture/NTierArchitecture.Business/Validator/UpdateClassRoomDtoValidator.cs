using FluentValidation;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.Business.Validator;
public class UpdateClassRoomDtoValidator : AbstractValidator<UpdateClassRoomDto>
{
    public UpdateClassRoomDtoValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.Name).NotEmpty().MinimumLength(3);
    }
}
