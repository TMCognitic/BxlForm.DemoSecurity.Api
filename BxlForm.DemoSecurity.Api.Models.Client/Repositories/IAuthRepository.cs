using BxlForm.DemoSecurity.Api.Models.Client.Data;

namespace BxlForm.DemoSecurity.Api.Models.Client.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User entity);
        bool EmailExists(string email);
    }
}
