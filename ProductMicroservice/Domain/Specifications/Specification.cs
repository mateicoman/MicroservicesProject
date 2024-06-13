using System.Linq.Expressions;
using ProductMicroservice.Domain.Interfaces;

namespace ProductMicroservice.Domain.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>>? Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected Specification()
        {
        }

        protected Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}

