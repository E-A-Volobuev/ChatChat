using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatChat.Models
{
    public class Person:IdentityUser
    {
        public bool Ban { get; set; } //заблокирован ли пользователь

        public DateTime BanDateTime { get; set; } // дата блокировки
        public ICollection<Chat> Chat { get; set; }
        public Person()
        {
            Chat = new List<Chat>();
        }
    }
}