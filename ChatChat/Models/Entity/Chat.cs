using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatChat.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Message> MessagesChat { get; set; }
        public ICollection<Person> PeopleChat { get; set; }
        public Chat()
        {
            MessagesChat = new List<Message>();
            PeopleChat = new List<Person>();
        }
    }
}