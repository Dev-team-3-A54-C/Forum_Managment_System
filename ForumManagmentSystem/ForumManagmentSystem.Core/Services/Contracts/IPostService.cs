using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface IPostService
    {
        PostResponseDTO CreatePost(string username, PostDTO incomingPost);
        IList<PostResponseDTO> GetAll();
        IList<PostResponseDTO> GetAllFromUser(string username);
        IList<PostResponseDTO> GetAllLikedByUser(string username);
        IList<PostResponseDTO> GetTopTenByComments();
        IList<PostResponseDTO> GetTopTenRecent();
        int GetCount();
        PostResponseDTO Get(Guid id);
        PostResponseDTO Get(string title);
        PostResponseDTO Update(Guid postId, string username, PostDTO newData);
        PostResponseDTO Delete(string username, Guid postID);
        bool AddLike(Guid userID, Guid postID);
    }
}
