using ForumManagmentSystem.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Core.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public int Likes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<PostReplyResponseDTO> Replies { get; set; }
    }
}
