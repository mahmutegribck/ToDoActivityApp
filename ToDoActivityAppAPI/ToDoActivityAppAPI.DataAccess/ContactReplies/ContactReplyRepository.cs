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

        public async Task<ContactReply> CreateContactReply(string IdentityUserId, ContactReply contactReply)
        {
            if (contactReply != null)
            {
                contactReply.ApplicationUserId = IdentityUserId;
                await _context.ContactReplies.AddAsync(contactReply);
                await _context.SaveChangesAsync();
                return contactReply;
            }
            else
            {
                throw new Exception("ContactReply could not be created");
            }
        }   

        public async Task DeleteContactReply(string IdentityUserId, int id)
        {
            var deleteContactReply = await _context.ContactReplies.FindAsync(id);

            if (deleteContactReply != null)
            {
                if(deleteContactReply.ApplicationUserId == IdentityUserId)
                {
                    _context.ContactReplies.Remove(deleteContactReply);
                    await _context.SaveChangesAsync();
                }
                throw new Exception("User is not delete this ContactReply");

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

        public async Task<ContactReply> UpdateContactReply(int contactReplyId, string IdentityUserId, ContactReply contactReply)
        {
            var contactReplyUpdate = await _context.ContactReplies.FindAsync(contactReplyId);

            if(contactReplyUpdate != null)
            {
                if(contactReplyUpdate.ApplicationUserId == IdentityUserId)
                {
                    contactReplyUpdate.Title = contactReply.Title;
                    contactReplyUpdate.Text = contactReply.Text;
                    contactReplyUpdate.Date = contactReply.Date;

                    _context.ContactReplies.Update(contactReplyUpdate);
                    await _context.SaveChangesAsync();
                    return contactReplyUpdate;
                }
                throw new Exception("User is not update this ContactReply");
            }                                           
            else
            {
                throw new Exception("Not Found Contact Reply");
            }
        }
    }
}
