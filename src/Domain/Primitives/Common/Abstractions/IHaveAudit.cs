namespace Domain.Primitives.Common.Abstractions
{
    public interface IHaveAudit : IHaveCreator
    {
        DateTime? LastModified { get; }
        int? LastModifiedBy { get; }
        int MofificationNumber { get; }
    }
}
