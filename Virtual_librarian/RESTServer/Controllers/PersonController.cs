using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using LibraryObjects;

namespace RESTServer.Controllers
{
    public class PersonController : ApiController
    {
        HumanDBHelper humanDBHelper = new HumanDBHelper();

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            System.Windows.Forms.MessageBox.Show("Test 1");
            return humanDBHelper.GetAllPersons();
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            System.Windows.Forms.MessageBox.Show("Test 2");
            return humanDBHelper.GetPersonByID(id);
        }

        public Person Get(string name, string surname, string password)
        {
            System.Windows.Forms.MessageBox.Show("Test 3");
            return humanDBHelper.GetPersonByNameSurnamePassword(name, surname, password);
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person person)
        {
            //int newPersonId = humanDBHelper.AddNewPerson(person);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, String.Format("person/{0}", newPersonId));
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("person/{0}", 1));
            return response;
        }

        // PUT: api/Person/5
        public HttpResponseMessage Put(int id, [FromBody]Person newPerson)
        {
            bool successfulEdit = humanDBHelper.EditPerson(id, newPerson);
            HttpResponseMessage response;
            if (successfulEdit)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;

        }

        // DELETE: api/Person/5
        public HttpResponseMessage Delete(int id)
        {
            bool successfullDelete = humanDBHelper.DeletePerson(id);
            HttpResponseMessage response;
            if (successfullDelete)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }
    }
}
