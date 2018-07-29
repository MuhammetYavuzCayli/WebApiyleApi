using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiyleApi.Classes;
using WebApiyleApi.Models;
using WebApiyleApi.Services;

namespace WebApiyleApi.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        u_service _uservice;
        b_service _bservice;

        public ValuesController() {
            _uservice = new u_service();
            _bservice = new b_service();
        }
        [HttpGet]
        [Route("getusers")]
        // GET api/values
        public JObject GetUsers()
        {
            var Usermodel = new
            {
                User = _uservice.GetList()
            };
            var Resultmodel = new
            {
                Results = Usermodel
            };
            var Rootmodel = new {
                RootObjects = Resultmodel
            };
            JObject obj = JObject.FromObject(Rootmodel);
            return obj;
        }
        [HttpGet]
        [Route("getbooks")]
        // GET api/values
        public JObject GetBooks()
        {
            var Bookmodel = new
            {
                User = _bservice.GetList()
            };
            var Resultmodel = new
            {
                Results = Bookmodel
            };
            var Rootmodel = new
            {
                RootObjects = Resultmodel
            };
            JObject obj = JObject.FromObject(Rootmodel);
            return obj;
        }
        [HttpGet]
        [Route("getuser/{id}")]
        // GET api/values/5
        public JObject Get(int id)
        {
            var Usermodel = new
            {
                //User = _uservice.GetWithWhere(p => p.Id == id)
                User = _uservice.GetWithDetail(id)
            };
            var Resultmodel = new
            {
                Results = Usermodel
            };
            var Rootmodel = new
            {
                RootObjects = Resultmodel
            };
            JObject obj = JObject.FromObject(Rootmodel);
            return obj;
        }

        [HttpGet]
        [Route("getbook/{id}")]
        // GET api/values/5
        public JObject GetBook(int id)
        {
            var Bookmodel = new
            {
                User = _bservice.GetWithWhere(p => p.Id == id)
            };
            var Resultmodel = new
            {
                Results = Bookmodel
            };
            var Rootmodel = new
            {
                RootObjects = Resultmodel
            };
            JObject obj = JObject.FromObject(Rootmodel);
            return obj;
        }

        [HttpPost]
        [Route("adduser")]
        // POST api/values
        public IHttpActionResult PostUser(JObject request)
        {
            User user = new User();
            RootObjects jsonobject = JsonConvert.DeserializeObject<RootObjects>(request.ToString());
            foreach (KeyValuePair<string, User> kvp in jsonobject.Result.User)
            {
                user.Name = kvp.Value.Name;
                user.Location = kvp.Value.Location;
            }
            return Ok(_uservice.InsertEntity(user));
        }

        [HttpPost]
        [Route("addbook")]
        // POST api/values
        public IHttpActionResult PostBook(JObject request)
        {
            Book book = new Book();
            RootObjects jsonobject = JsonConvert.DeserializeObject<RootObjects>(request.ToString());
            foreach (KeyValuePair<string, Book> kvp in jsonobject.Result.Book)
            {
                book.Name = kvp.Value.Name;
                book.Category = kvp.Value.Category;
                book.CreatedTime = DateTime.Now;
                book.ISBN = kvp.Value.ISBN;
                book.Author = kvp.Value.Author;
                book.IsValid = kvp.Value.IsValid;
            }
            return Ok(_bservice.InsertEntity(book));
        }
        [HttpPut]
        [Route("updateuser/{id}")]
        // PUT api/values/5
        public IHttpActionResult PutUser(int id, JObject request)
        {
            User user = new User();
            RootObjects jsonobject = JsonConvert.DeserializeObject<RootObjects>(request.ToString());
            foreach (KeyValuePair<string, User> kvp in jsonobject.Result.User)
            {
                user.Id = id;
                user.Location = kvp.Value.Location;
                user.Name = kvp.Value.Name;
            }
            var response = _uservice.UpdateEntity(user);
            if (response)
            {
                return Ok("Tamamdır"); //burada isterseniz json nesne döndürebilirsiniz :)
            }
            else
            {
                return NotFound(); //burada isterseniz json nesne döndürebilirsiniz :)
            }
        }
        [HttpPut]
        [Route("updatebook/{id}")]
        // PUT api/values/5
        public IHttpActionResult PutBook(int id, JObject request)
        {
            Book book = new Book();
            RootObjects jsonobject = JsonConvert.DeserializeObject<RootObjects>(request.ToString());
            foreach (KeyValuePair<string, Book> kvp in jsonobject.Result.Book)
            {
                book.Id = id;
                book.Name = kvp.Value.Name;
                book.Category = kvp.Value.Category;
                book.Author = kvp.Value.Author;
                book.ISBN = kvp.Value.ISBN;
                book.IsValid = kvp.Value.IsValid;
            }
            var response = _bservice.UpdateEntity(book);
            if (response)
            {
                return Ok("Tamamdır"); //burada isterseniz json nesne döndürebilirsiniz :)
            }
            else
            {
                return NotFound(); //burada isterseniz json nesne döndürebilirsiniz :)
            }
        }
        [HttpDelete]
        [Route("deleteuser/{id}")]
        // DELETE api/values/5
        public IHttpActionResult DeleteUser(int id)
        {
            User u = new User();
            u.Id = id;
            var response = _uservice.DeleteEntity(u);
            if (response)
            {
                return Ok("Tamamdır"); //burada isterseniz json nesne döndürebilirsiniz :)
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("deletebook/{id}")]
        // DELETE api/values/5
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = new Book();
            book.Id = id;
            var response = _bservice.DeleteEntity(book);
            if (response)
            {
                return Ok("Tamamdır"); //burada isterseniz json nesne döndürebilirsiniz :)
            }
            else
            {
                return NotFound();
            }
        }
    }
}
