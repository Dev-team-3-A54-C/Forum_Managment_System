using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;

namespace ForumManagmentSystem.Core.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository replyRepository;
        private readonly IUsersRepository userRepository;
        private readonly IPostsRepository postsRepository;
        private readonly IMapper mapper;

        public ReplyService(IReplyRepository replyRepository,
            IUsersRepository userRepository,
            IPostsRepository postsRepository,
            IMapper mapper)
        {
            this.replyRepository = replyRepository;
            this.userRepository = userRepository;
            this.postsRepository = postsRepository;
            this.mapper = mapper;
        }
        public IEnumerable<ReplyResponseDTO> GetAll()
        {
            var replies = replyRepository.GetAll().Result.Select(r => mapper.Map<ReplyResponseDTO>(r));

            return replies;
        }

        public IEnumerable<ReplyResponseDTO> GetLikedRepliesFromUser(string username)
        {
            if (!userRepository.UserExists(username))
            {
                throw new EntityNotFoundException($"User with name {username} does not exist.");
            }

            var replies = replyRepository.GetLikedRepliesFromUser(username).Result.Select(r => mapper.Map<ReplyResponseDTO>(r));

            return replies;

        }

        public IEnumerable<ReplyResponseDTO> GetRepliesFromPost(string postTitle)
        {
            if (!postsRepository.PostExists(postTitle))
            {
                throw new EntityNotFoundException($"Post with title {postTitle} does not exist.");
            }

            var replies = replyRepository.GetRepliesFromPost(postTitle).Result.Select(r => mapper.Map<ReplyResponseDTO>(r));

            return replies;
        }

        public IEnumerable<ReplyResponseDTO> GetRepliesMadeByUser(string username)
        {
            if (!userRepository.UserExists(username))
            {
                throw new EntityNotFoundException($"User with name {username} does not exist.");
            }

            var replies = replyRepository.GetRepliesFromUser(username).Result.Select(r => mapper.Map<ReplyResponseDTO>(r));

            return replies;
        }
        public ReplyResponseDTO Create(ReplyDTO reply)
        {
            if (!userRepository.UserExists(reply.CreatedBy))
            {
                throw new EntityNotFoundException($"User with name {reply.CreatedBy} does not exist.");
            }

            if (!postsRepository.PostExists(reply.PostTitle))
            {
                throw new EntityNotFoundException($"Post with title {reply.PostTitle} does not exist.");
            }

            var newReply = replyRepository.Create(mapper.Map<ReplyDb>(reply)).Result;

            return mapper.Map<ReplyResponseDTO>(newReply);
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
