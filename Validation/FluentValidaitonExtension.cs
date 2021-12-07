using System;
using System.Collections.Generic;
using FluentValidation;

namespace GitGoodScrub
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptionsConditions<T, TProperty> FailValidation<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, bool fail)
        {
            return ruleBuilder.Custom((_, context) =>
                {
                    if (fail) context.AddFailure(context.PropertyName, $"Validatie mislukt met: {fail}");
                }
            );
        }

        public static IRuleBuilderOptionsConditions<T, DateTime> NotOnFriday<T>(
            this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder.Custom((date, context) =>
                { 
                    DayOfWeek DayGifted = date.DayOfWeek;
                    DayOfWeek DayNoGift = DayOfWeek.Friday;

                    if (DayGifted != DayNoGift) context.AddFailure(context.PropertyName, $"Not allowed to give gifts on {DayNoGift}");
                });
        }
    }
}
