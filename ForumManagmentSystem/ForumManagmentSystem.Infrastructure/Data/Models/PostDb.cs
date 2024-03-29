﻿using ForumManagmentSystem.Infrastructure.Data.Models.Contracts;

namespace ForumManagmentSystem.Infrastructure.Data.Models
{
    public class PostDb : ISoftDelete
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; 
        public int LikesCount { get; set; }
        public Guid CreatedBy { get; set; }
        public virtual UserDb User { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public virtual ICollection<PostLikesDb> Likes { get; set; } = new HashSet<PostLikesDb>();
        public virtual ICollection<ReplyDb> Replies { get; set; } = new HashSet<ReplyDb>();
        public virtual ICollection<PostTagsDb> Tags { get; set; } = new HashSet<PostTagsDb>();
    }
}
