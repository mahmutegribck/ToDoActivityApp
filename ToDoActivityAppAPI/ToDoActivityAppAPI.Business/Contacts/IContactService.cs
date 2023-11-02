using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Contacts.DTOs;

namespace ToDoActivityAppAPI.Business.Contacts
{
    public interface IContactService
    {
        Task<List<GetContactDTO>> GetAllContacts();
        Task<GetContactDTO> GetContactById(int id);
        Task CreateContact(string IdentityUserId, CreateContactDTO createContactDTO);
        Task UpdateContact(string IdentityUserId, UpdateContactDTO updateContactDTO);
        Task DeleteContact(string IdentityUserId, int id);
        Task<List<GetContactDTO>> GetAllUserContacts(string IdentityUserId);
        Task<GetContactDTO> GetUserContactById(string IdentityUserId, int id);
    }
}
