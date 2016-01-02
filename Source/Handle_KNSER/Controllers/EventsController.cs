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
        [Route("api/Events/GetDetails")]
        public HttpResponseMessage getDetails(string id)
        {
            Event ev = new Event();
            if (ModelState.IsValid)
            {
                int Id = int.Parse(id);
                ev = _repo.Events.SingleOrDefault(s => s.EventId == Id);

                if (ev == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, ev);

            
        }

    }
}
