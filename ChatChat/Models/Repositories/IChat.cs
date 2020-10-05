using ChatChat.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatChat.Models.Repositories
{
    public interface IChat
    {
        List<Person> GetPeople(Person user); //все пользователи ,кроме текущего
        Person Person(string id); //получаем пользователя по указанному id
        string Messages(Message mes,Person personCurrent); //отправка личных сообщений
        string Complaint(ComplaintPerson complaint,Person person);// жалоба на пользователя
        List<Person> AllPeople();// все пользователи

        Person FindPerson(string name);// пользователь (Вы)
        string FindPersonName(string name);// Имя екущего пользователя
    }
}
