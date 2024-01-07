using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services.Contracts;

namespace ForumManagmentSystem.Core.Services
{
    public class ReplyService : IReplyService
    {
        public ReplyResponseDTO AddLike(ReplyDTO reply)
        {
            throw new NotImplementedException();
        }

        public ReplyResponseDTO Create(ReplyDTO reply)
        {
            throw new NotImplementedException();
        }

        public ReplyResponseDTO Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReplyResponseDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReplyResponseDTO> GetLikedRepliesFromUser(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReplyResponseDTO> GetRepliesFromPost(string postTitle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReplyResponseDTO> GetRepliesMadeByUser(string username)
        {
            throw new NotImplementedException();
        }

        public ReplyResponseDTO Update(Guid id, ReplyDTO reply)
        {
            throw new NotImplementedException();
        }
    }
}
