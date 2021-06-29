using BxlForm.DemoSecurity.Api.Models.Client.Data;
using System.Collections.Generic;

namespace BxlForm.DemoSecurity.Api.Models.Client.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get(int userId);
        IEnumerable<Contact> GetByCategory(int userId, int categoryId);
        Contact Get(int userId, int id);
        void Insert(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int userId, int id);
    }
}
