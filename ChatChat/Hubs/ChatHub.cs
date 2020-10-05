using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using ChatChat.Models;
using Microsoft.AspNet.SignalR;


namespace ChatChat.Hubs
{
    public class ChatHub:Hub
    {
        static List<OnlineUser> Onlines = new List<OnlineUser>();

        // Отправка сообщений
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        // Подключение нового пользователя
        public void Connect(Person person)
        {
            Onlines.Add(new OnlineUser { ConnectionId =person.Id , Name = person.Email });
        }

    }
}
