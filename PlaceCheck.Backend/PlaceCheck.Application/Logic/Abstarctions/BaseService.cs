using PlaceCheck.Application.Interfaces;

namespace PlaceCheck.Application.Logic.Abstarctions;

public abstract class BaseService
{
    protected readonly IApplicationDbContext _applicationDbContext;

    public BaseService(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}
