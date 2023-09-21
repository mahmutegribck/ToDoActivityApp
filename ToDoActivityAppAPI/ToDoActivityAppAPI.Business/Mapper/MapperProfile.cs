﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Activities.DTOs;
using ToDoActivityAppAPI.Business.ContactReplies.DTOs;
using ToDoActivityAppAPI.Business.Contacts.DTOs;
using ToDoActivityAppAPI.Entity.Entities;
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
        }
    }
}