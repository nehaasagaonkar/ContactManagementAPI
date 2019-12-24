using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Contact.Models;
using Contact.Business.Contract;
using Contact.Business.Implementation;
using System.Net;

namespace Contact.API.Controllers
{
    [Authorize]
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        private readonly IContactBusiness _contactBusiness;      
        //public HomeController(IContactBusiness contactBusiness)
        //{
        //    this._contactBusiness = contactBusiness;
        //}
        //[HttpPost]
        //[Route("add")]
        //public HttpResponseMessage Submit(User user)
        //{
        //    var model = _contactBusiness.Add(user);
        //    if (model.StatusCode.Equals("200"))
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }

        //}

        //[Route("list")]
        //[AllowAnonymous]   
        //[HttpGet]    
        //public HttpResponseMessage List()
        //{
        //    var model = _contactBusiness.List();
        //    if (model.StatusCode.Equals("200"))
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }
        //}

        //[HttpPost]
        //[Route("update")]
        //public HttpResponseMessage Edit(User user)
        //{
        //    var model = _contactBusiness.Edit(user);
        //    if (model.StatusCode.Equals("200"))
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }
        //}

        //[HttpPost]
        //[Route("EditStatus")]
        //public HttpResponseMessage EditStatus(int id, bool status)
        //{
        //    var model = _contactBusiness.Edit(id,status);
        //    if (model.StatusCode.Equals("200"))
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(model.StatusCode, model);
        //    }
        //}        
    }
}
