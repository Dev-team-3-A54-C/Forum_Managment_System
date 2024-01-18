using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface IReplyService
    {
        IEnumerable<ReplyResponseDTO> GetAll();
        ReplyResponseDTO Get(Guid id);
        IEnumerable<ReplyResponseDTO> GetRepliesMadeByUser(string username);
        IEnumerable<ReplyResponseDTO> GetLikedRepliesFromUser(string username);
        IEnumerable<ReplyResponseDTO> GetRepliesFromPost(string postTitle);
        ReplyResponseDTO Create(ReplyDTO reply);
        ReplyResponseDTO Update(Guid id, ReplyDTO reply);
        ReplyResponseDTO AddLike(Guid userId, Guid replyId);
        ReplyResponseDTO Delete(Guid id, string username);
    }
}
