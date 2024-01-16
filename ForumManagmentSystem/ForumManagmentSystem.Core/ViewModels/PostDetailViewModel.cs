using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Core.ViewModels
{
    public class PostDetailViewModel
    {
        public PostResponseDTO Post { get; set; }
        public ReplyDTO Reply { get; set; }
    }
}
