using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Api.Infrastructure.Security
{
    public class TokenUser
    {
        public int Id { get; internal set; }
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
        public string Email { get; internal set; }
        public bool IsAdmin { get; internal set; }
    }
}
