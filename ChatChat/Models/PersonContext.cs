using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChatChat.Models
{
    public class PersonContext:IdentityDbContext<Person>
    {
        public PersonContext():base("PersonChat") { }
        public static PersonContext Create()
        {
            return new PersonContext();
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}