using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatChat.Models
{
    public class ApplicationUserManager:UserManager<Person>
    {
        public ApplicationUserManager(IUserStore<Person> store)
           : base(store)
        {
        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                                                IOwinContext context)
        {
            PersonContext db = context.Get<PersonContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<Person>(db));
            return manager;
        }
    }
    
}