using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Activities.DTOs;
using ToDoActivityAppAPI.DataAccess.Activities;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.Business.Activities
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task ActivityDone(string IdentityUserId, int id)
        {
            await _activityRepository.ActivityDone(IdentityUserId, id);
        }

        public async Task ActivityNotDone(string IdentityUserId, int id)
        {
            await _activityRepository.ActivityNotDone(IdentityUserId, id);
        }

        public async Task<GetActivityDTO> CreateActivity(string IdentityUserId, CreateActivityDTO createActivityDTO)
        {
            Activity activity = _mapper.Map<Activity>(createActivityDTO);
            activity.ApplicationUserId = IdentityUserId;
            return _mapper.Map<GetActivityDTO>(await _activityRepository.CreateActivity(activity));
        }

        public async Task DeleteActivity(string IdentityUserId, int activityId)
        {
            await _activityRepository.DeleteActivity(IdentityUserId, activityId);
        }

        public async Task<List<GetActivityDTO>> GetAllActivities()
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetAllActivities());
        }

        public async Task<List<GetActivityDTO>> GetAllUserActivities(string IdentityUserId)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetAllUserActivities(IdentityUserId));
        }

        public async Task<List<GetActivityDTO>> GetUserActiviesByButget(string IdentityUserId, double MinButget, double MaxButget)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActiviesByButget(IdentityUserId, MinButget, MaxButget));
        }

        public async Task<List<GetActivityDTO>> GetUserActiviesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActiviesByNumberOfDays(IdentityUserId, MinDay, MaxDay));
        }

        public async Task<List<GetActivityDTO>> GetUserActiviesDone(string IdentityUserId)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActiviesDone(IdentityUserId));
        }

        public async Task<List<GetActivityDTO>> GetUserActiviesNotDone(string IdentityUserId)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActiviesNotDone(IdentityUserId));
        }

        public async Task<GetActivityDTO> GetUserActivityById(string IdentityUserId, int id)
        {
            return _mapper.Map<GetActivityDTO>(await _activityRepository.GetUserActivityById(IdentityUserId, id));
        }

        public async Task<GetActivityDTO> UpdateActivity(int activityId, string IdentityUserId, UpdateActivityDTO updateActivityDTO)
        {
            return _mapper.Map<GetActivityDTO>(await _activityRepository.UpdateActivity(activityId, IdentityUserId, _mapper.Map<Activity>(updateActivityDTO)));
        }
    }
}
