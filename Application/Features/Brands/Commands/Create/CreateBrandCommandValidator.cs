using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(c=>c.Name).NotEmpty().WithMessage("Brand name cannot be empty.")
            .MinimumLength(2).WithMessage("Brand name must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters.");
    }
}
