using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface IPostService
    {
        PostResponseDTO CreatePost(string username, string title, string content);
        IList<PostResponseDTO> GetAll();
        IList<PostResponseDTO> GetTopTenByComments();
        IList<PostResponseDTO> GetTopTenRecent();
        int GetCount();
        PostResponseDTO Get(Guid id);
        PostResponseDTO Get(string title);
        PostResponseDTO Update(Guid postId, string username, PostDTO newData);
        PostResponseDTO Delete(string username, Guid postId);
        bool AddLike(Guid userID, Guid postID);


    }
}
