using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess.ContactReplies
{
    public interface IContactReplyRepository
    {
        Task<List<ContactReply>> GetAllContactReplies();
        Task<ContactReply> GetContactReplyById(int id);
        Task<ContactReply> CreateContactReply(ContactReply contactReply);
        Task<ContactReply> UpdateContactReply(int contactReplyId, ContactReply contactReply);
        Task DeleteContactReply(int id);
    }
}
