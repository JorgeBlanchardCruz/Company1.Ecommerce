namespace Company1.Ecommerce.Domain.Common;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}
