using BxlForm.DemoSecurity.Api.Infrastructure.Security;
using BxlForm.DemoSecurity.Api.Models.Client.Data;
using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using BxlForm.DemoSecurity.Api.Models.Forms;
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

        private int UserId
        {
            get { return (int)ControllerContext.RouteData.Values["userId"]; }
        }

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ContactController/1
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get(UserId));
        }

        // GET api/<ContactController>/1/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(UserId, id));
        }

        [HttpGet("ByCategory/{categoryId}")]
        public IActionResult GetByCategory(int categoryId)
        {
            return Ok(_repository.GetByCategory(UserId, categoryId));
        }

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateContactForm form)
        {
            Contact contact = new Contact(form.LastName, form.FirstName, form.Email, form.CategoryId, UserId);
            _repository.Insert(contact);
            return NoContent();
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditContactForms form)
        {
            Contact contact = new Contact(form.LastName, form.FirstName, form.Email, form.CategoryId, UserId);
            _repository.Update(id, contact);
            return NoContent();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(UserId, id);
            return NoContent();
        }        
    }
}
