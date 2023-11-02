//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using ToDoActivityAppAPI.Business.Activities.DTOs;
//using ToDoActivityAppAPI.Business.ContactReplies;
//using ToDoActivityAppAPI.Business.ContactReplies.DTOs;
//using ToDoActivityAppAPI.Business.Contacts;
//using ToDoActivityAppAPI.Entity.Identity;

//namespace ToDoActivityAppAPI.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    public class ContactReplyController : ControllerBase
//    {
//        private readonly IContactReplyService _contactReplyService;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public ContactReplyController(IContactReplyService contactReplyService, UserManager<ApplicationUser> userManager)
//        {
//            _contactReplyService = contactReplyService;
//            _userManager = userManager;
//        }

//        [HttpPost]
//        [Route("[action]")]
//        public async Task<IActionResult> CreateContactReply(CreateContactReplyDTO createContactReplyDTO)
//        {
//            var currentUser = await _userManager.GetUserAsync(User);

//            if (currentUser != null)
//            {
//                var contactReply = await _contactReplyService.CreateContactReply(createContactReplyDTO);

//                if (contactReply != null)
//                {
//                    return Ok(contactReply);
//                }
//                return NotFound();
//            }
//            return Unauthorized();
//        }

//        [HttpDelete]
//        [Route("[action]")]
//        public async Task<IActionResult> DeleteContactReply(int id)
//        {
//            var currentUser = await _userManager.GetUserAsync(User);

//            if (currentUser != null)
//            {
//                await _contactReplyService.DeleteContactReply(id);

//                return Ok();
//            }
//            return Unauthorized();
//        }

//        [HttpGet]
//        [Route("[action]")]
//        public async Task<IActionResult> GetAllContactReplies()
//        {
//            var contactReplies = await _contactReplyService.GetAllContactReplies();

//            if(contactReplies.Count>0)
//            {
//                return Ok(contactReplies);
//            }
//            return NotFound();
//        }

//        [HttpGet]
//        [Route("[action]")]
//        public async Task<IActionResult> GetContactReplyById(int id)
//        {
//            var contactReplies = await _contactReplyService.GetContactReplyById(id);

//            if (contactReplies != null)
//            {
//                return Ok(contactReplies);
//            }
//            return NotFound();
//        }

//        [HttpPut]
//        [Route("[action]")]
//        public async Task<IActionResult> UpdateContactReply(int contactReplyId, UpdateContactReplyDTO updateContactReplyDTO)
//        {
//            var currentUser = await _userManager.GetUserAsync(User);

//            if (currentUser != null)
//            {
//                return Ok(await _contactReplyService.UpdateContactReply(contactReplyId, updateContactReplyDTO));
//            }
//            return Unauthorized();
//        }
//    }
//}
