namespace MotelHubApi;
public static class QueryStringQueryExtension
{
    public static string GetContainStringQuery<TEntity>(this TEntity entity, string selectedField, string compareValue) where TEntity : class, IEntity
    {
        return $"{selectedField}:{compareValue}";
    }

    public static string GetRangeQuery<TEntity>(this TEntity entity, string selectedField, IComparable from, IComparable to) where TEntity : class, IEntity
    {
        return $"{selectedField}:>={from} AND {selectedField}:<={to}";
    }

    public static string GetGreaterThanOrEqualQuery<TEntity>(this TEntity entity, string selectedField, IComparable value)
    {
        return $"{selectedField}:>={value}";
    }

    public static string GetGreaterThanQuery<TEntity>(this TEntity entity, string selectedField, IComparable value)
    {
        return $"{selectedField}:>{value}";
    }

    public static string GetLessThanQuery<TEntity>(this TEntity entity, string selectedField, IComparable value)
    {
        return $"{selectedField}:<{value}";
    }

    public static string GetLessThanOrEqualQuery<TEntity>(this TEntity entity, string selectedField, IComparable value)
    {
        return $"{selectedField}:<={value}";
    }
}
