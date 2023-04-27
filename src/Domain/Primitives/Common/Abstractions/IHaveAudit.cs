namespace Domain.Primitives.Common.Abstractions
{
    public interface IHaveAudit : IHaveCreator
    {
        DateTime? LastModified { get; }
        string? LastModifiedBy { get; }
        int MofificationNumber { get; }
    }
}
