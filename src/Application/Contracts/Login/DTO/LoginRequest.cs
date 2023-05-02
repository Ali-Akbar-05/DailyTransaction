namespace Application.Contracts.Login.DTO
{
    public record LoginRequest(string userName, string password, bool isRemember);
}
