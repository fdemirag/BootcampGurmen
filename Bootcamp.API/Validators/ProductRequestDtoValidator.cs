using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using FluentValidation;

namespace Bootcamp.API.Validators
{
    public class ProductRequestDtoValidator : AbstractValidator<ProductRequestDto>
    {

        public ProductRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name alanı boş olamaz").NotEmpty().WithMessage("Name alanı boş olamaz");
            RuleFor(x => x.Price).NotNull().WithMessage("Price alanı boş olamaz");
            RuleFor(x => x.Stock).NotNull().WithMessage("Stock alanı boş olamaz");

            RuleFor(x => x.Stock).Must(x =>
            {
                if (x.Value > 10 && x.Value < 200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }).WithMessage("Stok alanı 10 ile 200 arasında bir değer olmalıdır."); 
        }
    }
}
