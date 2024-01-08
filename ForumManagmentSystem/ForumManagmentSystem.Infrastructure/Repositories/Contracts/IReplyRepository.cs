using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface IReplyRepository
    {
        Task<IEnumerable<ReplyDb>> GetAll();
        Task<ReplyDb> GetById(Guid id);
        Task<IEnumerable<ReplyDb>> GetRepliesFromUser(string username);
        Task<IEnumerable<ReplyLikesDb>> GetLikedRepliesFromUser(string username);
        Task<IEnumerable<ReplyDb>> GetRepliesFromPost(string postTitle);
        Task<ReplyDb> Create(ReplyDb reply);
        Task<ReplyDb> Update(Guid id, ReplyDb newReply);
        Task<ReplyDb> AddLike(ReplyLikesDb replyLike);
        Task<ReplyDb> RemoveLike(ReplyLikesDb replyLike);
        Task<ReplyDb> Delete(Guid id);
        Task<bool> ReplyExist(Guid id);
    }
}
