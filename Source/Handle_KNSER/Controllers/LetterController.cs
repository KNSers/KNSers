using Handle_KNSER.Entities;
using Handle_KNSER.Models;
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
        public HttpResponseMessage Post([FromBody]LetterRequest request)
        {
            if (ModelState.IsValid)
            {
                var _MemberId = _repo.Members.SingleOrDefault(s => s.KNSId == request.MemberId);
                if (_MemberId == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    Entities.Request req = new Request();
                    req.MemberId = _MemberId.MemberId;
                    req.LetterId = request.LetterId;
                    req.Reason = request.Reason;
                    req.StartDate = DateTime.Now;
                    req.EndDate = DateTime.Now;
                    _repo.Requests.Add(req);
                    _repo.SaveChanges();
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
