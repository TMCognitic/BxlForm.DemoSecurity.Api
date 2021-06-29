using BxlForm.DemoSecurity.Api.Models.Global.Data;
using BxlForm.DemoSecurity.Api.Models.Global.Mappers;
using BxlForm.DemoSecurity.Api.Models.Global.Repositories;
using System.Collections.Generic;
using System.Linq;
using Tools.Connections.Database;

namespace BxlForm.DemoSecurity.Api.Models.Global.Services
{
    public class ContactService : IContactRepository
    {
        private readonly Connection _connection;

        public ContactService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> GetByCategory(int userId, int categoryId)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, CategoryId, UserId From Contact Where UserId = @UserId and CategoryId = @CategoryId;", false);
            command.AddParameter("UserId", userId);
            command.AddParameter("CategoryId", categoryId);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public IEnumerable<Contact> Get(int userId)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, CategoryId, UserId From Contact Where UserId = @UserId;", false);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int userId, int id)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, CategoryId, UserId From Contact Where Id = @Id and UserId = @UserId;", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

        public void Insert(Contact contact)
        {
            Command command = new Command("BFSP_AddContact", true);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, Contact contact)
        {
            Command command = new Command("BFSP_UpdateContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int userId, int id)
        {
            Command command = new Command("BFSP_DeleteContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            _connection.ExecuteNonQuery(command);
        }        
    }
}
