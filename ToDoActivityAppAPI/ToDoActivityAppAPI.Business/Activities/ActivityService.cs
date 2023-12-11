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



        public async Task<bool> ActivityDone(string IdentityUserId, int activityId)
        {
            return await _activityRepository.ActivityDone(IdentityUserId, activityId);
        }


        public async Task<bool> ActivityNotDone(string IdentityUserId, int activityId)
        {
            return await _activityRepository.ActivityNotDone(IdentityUserId, activityId);
        }


        public async Task<bool> CreateActivity(string IdentityUserId, CreateActivityDTO createActivityDTO)
        {
            Activity activity = _mapper.Map<Activity>(createActivityDTO);
            activity.ApplicationUserId = IdentityUserId;
          
            return await _activityRepository.CreateActivity(activity);
        }


        public async Task<bool> DeleteUserActivityById(string IdentityUserId, int activityId)
        {
            return await _activityRepository.DeleteUserActivityById(IdentityUserId, activityId);
        }


        public async Task<bool> DeleteUserAllActivitiesById(string IdentityUserId, int[] activityId)
        {
            return await _activityRepository.DeleteUserAllActivitiesById(IdentityUserId, activityId);
        }


        public async Task<bool> DeleteUserAllActivities(string IdentityUserId)
        {
            return await _activityRepository.DeleteUserAllActivities(IdentityUserId);   
        }


        public async Task<List<GetActivityDTO>> GetAllActivities()
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetAllActivities());
        }


        public async Task<List<GetActivityDTO>> GetAllUserActivities(string IdentityUserId)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetAllUserActivities(IdentityUserId));
        }


        public async Task<List<GetActivityDTO>> GetUserActivitiesByButget(string IdentityUserId, double minButget, double maxButget)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActivitiesByButget(IdentityUserId, minButget, maxButget));
        }


        public async Task<List<GetActivityDTO>> GetUserActivitiesByNumberOfDays(string IdentityUserId, int MinDay, int MaxDay)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActivitiesByNumberOfDays(IdentityUserId, MinDay, MaxDay));
        }


        public async Task<List<GetActivityDTO>> GetUserActivitiesDone(string IdentityUserId)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActivitiesDone(IdentityUserId));
        }


        public async Task<List<GetActivityDTO>> GetUserActivitiesNotDone(string IdentityUserId)
        {
            return _mapper.Map<List<GetActivityDTO>>(await _activityRepository.GetUserActivitiesNotDone(IdentityUserId));
        }


        public async Task<GetActivityDTO> GetUserActivityById(string IdentityUserId, int id)
        {
            return _mapper.Map<GetActivityDTO>(await _activityRepository.GetUserActivityById(IdentityUserId, id));
        }


        public async Task<bool> UpdateActivity(int activityId, string IdentityUserId, UpdateActivityDTO updateActivityDTO)
        {
            return await _activityRepository.UpdateActivity(activityId, IdentityUserId, _mapper.Map<Activity>(updateActivityDTO));
        }

        public async Task<List<string>> GetUserActivityTitles(string identityUserId)
        {
            return await _activityRepository.GetUserActivityTitles(identityUserId);
        }
    }
}
