using BxlForm.DemoSecurity.Api.Models.Global.Data;
using BxlForm.DemoSecurity.Api.Models.Global.Mappers;
using BxlForm.DemoSecurity.Api.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Connections.Database;

namespace BxlForm.DemoSecurity.Api.Models.Global.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly Connection _connection;

        public CategoryService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("Select Id, Name From Category;", false);
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public Category Get(int id)
        {
            Command command = new Command("Select Id, Name From Category WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToCategory()).SingleOrDefault();
        }

        public Category Insert(Category category)
        {
            Command command = new Command("BFSP_AddCategory", true);
            command.AddParameter("Name", category.Name);
            category.Id = (int)_connection.ExecuteScalar(command);
            return category;
        }

        public bool Update(int id, Category category)
        {
            Command command = new Command("BFSP_UpdateCategory", true);
            command.AddParameter("Id", id);
            command.AddParameter("Name", category.Name);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("BFSP_DeleteCategory", true);
            command.AddParameter("Id", id);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
