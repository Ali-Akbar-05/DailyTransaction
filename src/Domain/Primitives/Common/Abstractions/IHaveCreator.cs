namespace Domain.Primitives.Common.Abstractions;

public interface IHaveCreator
{
    DateTime CreatedDate { get; }
    string CreatedBy { get; }
}
