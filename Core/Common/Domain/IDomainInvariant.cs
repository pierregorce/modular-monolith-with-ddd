using CSharpFunctionalExtensions;

namespace Core.Common.Domain
{
    public interface IDomainInvariant<TData>
    {
        public Result IsInvariantSatisfied(TData data);
    }
}