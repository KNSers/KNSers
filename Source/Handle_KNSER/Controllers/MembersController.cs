using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Handle_KNSER.Entities;

namespace Handle_KNSER.Controllers
{
    public class MembersController : ApiController
    {


        //public AngularJSAuthesEntities _db = new AngularJSAuthesEntities();
        // GET: api/Members

        [Authorize]
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        // GET: api/Members/5
        [Authorize]
       //// public List<Member> Get(int id)
       // {
       //     id = 1;
       //     List<Member> Members = new List<Member>();
       //     Members = _db.Members.ToList();
       //     return Members;
       // }

        // POST: api/Members
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Members/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Members/5
        public void Delete(int id)
        {
        }
    }
}
