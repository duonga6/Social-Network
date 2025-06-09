using System.Linq.Expressions;

namespace SocialNetwork.SharedKernel.Specifications;

public abstract class SpecificationBase<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }

    public SpecificationBase(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> include)
    {
        Includes.Add(include);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderBy)
    {
        OrderBy = orderBy;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDecs)
    {
        OrderByDescending = orderByDecs;
    }

    protected void ApplyPaging(int take, int skip)
    {
        Take = take;
        Skip = skip;
        IsPagingEnabled = true;
    }
}
