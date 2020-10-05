using ChatChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;
using System.Web.Http.Results;
using System.Threading.Tasks;
using ChatChat.Models.Repositories;
using Ninject;

namespace ChatChat.Controllers
{
    //для групповых чатов
    [Authorize]
    public class GroupController : ApiController
    {
        IGroupChat repo;

        public GroupController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IGroupChat>().To<Dialogs>();
            repo = ninjectKernel.Get<IGroupChat>();
        }

        //список бесед пользователя
        [HttpGet]
        public List<Chat> GetChats()
        {
            var currentUserName = User.Identity.Name;
           if(currentUserName!=null)
            {
                return repo.GetChats(currentUserName);
            }
            else
            {
                return null;
            }
                
        }
        //поиск беседы по id
        [HttpGet]
        public Chat FindChat(int id)
        {
            return repo.FindChat(id);

        }
        //список сообщений беседы
        [HttpGet]
        public List<Message> GetMessages(int id)
        {
            return repo.GetMessages(id);

        }

        
        //создание беседы из нескольких человек
        [HttpPost]
        public string Array([FromBody]GroupChat groupChat)
        {
            var currentUserName = User.Identity.Name;
            return repo.Array(currentUserName, groupChat);
            
           

        } 
        //выход из чата
        [HttpGet]
        public string OutChat(int id)
        {
            var currentUserName = User.Identity.Name;
            return repo.OutChat(id, currentUserName);
        }





    }
}
