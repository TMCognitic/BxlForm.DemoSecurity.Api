using BxlForm.DemoSecurity.Api.Models.Forms;
using BxlForm.DemoSecurity.Api.Models.Client.Data;
using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BxlForm.DemoSecurity.Api.Infrastructure.Security;

namespace BxlForm.DemoSecurity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AdminRequired]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryForm form)
        {
            Category category = _repository.Insert(new Category(form.Name));
            if(category is not null)
            {
                return Ok(category);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditCategoryForm form)
        {
            if(id != form.Id)
            {
                ModelState.AddModelError("Id", "Invalid Id");
                return BadRequest(ModelState);
            }
            
            if (_repository.Update(id, new Category(form.Name)))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
