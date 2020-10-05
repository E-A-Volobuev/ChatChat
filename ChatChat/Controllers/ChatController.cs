using ChatChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Data.Entity;
using System.Web.Razor.Parser;
using ChatChat.Hubs;
using ChatChat.Models.Repositories;
using Ninject;
using ChatChat.Models.Entity;
using System.IO;
using System.Threading.Tasks;
using Ninject.Activation;

namespace ChatChat.Controllers
{
    [Authorize]
    //контроллер  для личных сообщений
    public class ChatController : ApiController
    {
        IChat repo;
        public ChatController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IChat>().To<Chats>();
            repo = ninjectKernel.Get<IChat>();
        }
        //все пользователи , кроме текущего
        [HttpGet]
        public List<Person> GetPeople()
        {

            var user = CurrentPerson();
            if (user!=null)
            {

                return repo.GetPeople(user);
            }
            else
            {
                return repo.AllPeople();
            }
  
        }
        //получаем пользователя по указанному id
        [HttpGet]
        public Person Person(string id)
        {
            return repo.Person(id);
        }

        //отправка личных сообщений
        [HttpPost]
        public string Messages([FromBody] Message mes)
        {

            CoockieClear();
            var person = CurrentPerson();

            HttpCookie cookieReq = HttpContext.Current.Request.Cookies["Chat"];

            // Проверить, удалось ли обнаружить cookie-набор с таким именем.
            // Это хорошая мера предосторожности, потому что         
            // пользователь мог отключить поддержку cookie-наборов,         
            // в случае чего cookie-набор не существует        
            
            if (cookieReq != null)
            {
                mes.ImageRout = cookieReq["UserFiles"];
                return repo.Messages(mes, person);
            }
         

            return repo.Messages(mes, person);
        }
        //очистка куки-наборов
        public void CoockieClear()
        {
            HttpCookie cookie = new HttpCookie("Chat");
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        //определение текущего пользователя
        public Person CurrentPerson()
        {
            string name = User.Identity.Name;
            return repo.FindPerson(name);
           
        }
        //определение имени текущего пользователя
        [HttpGet]
        public string CurrentPersonName()
        {
            string name = User.Identity.Name;
            return repo.FindPersonName(name);

        }
        //жалоба на пользователя
        [HttpPost]
        public string Complaint([FromBody] ComplaintPerson complaint)
        {

            var personCurrent = CurrentPerson();
            return repo.Complaint(complaint,personCurrent);

        }
         // отпрака файлов пользователю
         [HttpPost]
         public  async Task<IHttpActionResult> File()
         {

            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }
            var provider = new MultipartMemoryStreamProvider();
            // путь к папке на сервере
            string root = HttpContext.Current.Server.MapPath("~/Files/");
            await Request.Content.ReadAsMultipartAsync(provider);
            string name = null;

            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                byte[] fileArray = await file.ReadAsByteArrayAsync();
                name = root + filename;
                // Создать объект cookie-набора
                HttpCookie cookie = new HttpCookie("Chat");

                // Установить значения в нем
                cookie["UserFiles"] = filename;
                cookie.Expires = DateTime.Now.AddDays(1);

                // Добавить куки в ответ
                HttpContext.Current.Response.Cookies.Add(cookie);

                using (FileStream fs = new FileStream(root + filename, FileMode.Create))
                {
                    await fs.WriteAsync(fileArray, 0, fileArray.Length);
                }
            }
            return Ok("ОК");
         }


    }
}
