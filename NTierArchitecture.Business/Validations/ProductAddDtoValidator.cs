using FluentValidation;
using NTierArchitecture.DTO.DTOs.ProductDtos;

namespace NTierArchitecture.Business.Validations
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(i => i.Name).NotNull().WithMessage("This {PropertyName} is requireds");
            RuleFor(i => i.Price).InclusiveBetween(1, int.MaxValue).WithMessage("This {PropertyName} must be greather 0ssss");
        }

    }
}
