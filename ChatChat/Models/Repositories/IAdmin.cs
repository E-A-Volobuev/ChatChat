using ChatChat.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChat.Models.Repositories
{
    public interface IAdmin
    {
        
        List<Person> GetPeople(Person user); //все пользователи ,кроме текущего
        string Array(BanPerson ban); //блокировка пользователей
    }
}
