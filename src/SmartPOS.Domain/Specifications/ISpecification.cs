namespace SmartPOS.Domain.Specifications;

/// <summary>
/// Defines a specification that can be used to evaluate whether a candidate satisfies a business rule.
/// </summary>
/// <typeparam name="T">The type of candidate evaluated by the specification.</typeparam>
public interface ISpecification<T>
{
    /// <summary>Determines whether the supplied candidate satisfies the specification.</summary>
    /// <param name="candidate">The candidate to evaluate.</param>
    /// <returns><see langword="true" /> if the candidate satisfies the specification; otherwise <see langword="false" />.</returns>
    bool IsSatisfiedBy(T candidate);
}
