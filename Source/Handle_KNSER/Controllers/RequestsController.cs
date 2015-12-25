using Handle_KNSER.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Handle_KNSER.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RequestsController : ApiController
    {

        private AuthContext _repo = new AuthContext();


        [HttpGet]
        [Route("api/Requests/Get")]
        public HttpResponseMessage get()
        {
            if (ModelState.IsValid)
            {

                var query = from member in _repo.Members
                             join request in _repo.Requests on member.MemberId equals request.MemberId.MemberId
                             join letter in _repo.Letters on request.LetterId.LetterId equals letter.LetterId
                             select new 
                             {
                                 requestid = request.RequestId,
                                 memberid = request.MemberId,
                                 letterid= letter.LetterId,
                                 fullname = member.Fullname,
                                 letter = letter.Description,
                                 startdate = request.StartDate,
                                 enddate = request.EndDate,
                                 reason = request.Reason,
                                 approval = request.Approval,
                             };
                return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }



        [HttpPut]
        public HttpResponseMessage Put(string id, Request request)
        {
            if (id != request.RequestId.ToString())
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _repo.Entry(request).State = EntityState.Modified;

            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
            //return Request.CreateResponse(HttpStatusCode.OK, request.MemberId);
        }
    }
}
