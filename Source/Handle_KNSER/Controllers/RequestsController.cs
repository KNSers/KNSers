using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace Handle_KNSER.Controllers
{
    public class RequestsController : ApiController
    {

        private AuthContext _repo = new AuthContext();
        [HttpGet]

        public HttpResponseMessage get()
        {
            if (ModelState.IsValid)
            {

                var query = from member in _repo.Members
                             join request in _repo.Requests on member.MemberId equals request.MemberId.MemberId
                             join letter in _repo.Letters on request.LetterId.LetterId equals letter.LetterId
                             select new 
                             {
                                 fullname = member.Fullname,
                                 letter = letter.Description,
                                 startdate = request.StartDate,
                                 enddate = request.EndDate,
                                 reason = request.Reason
                             };

                return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            
        }
    }
}
