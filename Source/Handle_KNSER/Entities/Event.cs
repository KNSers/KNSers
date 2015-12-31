using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Handle_KNSER.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string OtherId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal Score { get; set; }

        public int MemberId { get; set; }
        
        public virtual Member Member { get; set; }
        
    }
}