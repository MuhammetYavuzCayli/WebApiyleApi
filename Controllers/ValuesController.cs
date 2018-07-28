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

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
