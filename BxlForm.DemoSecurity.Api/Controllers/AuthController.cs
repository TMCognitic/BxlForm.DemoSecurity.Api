using BxlForm.DemoSecurity.Api.Infrastructure.Security;
using BxlForm.DemoSecurity.Api.Models.Client.Data;
using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using BxlForm.DemoSecurity.Api.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IAuthRepository authRepository, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            User user = _authRepository.Login(form.Email, form.Passwd);

            if (user is null)
                return Unauthorized(new { Error = "mail ou mot de passe invalide!" });

            user.Token = _tokenRepository.GenerateToken(new TokenUser() { Id = user.Id, LastName = user.LastName, FirstName = user.FirstName, Email = user.Email, IsAdmin = user.IsAdmin });

            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            _authRepository.Register(new User(form.LastName, form.FirstName, form.Email, form.Passwd));
            return NoContent();
        }
    }
}
