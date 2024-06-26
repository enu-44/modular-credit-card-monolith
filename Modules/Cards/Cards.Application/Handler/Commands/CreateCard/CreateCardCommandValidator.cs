﻿using FluentValidation;
namespace Cards.Application;
internal sealed class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
{
    internal CreateCardCommandValidator()
    {
        RuleFor(v => v.Dto.UserId).NotNull().NotEmpty();
        RuleFor(v => v.Dto.CardNumber).NotNull().NotEmpty().MinimumLength(8).MaximumLength(15);
        RuleFor(v => v.Dto.OwnerName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}