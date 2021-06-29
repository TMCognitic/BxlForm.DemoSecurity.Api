using BxlForm.DemoSecurity.Api.Infrastructure.Security;
using BxlForm.DemoSecurity.Api.Models.Client.Data;
using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BxlForm.DemoSecurity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthRequired]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ContactController/1
        [HttpGet("{userId}")]
        public IEnumerable<Contact> Get(int userId)
        {
            return _repository.Get(userId);
        }

        // GET api/<ContactController>/1/1
        [HttpGet("{userId}/{id}")]
        public Contact Get(int userId, int id)
        {
            return _repository.Get(userId, id);
        }

        //// POST api/<ContactController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ContactController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ContactController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
