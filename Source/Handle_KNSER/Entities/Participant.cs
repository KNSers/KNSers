using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Handle_KNSER.Entities
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }
        public virtual Event Event { get; set; }
        public virtual Member Member { get; set; }
        public DateTime? PartDate { get; set; }
        public string EventRole { get; set; }
        public decimal PartScore { get; set; }
    }
}