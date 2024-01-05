using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class ReplyLikesDb
    {
        public Guid ReplyId { get; set; }
        public ReplyDb Reply { get; set; }
        public Guid UserId { get; set; }
        public UserDb User { get; set; }

    }
}
