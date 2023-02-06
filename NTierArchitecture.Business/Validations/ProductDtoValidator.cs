using FluentValidation;
using NTierArchitecture.DTO.DTOs.ProductDtos;

namespace NTierArchitecture.Business.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(i => i.Name).NotNull().WithMessage("This {PropertyName} is required").NotEmpty().WithMessage("This {PropertyName} is not null");
            RuleFor(i => i.Price).InclusiveBetween(1, int.MaxValue).WithMessage("This {PropertyName} must be greather 0");
            RuleFor(i => i.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("This {PropertyName} must be greather 0");
        }
    }
}
