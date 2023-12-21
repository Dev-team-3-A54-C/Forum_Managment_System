using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Services
{
    public interface IPostService
    {
        PostDb CreatePost(UserDb user, string title, string content);
        List<PostResponseDTO> GetAll();
        PostResponseDTO Get(int id);
        PostResponseDTO Get(string title);
        PostDb Update(int postId, UserDb user, PostDb newData);
        void Delete(UserDb user, int postId);
    }
}
