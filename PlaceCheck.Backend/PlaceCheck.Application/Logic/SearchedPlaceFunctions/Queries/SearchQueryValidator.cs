using System.Data;
using FluentValidation;

namespace PlaceCheck.Application.Logic.SearchedPlaceFunctions.Queries;

public class SearchQueryValidator : AbstractValidator<SearchQuery>
{
    public SearchQueryValidator()
    {
        RuleFor(x => x.SearchPhase)
            .NotEmpty();

        RuleFor(x => x.City)
            .NotEmpty();
    }
}
