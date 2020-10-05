using ChatChat.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatChat.Models.Repositories
{
    public class Chats:IChat,IDisposable
    {
        PersonContext db = new PersonContext();

        private bool disposed = false;
        //все пользователи , кроме текущего
        public List<Person> GetPeople(Person user)
        {

            var list = db.Users.Where(x => (x.Id != user.Id));
            return list.ToList();

        }
      
        // все пользователи
        public List<Person> AllPeople()
        {
            return db.Users.ToList();
        }
       
        //получаем пользователя по указанному id
        public Person Person(string id)
        {
            var person = db.Users.FirstOrDefault(s => s.Id == id);
            return person;
        }
      
        //отправка личных сообщений
        public string Messages(Message mes,Person personCurrent)
        {


            var person = db.Users.FirstOrDefault(s => s.Id == mes.ToId);
            var user = personCurrent;// текущий пользователь
            var date = DateTime.Now;//текущее время
            if (user.Ban == true && date > user.BanDateTime.AddMinutes(5))
            {
                user.Ban = false;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (user.Ban == false)
            {
                if (mes.ChatId == null)
                {
                    var chat = db.Chats.FirstOrDefault(x => x.Name == person.UserName + "--" + personCurrent.Email);
                    if (chat==null)
                    {
                        Chat dialog = new Chat() { Name = person.UserName + "--" + personCurrent.Email };
                        dialog.PeopleChat.Add(person);
                        dialog.PeopleChat.Add(user);
                        db.Chats.Add(dialog);
                        db.SaveChanges();
                        Message message = new Message() { Text = mes.Text, FromId = user.Id, FromName = user.Email, ChatId = dialog.Id, DateTime = DateTime.Now, ImageRout = mes.ImageRout };
                        db.Messages.Add(message);
                        db.SaveChanges();
                        return "сообщение отправлено!";
                    }
                    else
                    {
                        Message message = new Message() { Text = mes.Text, FromId = user.Id, FromName = user.Email, ChatId = chat.Id, DateTime = DateTime.Now, ImageRout = mes.ImageRout };
                        db.Messages.Add(message);
                        db.SaveChanges();
                        return "сообщение отправлено!";
                    }
                }
                else
                {
                    Message message = new Message() { Text = mes.Text, FromId = user.Id, FromName = user.Email, ChatId = mes.ChatId, DateTime = DateTime.Now, ImageRout = mes.ImageRout };
                    db.Messages.Add(message);
                    db.SaveChanges();
                    return "сообщение отправлено!";
                }
              
            }
            else
            {
                return "Вы заблокированы на пять минут!";
            }

        }
       
        //определение текущего пользователя
        public Person FindPerson(string name)
        {
            
            var user = db.Users.FirstOrDefault(s => s.UserName == name);
            return user;

        }
      
        //
        //имя текущего пользователя
        public string FindPersonName(string name)
        {
            var user = db.Users.FirstOrDefault(s => s.UserName == name);
            return user.Email;
        }
        //жалоба на пользователя
        public string Complaint(ComplaintPerson complaint,Person personCurrent)
        {
            var users = db.Users.ToList();// все пользователи
            var roles = db.Roles.ToList();// все роли
            var adminRole = roles.FirstOrDefault(x => x.Name == "admin");// роль администратора
            var usersRole = db.Users.Where(u => u.Roles.Any(p => p.RoleId == adminRole.Id));// все пользователи,обладающие правами администратора
            var complaintUser = users.FirstOrDefault(x => x.Id == complaint.Id);// пользователь,на которого жалоба

            Chat dialog = new Chat() { Name = "Жалоба на пользователя:" + complaintUser.Email+" дата:"+DateTime.Now };
            foreach (var x in usersRole)
            {
                dialog.PeopleChat.Add(x);
                dialog.PeopleChat.Add(personCurrent);
                
            }
            db.Chats.Add(dialog);
            db.SaveChanges();
            Message message = new Message() { Text = complaint.Text, FromId = personCurrent.Id, FromName = personCurrent.Email, ChatId = dialog.Id, DateTime = DateTime.Now };
            db.Messages.Add(message);
            db.SaveChanges();
            return "Жалоба на пользователя:"+complaintUser.Email+"  отпправлена на рассмотрение Администратору";

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
        ~Chats()
        {
            Dispose(false);
        }




    }
}