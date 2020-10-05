using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string FromId { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string ToId { get; set; }
        public string ImageRout { get; set; }//путь к картинке на диске 
        public int? ChatId { get; set; }
        public Chat Chat { get; set; }
        public Message()
        {
        }

    }
}