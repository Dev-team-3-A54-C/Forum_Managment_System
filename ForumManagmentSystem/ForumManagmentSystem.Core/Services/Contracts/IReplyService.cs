using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface IReplyService
    {
        IEnumerable<ReplyResponseDTO> GetAll();
        IEnumerable<ReplyResponseDTO> GetRepliesMadeByUser(string username);
        IEnumerable<ReplyResponseDTO> GetLikedRepliesFromUser(string username);
        IEnumerable<ReplyResponseDTO> GetRepliesFromPost(string postTitle);
        ReplyResponseDTO Create(ReplyDTO reply);
        ReplyResponseDTO Update(Guid id, ReplyDTO reply);
        ReplyResponseDTO AddLike(AddReplyLikeDTO reply);
        ReplyResponseDTO Delete(Guid id);
    }
}
