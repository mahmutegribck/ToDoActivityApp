using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.DataAccess
{
    public class ToDoActivityAppAPIDbContext : DbContext
    {
        public ToDoActivityAppAPIDbContext(DbContextOptions<ToDoActivityAppAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactReply> ContactsReplies { get; set; }
        
        
    }
}
