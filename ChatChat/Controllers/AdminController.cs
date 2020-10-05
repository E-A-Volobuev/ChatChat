using ChatChat.Models;
using ChatChat.Models.Entity;
using ChatChat.Models.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatChat.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : ApiController
    {
        IAdmin repo;

        ChatController chat = new ChatController();
        public Person ThisUser()
        {
            var user = chat.CurrentPerson();
            return user;
        }
        public AdminController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IAdmin>().To<Admins>();
            repo = ninjectKernel.Get<IAdmin>();
        }

        [HttpGet]
        public string Check()
        {
            return "вы обладаете правами администратора";
        }
        [HttpGet]
        public List<Person> GetPeople()
        {
            var user = ThisUser();
            return repo.GetPeople(user);
        }
        [HttpPost]

        public string Array([FromBody] BanPerson ban)
        {
            
            return repo.Array(ban);
        }
    }
}
