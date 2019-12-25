using Contact.Business.Contract;
using Contact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Contact.API.Controllers
{
    [Authorize]
    [RoutePrefix("api")]
    public class ContactsController : ApiController
    {
        private readonly IContactBusiness _contactBusiness;
        public ContactsController(IContactBusiness contactBusiness)
        {
            this._contactBusiness = contactBusiness;
        }
        [HttpPost]
        public async Task<HttpResponseMessage> Post(User user)
        {
            var model = await _contactBusiness.AddContact(user);
            return Request.CreateResponse(model.StatusCode, model);

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task <HttpResponseMessage> Get()
        {
            var model = await _contactBusiness.ListContacts();
            return Request.CreateResponse(model.StatusCode, model);
        }

        [HttpPatch]
        public async Task<HttpResponseMessage> Patch(User user)
        {
            var model =await _contactBusiness.EditContact(user);
            return Request.CreateResponse(model.StatusCode, model);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id, bool status)
        {
            var model =await _contactBusiness.DeleteContact(id, status);
            return Request.CreateResponse(model.StatusCode, model);
        }
    }
}
