using BxlForm.DemoSecurity.Api.Models.Global.Data;

namespace BxlForm.DemoSecurity.Api.Models.Global.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User entity);
        bool EmailExists(string email);
    }
}
