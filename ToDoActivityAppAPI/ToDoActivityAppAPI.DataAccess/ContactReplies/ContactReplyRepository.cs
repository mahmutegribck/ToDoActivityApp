using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.ContactReplies
{
    public class ContactReplyRepository : IContactReplyRepository
    {
        private readonly ToDoActivityAppAPIDbContext _context;

        public ContactReplyRepository(ToDoActivityAppAPIDbContext context)
        {
            _context = context;
        }

        public async Task CreateContactReply(ContactReply contactReply)
        {
            if (contactReply != null)
            {
                await _context.ContactReplies.AddAsync(contactReply);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("ContactReply could not be created");
            }
        }

        public async Task DeleteContactReply(int id)
        {
            var deleteContactReply = await _context.ContactReplies.FindAsync(id);

            if (deleteContactReply != null)
            {

                _context.ContactReplies.Remove(deleteContactReply);
                await _context.SaveChangesAsync();

            }
            else
            {
                throw new Exception("ContactReply could not be deleted");
            }
        }

        public async Task<List<ContactReply>> GetAllContactReplies()
        {
            var contactReplies = await _context.ContactReplies.ToListAsync();

            if (contactReplies.Count > 0)
            {
                return contactReplies;
            }
            else
            {
                throw new Exception("Not Found Contact Reply");
            }
        }

        public async Task<ContactReply> GetContactReplyById(int id)
        {
            var contactReply = await _context.ContactReplies.FindAsync(id);

            if (contactReply != null)
            {
                return contactReply;
            }
            else
            {
                throw new Exception("Not Found Contact Reply");
            }

        }

        public async Task UpdateContactReply(ContactReply contactReply)
        {
            var contactReplyUpdate = await _context.ContactReplies.FindAsync(contactReply.ContactId);

            if(contactReplyUpdate != null)
            {
                contactReplyUpdate.ContactReplyTitle = contactReply.ContactReplyTitle;
                contactReplyUpdate.ContactReplyText = contactReply.ContactReplyText;
                contactReplyUpdate.ContactReplyDate = contactReply.ContactReplyDate;
                
                _context.ContactReplies.Update(contactReplyUpdate);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not Found Contact Reply");
            }
        }
    }
}
