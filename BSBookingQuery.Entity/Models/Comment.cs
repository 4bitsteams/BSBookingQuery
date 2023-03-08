using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBookingQuery.Entity.Models
{
    public class Comment :BaseEntity
    {
        public string CommentText { get; set; }

        public int? PageId { get; set; }
        public int? ParentId { get; set; }
        public int CommentBy { get; set; }
    }
}
