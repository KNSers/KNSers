using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Handle_KNSER.Entities
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public int KNSId { get; set; }
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public string University { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int Term { get; set; }

        public string KNSRole { get; set; }

    }
}