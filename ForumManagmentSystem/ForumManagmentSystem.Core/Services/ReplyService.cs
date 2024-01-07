using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;

namespace ForumManagmentSystem.Core.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository replyRepository;
        private readonly IMapper mapper;

        public ReplyService(IReplyRepository replyRepository, IMapper mapper)
        {
            this.replyRepository = replyRepository;
            this.mapper = mapper;
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
        public ReplyResponseDTO Create(ReplyDTO reply)
        {
            throw new NotImplementedException();
        }
        public ReplyResponseDTO AddLike(ReplyDTO reply)
        {
            throw new NotImplementedException();
        }
        public ReplyResponseDTO Update(Guid id, ReplyDTO reply)
        {
            throw new NotImplementedException();
        }

        public ReplyResponseDTO Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
