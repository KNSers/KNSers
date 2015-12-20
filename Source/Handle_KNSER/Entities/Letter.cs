using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Handle_KNSER.Entities
{
    public class Letter
    {
        [Key]
        public int LetterId { get; set; }
        public string Description { get; set; }
    }
}