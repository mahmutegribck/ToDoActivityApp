using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Contacts.DTOs;
using ToDoActivityAppAPI.DataAccess.Contacts;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.Business.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task CreateContact(string IdentityUserId, CreateContactDTO createContactDTO)
        {
            Contact contact = _mapper.Map<Contact>(createContactDTO);
            contact.ApplicationUserId = IdentityUserId;
            await _contactRepository.CreateContact(contact);
        }

        public async Task DeleteContact(string IdentityUserId, int id)
        {
            await _contactRepository.DeleteContact(IdentityUserId, id);
        }

        public async Task<List<GetContactDTO>> GetAllContacts()
        {
            var contacts = _mapper.Map<List<GetContactDTO>>(await _contactRepository.GetAllContacts());
            return contacts.ToList();
            //return contacts;
        }

        public async Task<List<GetContactDTO>> GetAllUserContacts(string IdentityUserId)
        {
            var userContacts = _mapper.Map<List<GetContactDTO>>(await _contactRepository.GetAllUserContacts(IdentityUserId));
            return userContacts.ToList();
            //return userContacts;
        }

        public async Task<GetContactDTO> GetContactById(int id)
        {
            var contact = _mapper.Map<GetContactDTO>(await _contactRepository.GetContactById(id));
            return contact;
        }

        public async Task<GetContactDTO> GetUserContactById(string IdentityUserId, int id)
        {
            var userContact = _mapper.Map<GetContactDTO>(await _contactRepository.GetUserContactById(IdentityUserId, id));
            return userContact;
        }

        public async Task UpdateContact(string IdentityUserId, UpdateContactDTO updateContactDTO)
        {
            Contact updateContact = _mapper.Map<Contact>(updateContactDTO);
            await _contactRepository.UpdateContact(IdentityUserId, updateContact);
        }
    }
}
