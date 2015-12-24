using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Handle_KNSER.Entities
{
    public class Notification
    {
        [Key]
        public string NotiId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}