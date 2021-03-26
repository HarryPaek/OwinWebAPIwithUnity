﻿using OwinWebAPIwithUnity.Business.Abstracts;
using System.Collections.Generic;
using System.Web.Http;

namespace OwinWebAPIwithUnity.Server.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IBusinessClass _businessClass;
        private readonly IBusinessClassExt _businessClassExt;

        public ValuesController(IBusinessClass businessClass, IBusinessClassExt businessClassExt)
        {
            _businessClass = businessClass;
            _businessClassExt = businessClassExt;
        }

        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", _businessClass.Hello() };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
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
