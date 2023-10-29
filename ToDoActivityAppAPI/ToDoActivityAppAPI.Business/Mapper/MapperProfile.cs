using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Activities.DTOs;
using ToDoActivityAppAPI.Business.Auth.DTOs;
using ToDoActivityAppAPI.Business.ContactReplies.DTOs;
using ToDoActivityAppAPI.Business.Contacts.DTOs;
using ToDoActivityAppAPI.Business.Images.DTOs;
using ToDoActivityAppAPI.Entity.Entities;
using ToDoActivityAppAPI.Entity.Identity;
using Activity = ToDoActivityAppAPI.Entity.Entities.Activity;

namespace ToDoActivityAppAPI.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Activity, CreateActivityDTO>().ReverseMap();
            CreateMap<Activity, GetActivityDTO>().ReverseMap();
            CreateMap<Activity, UpdateActivityDTO>().ReverseMap();

            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, GetContactDTO>().ReverseMap();   
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();

            CreateMap<ContactReply, CreateContactReplyDTO>().ReverseMap();
            CreateMap<ContactReply, GetContactReplyDTO>().ReverseMap(); 
            CreateMap<ContactReply, UpdateContactReplyDTO>().ReverseMap();  

            CreateMap<Image, GetImageDTO>().ReverseMap();
            CreateMap<Image, AddImageDTO>().ReverseMap();


            CreateMap<ApplicationUser, LoginDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
            CreateMap<ApplicationUser, ResetPasswordDto>().ReverseMap();


            
            CreateMap<DateTime, DateOnly>().ConvertUsing(dt => DateOnly.FromDateTime(dt));
            //CreateMap<DateOnly, DateTime>().ConstructUsing(do => do.ToDateTime());
            //CreateMap<DateOnly, DateTime>().ConvertUsing(do => do.ToDateTime());

        }
    }
}
