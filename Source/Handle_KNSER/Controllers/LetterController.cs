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

                var UserName = ClaimsPrincipal.Current.Identity.Name;

                var _MemberId = _userInfo.Users.SingleOrDefault(s => s.UserName == UserName).KNSId;                
                //var _MemberId. = _repo.Members.SingleOrDefault(s => s.KNSId == request.MemberId);
                if (String.IsNullOrEmpty(_MemberId.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    Entities.Request req = new Request();
                    req.MemberId = _MemberId;
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
