using Contact.Business.Contract;
using Contact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage Post(User user)
        {
            var model = _contactBusiness.AddContact(user);
            return Request.CreateResponse(model.StatusCode, model);

        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var model = _contactBusiness.ListContacts();
            return Request.CreateResponse(model.StatusCode, model);
        }

        [HttpPatch]
        public HttpResponseMessage Patch(User user)
        {
            var model = _contactBusiness.EditContact(user);
            return Request.CreateResponse(model.StatusCode, model);
        }

        [HttpPatch]
        [Route("EditStatus")]
        public HttpResponseMessage Patch(int id, bool status)
        {
            var model = _contactBusiness.EditContact(id, status);
            return Request.CreateResponse(model.StatusCode, model);
        }
    }
}
