using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Services
{
    public interface IPostService
    {
        PostDb CreatePost(UserDb user, string title, string content);
        IList<PostResponseDTO> GetAll();
        PostResponseDTO Get(int id);
        PostResponseDTO Get(string title);
        PostDb Update(int postId, UserDTO user, PostDTO newData);
        void Delete(UserDb user, int postId);
    }
}
