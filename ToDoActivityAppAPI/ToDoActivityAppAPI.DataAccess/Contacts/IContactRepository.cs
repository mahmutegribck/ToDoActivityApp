using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.Contacts
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task CreateContact(Contact contact);
        Task UpdateContact(string IdentityUserId, Contact contact);
        Task DeleteContact(string IdentityUserId, int id);
        Task<List<Contact>> GetAllUserContacts(string IdentityUserId);
        Task<Contact> GetUserContactById(string IdentityUserId, int id);
    }
}
