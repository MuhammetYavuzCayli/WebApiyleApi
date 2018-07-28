using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
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
        public JObject Get()
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
        [Route("getuser/{id}")]
        // GET api/values/5
        public JObject Get(int id)
        {
            var Usermodel = new
            {
                User = _uservice.GetWithWhere(p => p.Id == id)
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
        [HttpPost]
        [Route("adduser")]
        // POST api/values
        public IHttpActionResult Post(JObject request)
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
        [HttpPut]
        [Route("updateuser/{id}")]
        // PUT api/values/5
        public IHttpActionResult Put(int id, JObject request)
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
        [HttpDelete]
        [Route("deleteuser/{id}")]
        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
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
    }
}
