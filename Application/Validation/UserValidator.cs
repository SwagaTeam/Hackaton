using Application.Dto;
using FluentValidation;

namespace Application.Validation;

public class UserValidator : AbstractValidator<RegisterModel>
{
    public UserValidator()
    {
        RuleFor(user => user.Login)
            .EmailAddress()
            .NotEmpty()
            .WithMessage("Некорректный email адрес");   
    }
}