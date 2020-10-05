using ChatChat.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatChat.Models.Repositories
{
    public class Admins:IAdmin
    {
        PersonContext db = new PersonContext();

        private bool disposed = false;

        //все пользователи , кроме текущего
        public List<Person> GetPeople(Person user)
        {

            var list = db.Users.Where(x => (x.Id != user.Id));
            return list.ToList();

        }
        //пользователи для добавления в бан
        public string Array(BanPerson ban)
        {
            var clientList = ban.BanIdMassive.ToList();// id клиентов для блокировки
            var userList = db.Users.ToList(); //все пользователи
            List<Person> banList = new List<Person>();// список клиентов для блокировки
            foreach (var i in clientList)
            {
                foreach (var j in userList)
                {
                    if (i == j.Id)
                    {
                        banList.Add(j);
                    }
                }
            }
            foreach(var x in banList)
            {
                if(x!=null)
                {
                    x.Ban = true;
                    x.BanDateTime = DateTime.Now;
                    db.Entry(x).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return "Блокировка установлена";
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
        ~Admins()
        {
            Dispose(false);
        }
    }
}