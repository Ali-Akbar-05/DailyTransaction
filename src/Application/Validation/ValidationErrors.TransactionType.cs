using Domain.Primitives;

namespace Application.Validation;

internal static partial class ValidationErrors
{
    internal static class TransactionType
    {
        internal static Error NotValid => new Error("TransactionType.NotValid", "The specified Transaction type is not valid.");
    }
}
