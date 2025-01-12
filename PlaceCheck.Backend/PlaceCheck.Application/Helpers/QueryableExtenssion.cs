namespace PlaceCheck.Application.Helpers;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> query, bool condition, Func<T, bool> predicate) 
        => condition ? query.Where(predicate) : query;
}