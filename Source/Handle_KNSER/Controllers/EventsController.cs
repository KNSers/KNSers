using Handle_KNSER.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Handle_KNSER.Controllers
{
    public class EventsController : ApiController
    {

        private AuthContext _repo = new AuthContext();


        [HttpGet]
        [Route("api/Events/Get")]
        public HttpResponseMessage get()
        {
            if (ModelState.IsValid)
            {

                var query = from events in _repo.Events
                            select new
                            {
                                EventId = events.EventId,
                                OtherId = events.OtherId,
                                EventName = events.Name,
                                leaderid = events.MemberId,
                                fullname = events.Member.Fullname,
                                startdate = events.StartDate,
                                enddate = events.EndDate,
                                description = events.Description
                            };
                return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpGet]
        public HttpResponseMessage getEventDetails(int id)
        {
            if (ModelState.IsValid)
            {
                var query = _repo.Participants.Where(s => s.Event.EventId == id)
                                 .Select(x => new
                                 {
                                     x.Event.StartDate,
                                     x.Event.EventId,
                                     x.Event.EndDate,
                                     x.Event.Member.Fullname,
                                     x.Event.Member.KNSId,
                                     x.Event.Score,
                                     x.Event.Name,
                                     x.Event.OtherId,
                                     x.Member,
                                     x.PartDate
                                 });
                if (query == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
                return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }   
    }
}
