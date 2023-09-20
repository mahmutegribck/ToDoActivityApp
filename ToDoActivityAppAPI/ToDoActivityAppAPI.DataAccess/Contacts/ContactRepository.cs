using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.Contacts
{
    public class ContactRepository : IContactRepository
    {
        private readonly ToDoActivityAppAPIDbContext _context;

        public ContactRepository(ToDoActivityAppAPIDbContext context)
        {  
            _context = context;
        }
        public async Task CreateContact(Contact contact)
        {
            if(contact != null)
            {
                contact.Date = DateTime.Now;
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Contact could not be created");
            }
        }

        public async Task DeleteContact(string IdentityUserId, int id)
        {
            var deleteContact = await _context.Contacts.FindAsync(id);

            if(deleteContact != null)
            {
                if(deleteContact.ApplicationUserId == IdentityUserId)
                {
                    _context.Contacts.Remove(deleteContact);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User can not delete this contact");
                }
            }
            else
            {
                throw new Exception("Contact could not be deleted");
            }
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var contactList = await _context.Contacts.OrderByDescending(c => c.Date).ToListAsync();
            if(contactList.Count > 0)
            {
                return contactList;
            }
            else
            {
                throw new Exception("Not Found Contact");
            }
        }

        public async Task<List<Contact>> GetAllUserContacts(string IdentityUserId)
        {
            var userContacts = await _context.Contacts.Where(c => c.ApplicationUserId == IdentityUserId).OrderByDescending(c => c.Date).ToListAsync();

            if(userContacts.Count > 0)
            {
                return userContacts;
            }
            else
            {
                throw new Exception("Not Found Contact");
            }
        }

        public async Task<Contact> GetContactById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if(contact != null)
            {
                return contact;
            }
            else
            {
                throw new Exception("Not Found Contact");
            }
        }

        public async Task<Contact> GetUserContactById(string IdentityUserId, int id)
        {
            var userContact = await _context.Contacts.FindAsync(id);

            if(userContact != null)
            {
                if(userContact.ApplicationUserId == IdentityUserId)
                {
                    return userContact;
                }
                else
                {
                    throw new Exception("User contact not found ");
                }
            }
            else
            {
                throw new Exception("Not Found Contact");
            }
        }

        public async Task UpdateContact(string IdentityUserId, Contact contact)
        {
            var contactUpdate = await _context.Contacts.FindAsync(contact.ContactId);

            if(contactUpdate != null)
            {
                if(contactUpdate.ApplicationUserId == IdentityUserId)
                {
                    contactUpdate.Title = contact.Title;
                    contactUpdate.Text = contact.Text;
                    contactUpdate.Date = contact.Date;

                    _context.Contacts.Update(contactUpdate);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User can not update this contact");
                }
            }
            else
            {
                throw new Exception("Not Found Contact");
            }
        }
    }
}
