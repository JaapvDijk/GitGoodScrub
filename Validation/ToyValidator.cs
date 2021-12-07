using System;
using FluentValidation;

namespace GitGoodScrub
{
    public class ToyValidator : AbstractValidator<Toy>
    {   
        public ToyValidator()
        {   
            RuleFor(x => x).FailValidation(false);
            RuleFor(x => x.Name).NotEmpty().Length(0, 10);
            RuleFor(x => x.GiftedOn).Must(x => x.DayOfWeek != DayOfWeek.Friday)
                .WithMessage("You cannot give toys on a friday");
            RuleFor(x => x.GiftedOn).NotOnFriday();
        }
    }
}