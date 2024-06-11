using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserManagement.Domain.Interfaces.Specifications;

namespace UserManagement.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T>? GetAsync(Guid id);

        Task UpdateAsync(T entity);

        Task UpdateAsync(IEnumerable<T> entities);

        Task SaveAsync(T entity);

        Task SaveAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        Task DeleteAsync(IEnumerable<T> entities);

        T? Get(ISpecification<T> specification);

        TResult? Get<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function);

        Task<T>? GetAsync(ISpecification<T> specification);

        Task<TResult>? GetAsync<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function);

        IEnumerable<T> Find();

        IEnumerable<T> Find(ISpecification<T> specification);

        IEnumerable<TResult> Find<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function);

        Task<IEnumerable<T>> FindAsync();

        Task<IEnumerable<T>> FindAsync(ISpecification<T> specification);

        Task<IEnumerable<TResult>>? FindAsync<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function);

        IQueryable<T> FindQueryable(ISpecification<T> specification);
    }
}

