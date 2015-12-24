using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Handle_KNSER.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Handle_KNSER.Controllers
{
    public class MembersController : ApiController
    {

        private AuthContext _repo = new AuthContext();
        //public AngularJSAuthesEntities _db = new AngularJSAuthesEntities();
        // GET: api/Members

        //GET
        [HttpGet]
        public IEnumerable<Member> GetListMember()
        {
            return _repo.Members.AsEnumerable();
        }

        //GET/api/{id}
        public Member GetMember(int id)
        {
            Member mem = new Member();
            mem = _repo.Members.Find(id);
            if (mem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return mem;
        }

        // POST api/controller
        public HttpResponseMessage Post(Member mem)
        {
            if (ModelState.IsValid)
            {
                _repo.Members.Add(mem);
                _repo.SaveChanges();
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.Created, mem);
                reponse.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mem.MemberId }));
                return reponse;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //PUT api/controller/5
        public HttpResponseMessage Put(int id, Member mem)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if(id != mem.MemberId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            _repo.Entry(mem).State = EntityState.Modified;

            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException  ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
      
        //DELETE api/controller/5
        public HttpResponseMessage Delete(int id)
        {
            Member mem = _repo.Members.Find(id);
            if(mem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
            mem.isActive = false;
            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, mem);  
        }
      
    }
}
