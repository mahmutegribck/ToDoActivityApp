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

        public async Task CreateContactReply(CreateContactReplyDTO createContactReplyDTO)
        {
            ContactReply contactReply = _mapper.Map<ContactReply>(createContactReplyDTO);
            await _contactReplyRepository.CreateContactReply(contactReply);
        }

        public async Task DeleteContactReply(int id)
        {
            await _contactReplyRepository.DeleteContactReply(id);
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

        public async Task UpdateContactReply(UpdateContactReplyDTO updateContactReplyDTO)
        {
            ContactReply contactReply = _mapper.Map<ContactReply>(updateContactReplyDTO);
            await _contactReplyRepository.UpdateContactReply(contactReply);
        }
    }
}
