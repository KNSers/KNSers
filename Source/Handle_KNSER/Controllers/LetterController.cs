using Handle_KNSER.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        [Route("api/Letter/Create")]
        public HttpResponseMessage Post(Request request)
        {
            if (ModelState.IsValid)
            {
                _repo.Requests.Add(request);
            }

            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
