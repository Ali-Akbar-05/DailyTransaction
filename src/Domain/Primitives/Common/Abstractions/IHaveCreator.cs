namespace Domain.Primitives.Common.Abstractions;

public interface IHaveCreator
{
    DateTime CreatedDate { get; }
    int CreatedBy { get; }
}
