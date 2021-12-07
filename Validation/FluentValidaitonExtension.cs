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

                    if (DayGifted.Equals(DayNoGift)) context.AddFailure(context.PropertyName, $"Not allowed to give gifts on {DayGifted}");
                });
        }

        public static IRuleBuilderOptionsConditions<T, DateTime> IsDuringSummerVacation<T>(
            this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder.Custom((date, context) =>
                { 
                    int duration = 56; //56 days/8 weeks
                    int minDaysInMonth = 4;
                    DayOfWeek startDay = DayOfWeek.Saturday;
                    DayOfWeek endDay = DayOfWeek.Sunday;

                    DateTime firstOfJuly = new DateTime(date.Year, 7, 1);
                    DateTime start = firstOfJuly.AddDays(firstOfJuly.DaysToNextDayOfWeek(startDay));
                    DateTime firstSunday = firstOfJuly.AddDays(firstOfJuly.DaysToNextDayOfWeek(DayOfWeek.Sunday));
                    if (firstSunday.Day < minDaysInMonth) start = start.AddDays(7); //start has not enough days in month.
 
                    DateTime afterDuration = start.AddDays(duration);
                    DateTime end = afterDuration.AddDays(afterDuration.DaysToNextDayOfWeek(endDay));
                    
                    bool IsDuringVacation = date.IsBetween(start, end); 

                    if (!IsDuringVacation)
                    {
                        context.AddFailure(context.PropertyName,
                                           $"{date.ToShortDateString()} is not during the vacation from {start.ToShortDateString()} to {end.ToShortDateString()}, start {start.DayOfWeek}, end {end.DayOfWeek}");
                    }
                    
                });
        }
    }

}
