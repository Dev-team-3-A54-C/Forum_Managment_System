using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    internal class PostDb
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public Guid UserId { get; set; }
        public virtual UserDb User { get; set; }
        public virtual ICollection<ReplyDb> Replies { get; set; } = new HashSet<ReplyDb>();
    }
}
