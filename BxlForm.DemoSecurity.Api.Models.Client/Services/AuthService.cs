using BxlForm.DemoSecurity.Api.Models.Client.Data;
using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using GR = BxlForm.DemoSecurity.Api.Models.Global.Repositories;
using BxlForm.DemoSecurity.Api.Models.Client.Mappers;

namespace BxlForm.DemoSecurity.Api.Models.Client.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly GR.IAuthRepository _globalRepository;

        public AuthService(GR.IAuthRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public bool EmailExists(string email)
        {
            return _globalRepository.EmailExists(email);
        }

        public User Login(string email, string passwd)
        {
            return _globalRepository.Login(email, passwd)?.ToClient();
        }

        public void Register(User entity)
        {
            _globalRepository.Register(entity.ToGlobal());
        }
    }
}
