using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handle_KNSER.Models
{
    public class LetterRequest
    {
        public int LetterId { get; set; }
        public int MemberId { get; set; }
        public string Reason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Boolean Approval { get; set; }
    }
}