using Handle_KNSER.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Handle_KNSER.Controllers
{
    public class LetterController : ApiController
    {
        private AuthContext _repo = new AuthContext();
        //public AngularJSAuthesEntities _db = new AngularJSAuthesEntities();
        // GET: api/Members

        [HttpGet]
        public List<Letter> Get()
        {
            List<Letter> listLetters = new List<Letter>();
            listLetters = _repo.Letters.ToList();
            return listLetters;
        }

        [HttpPost]
        public HttpResponseMessage Post(Request request)
        {
            if (ModelState.IsValid)
            {
                _repo.Requests.Add(request);
                _repo.SaveChanges();
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.Created, request);
                reponse.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = request.MemberId }));
                return reponse;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
