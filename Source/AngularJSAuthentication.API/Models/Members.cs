using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Members
    {
        public int MemberId { get; set; }
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string University { get; set; }
    }
}