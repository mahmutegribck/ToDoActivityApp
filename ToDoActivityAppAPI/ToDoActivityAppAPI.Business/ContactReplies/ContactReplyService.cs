using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.ContactReplies.DTOs;
using ToDoActivityAppAPI.DataAccess.ContactReplies;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.Business.ContactReplies
{
    public class ContactReplyService : IContactReplyService
    {
        private readonly IMapper _mapper;
        private readonly IContactReplyRepository _contactReplyRepository;

        public ContactReplyService(IMapper mapper, IContactReplyRepository contactReplyRepository)
        {
            _mapper = mapper;
            _contactReplyRepository = contactReplyRepository;
        }

        public async Task<GetContactReplyDTO> CreateContactReply(string IdentityUserId, CreateContactReplyDTO createContactReplyDTO)
        {
            ContactReply contactReply = _mapper.Map<ContactReply>(createContactReplyDTO);
            return _mapper.Map<GetContactReplyDTO>(await _contactReplyRepository.CreateContactReply(IdentityUserId, contactReply));
        }

        public async Task DeleteContactReply(string IdentityUserId, int id)
        {
            await _contactReplyRepository.DeleteContactReply(IdentityUserId, id);
        }

        public async Task<List<GetContactReplyDTO>> GetAllContactReplies()
        {
            var contactReplies = _mapper.Map<List<GetContactReplyDTO>>(await _contactReplyRepository.GetAllContactReplies());
            return contactReplies;
        }

        public async Task<GetContactReplyDTO> GetContactReplyById(int id)
        {
            GetContactReplyDTO contactReply = _mapper.Map<GetContactReplyDTO>(await _contactReplyRepository.GetContactReplyById(id));
            return contactReply;
        }

        public async Task<GetContactReplyDTO> UpdateContactReply(int contactReplyId, string IdentityUserId, UpdateContactReplyDTO updateContactReplyDTO)
        {
            ContactReply contactReply = _mapper.Map<ContactReply>(updateContactReplyDTO);
            return _mapper.Map<GetContactReplyDTO>(await _contactReplyRepository.UpdateContactReply(contactReplyId, IdentityUserId, contactReply));
        }
    }
}
