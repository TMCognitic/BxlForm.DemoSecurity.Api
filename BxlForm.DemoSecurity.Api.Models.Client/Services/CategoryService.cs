using BxlForm.DemoSecurity.Api.Models.Client.Data;
using BxlForm.DemoSecurity.Api.Models.Client.Mappers;
using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using GR = BxlForm.DemoSecurity.Api.Models.Global.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace BxlForm.DemoSecurity.Api.Models.Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly GR.ICategoryRepository _globalRepository;

        public CategoryService(GR.ICategoryRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public IEnumerable<Category> Get()
        {
            return _globalRepository.Get().Select(c => c.ToClient());
        }

        public Category Get(int id)
        {
            return _globalRepository.Get(id)?.ToClient();
        }

        public Category Insert(Category category)
        {
            return _globalRepository.Insert(category.ToGlobal())?.ToClient();
        }

        public bool Update(int id, Category category)
        {
            return _globalRepository.Update(id, category.ToGlobal());
        }

        public bool Delete(int id)
        {            
            return _globalRepository.Delete(id);
        }
    }
}
