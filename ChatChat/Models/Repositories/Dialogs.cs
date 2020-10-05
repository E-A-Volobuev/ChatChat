using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ChatChat.Models.Repositories
{
    public class Dialogs:IGroupChat,IDisposable
    {
        PersonContext db = new PersonContext();

        private bool disposed = false;

        //список бесед пользователя
        public List<Chat> GetChats(string name)
        {
 
            var person = db.Users.FirstOrDefault(x=>x.Email==name);
            List<Chat> list = new List<Chat>();
            if(person!=null)
            {
                foreach (var s in db.Chats.Include(p => p.PeopleChat))
                {
                    foreach (Person p in s.PeopleChat)
                    {
                        if (p.Email == person.Email)
                        {
                            list.Add(s);
                        }
                    }
                }

                return list;
            }
            else
            {
                return null;
            }

        }
        //беседа по id
        public Chat FindChat(int id)
        {
            var chat = db.Chats.FirstOrDefault(x => x.Id == id);
            return chat;
        }

        //история сообщений
        public List<Message> GetMessages(int id)
        {
            
            var chat = db.Chats.FirstOrDefault(x => x.Id == id);
            var list = db.Messages.Where(x => (x.ChatId == chat.Id)).ToList();
            return list;

        }
        ////отправка сообщений в группу
        //public string GroupMessage(string name,Message mes)
        //{
        //    var person = db.Users.FirstOrDefault(x => x.Email == name);
        //    var date = DateTime.Now;
        //    if(person.Ban==true&&date>person.BanDateTime.AddMinutes(5))
        //    {
        //        person.Ban = false;
        //        db.Entry(person).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //    if(person.Ban==false)
        //    {
        //        var chat = db.Chats.FirstOrDefault(x => x.Name == mes.ToName);
        //        Message mess = new Message { Text = mes.Text, FromId = person.Id, FromName = person.Email, ChatId = chat.Id, DateTime = DateTime.Now };
        //        db.Messages.Add(mess);
        //        db.SaveChanges();
        //        return "ок";
        //    }
        //    else
        //    {
        //        return "Вас заблокировали на 5 минут";
        //    }
        //}
        //создание беседы из нескольких человек
        public string Array(string name,GroupChat groupChat)
        {

            var clients = groupChat.MassivIdUser.ToList();// id клиентов для создания беседы, без текущего пользователя
            var users = db.Users.ToList();// все пользователи из бд
            var person = db.Users.FirstOrDefault(x => x.Email == name);
            var people = new List<Person>(); //клиенты для беседы
            

            foreach(var i in clients)
            {
                foreach(var j in users)
                {
                    if(i==j.Id)
                    {
                        people.Add(j);
                    }
                }
            }
            Chat chat = new Chat { Name = groupChat.Name };
            chat.PeopleChat.Add(person);
            foreach(var x in people)
            {
                chat.PeopleChat.Add(x);
            }
            db.Chats.Add(chat);
            db.SaveChanges();
            return "беседа создана!";

        }

        //выход из чата
        public string OutChat(int id,string currentUserName)
        {
            var user = db.Users.Include(x=>x.Chat).FirstOrDefault(p => p.Email == currentUserName);
            var chat = user.Chat.FirstOrDefault(x=>x.Id==id);
            user.Chat.Remove(chat);
            db.SaveChanges();

            return "Вы покунули чат:"+ chat.Name;
        }
        // реализация интерфейса IDisposable.
        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                }
                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }

        // Деструктор
        ~Dialogs()
        {
            Dispose(false);
        }
    }
}