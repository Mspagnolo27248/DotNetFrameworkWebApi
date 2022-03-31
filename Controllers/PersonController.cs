using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BirthdayEnityModels.DataAcess;
using BirthdayEnityModels.Models;


namespace BirthdayTrackerWebApi.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            var people = DAL.GetPerson();

            return people;
        }

        // GET: api/Person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person person)
        { 
                var newid = DAL.Post_Person(person);
                person.Id = newid;
                var message = Request.CreateResponse(HttpStatusCode.Created, person);
                message.Headers.Location = new Uri(Request.RequestUri + newid.ToString());
                return message;
            //}
            //catch (Exception ex)
            //{
                
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            //}
          
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public HttpResponseMessage Delete(int id)
        {
            DAL.Delete_Person(id);
            var message = Request.CreateResponse(HttpStatusCode.OK);
            return message;
        }
    }
}
