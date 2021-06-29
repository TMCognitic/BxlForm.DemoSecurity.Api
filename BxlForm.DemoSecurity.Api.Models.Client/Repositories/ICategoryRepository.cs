using BxlForm.DemoSecurity.Api.Models.Client.Data;
using System.Collections.Generic;

namespace BxlForm.DemoSecurity.Api.Models.Client.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        Category Insert(Category category);
        bool Update(int id, Category category);
        bool Delete(int id);
    }
}
