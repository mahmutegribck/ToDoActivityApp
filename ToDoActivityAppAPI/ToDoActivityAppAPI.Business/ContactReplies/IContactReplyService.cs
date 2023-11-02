using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.ContactReplies.DTOs;

namespace ToDoActivityAppAPI.Business.ContactReplies
{
    public interface IContactReplyService
    {
        Task<List<GetContactReplyDTO>> GetAllContactReplies();
        Task<GetContactReplyDTO> GetContactReplyById(int id);
        Task<GetContactReplyDTO> CreateContactReply(CreateContactReplyDTO createContactReplyDTO);
        Task<GetContactReplyDTO> UpdateContactReply(int contactReplyId, UpdateContactReplyDTO updateContactReplyDTO);
        Task DeleteContactReply(int id);
    }
}
