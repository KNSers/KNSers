using Handle_KNSER.Entities;
using Microsoft.AspNet.Identity;
using Handle_KNSER.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Handle_KNSER.Controllers
{
    public class LetterController : ApiController
    {
        private AuthContext _repo = new AuthContext();


        /// <summary>
        /// Object dùng để xác định những thông tin hiện hành của tài khoản
        /// </summary>
        private UserManager<MemberUser> _userInfo = new UserManager<MemberUser>(new UserStore<MemberUser>(new AuthContext()));
        
        // GET: api/Members

        [Authorize]
        [HttpGet]
        public List<Letter> Get()
        {
            List<Letter> listLetters = new List<Letter>();
            listLetters = _repo.Letters.ToList();
            return listLetters;
        }


        //[HttpGet]
        //public string GetString()
        //{
        //    //string name = User.Identity.Name;
        //    ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

        //    var Name = ClaimsPrincipal.Current.Identity.Name;
        //    var Name1 = User.Identity.Name;

        //    //var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;
        //    return Name;
        //}

        [HttpPost]
        [Route("api/Letter/Create")]
        public HttpResponseMessage Post([FromBody]LetterRequest request)
        {
            
            if (ModelState.IsValid)
            {
                // Object dùng để lấy UserId hienej hành
                ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

                var UserIdPresent = ClaimsPrincipal.Current.Identity.Name;
                //var demo = from s in _userInfo.Users
                //           select s.Fullname;

                try
                {
                    //var _MemberUserId = _userInfo.FindByName(UserIdPresent);
                    var _MemberId = _repo.Members.SingleOrDefault(s => s.KNSId == request.MemberId);
                    Entities.Request req = new Request();
                    req.MemberId = _MemberId.MemberId;
                    req.LetterId = request.LetterId;
                    req.Reason = request.Reason;
                    req.StartDate = DateTime.Now;
                    req.EndDate = DateTime.Now;
                    _repo.Requests.Add(req);
                    _repo.SaveChanges();
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
