namespace BxlForm.DemoSecurity.Api.Infrastructure.Security
{
    public interface ITokenRepository
    {
        string GenerateToken(TokenUser user);
        TokenUser ValidateToken(string token);
    }
}