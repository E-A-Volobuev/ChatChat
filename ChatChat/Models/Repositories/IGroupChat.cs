using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChat.Models.Repositories
{
    public interface IGroupChat
    {
         List<Chat> GetChats(string name);//получение списка бесед пользователя
         List<Message> GetMessages(int id);// список сообщений беседы
        string OutChat(int id, string currentUserName);// выход из чата
         string Array(string name,GroupChat groupChat);// получение массива имён участников группы
        Chat FindChat(int id);// поиск беседы по id
    }
}
