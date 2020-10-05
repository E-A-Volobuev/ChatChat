using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatChat.Models.Entity
{
    public class ComplaintPerson
    {
        public string Id { get; set; } // id пользователя ,на которого жалоба
        public string Text { get; set; }// описание жалобы
    }
}