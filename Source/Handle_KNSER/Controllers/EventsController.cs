using Handle_KNSER.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Handle_KNSER.Controllers
{
    public class EventsController : ApiController
    {
        private UserManager<MemberUser> _userInfo = new UserManager<MemberUser>(new UserStore<MemberUser>(new AuthContext()));
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
                                     x.PartScore,
                                     x.Event.Member.KNSId,
                                     x.Event.Score,
                                     x.Event.Name,
                                     x.Event.OtherId,
                                     x.EventRole,
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

        /// <summary>
        /// Tham gia chương trình. Phải cập nhật lại entity
        /// </summary>
        /// <param name="EventId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Events/Participant")]
        public HttpResponseMessage participant([FromBody]int EventId)
        {
            //if (ModelState.IsValid)
            //{
            //    ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            //    var UserIdPresent = ClaimsPrincipal.Current.Identity.Name;

            //    var _KNSId = _userInfo.Users.SingleOrDefault(s => s.UserName == UserIdPresent).KNSId;
            //    if (_KNSId == null)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.NotFound);
            //    }
            //    else
            //    {
            //        var _MemberId = _repo.Members.SingleOrDefault(s => s.KNSId == _KNSId).MemberId;
            //        if (_MemberId == null)
            //        {
            //            return Request.CreateResponse(HttpStatusCode.NotFound);
            //        }
            //        else
            //        {
            //            var Parted = (from p in _repo.Participants
            //                     where p.Event.EventId == EventId &&
            //                     p.Member.MemberId == _MemberId
            //                              select p.ParticipantId).Count();
            //            if (Parted == 0)
            //            {
            //                Participant PartModel = new Participant();
            //                PartModel.Member.MemberId = _MemberId;
            //                PartModel.Event.EventId = EventId;
            //                PartModel.PartDate = DateTime.Now;
            //                PartModel.EventRole = "CTV";
            //                try
            //                {
            //                    //_repo.Participants.Add(PartModel);
            //                    //_repo.SaveChanges();
            //                    Request.CreateResponse(HttpStatusCode.Created);
            //                }
            //                catch (Exception e)
            //                {
            //                    Request.CreateResponse(HttpStatusCode.NotModified);    
            //                }
            //            }
            //                Request.CreateResponse(HttpStatusCode.NotModified);
            //        }
            //    }
            //}
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
