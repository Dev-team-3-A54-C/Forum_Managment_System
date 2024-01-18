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

        public ReplyResponseDTO Get(Guid id)
        {
            var reply = replyRepository.GetById(id);

            return mapper.Map<ReplyResponseDTO>(reply);
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

            var user = userRepository.GetByName(reply.CreatedBy);
            var post = postsRepository.GetByTitle(reply.PostTitle);

            reply.CreatedBy = user.Id.ToString();

            var replyDb = mapper.Map<ReplyDb>(reply);

            replyDb.PostId = post.Id;
            replyDb.CreatedOn = DateTime.Now;

            var newReply = replyRepository.Create(replyDb).Result;
            return mapper.Map<ReplyResponseDTO>(newReply);
        }
        public ReplyResponseDTO AddLike(Guid userId, Guid replyId)
        {
            var replyLike = new ReplyLikesDb();
            replyLike.UserId = userId;
            replyLike.ReplyId = replyId;


            var user = userRepository.GetById(userId);
            
            if(user.MyLikedReplies.Any(lr => lr.ReplyId.ToString() == replyId.ToString()))
            {
                replyRepository.RemoveLike(replyLike);
            }
            else
            {
                replyRepository.AddLike(replyLike);
            }

            var reply = replyRepository.GetById(replyId).Result;
            
            return mapper.Map<ReplyResponseDTO>(reply);
        }
        public ReplyResponseDTO Update(Guid id, ReplyDTO reply)
        {
            if(!replyRepository.ReplyExist(id).Result)
            {
                throw new EntityNotFoundException($"Reply with id {id} does not exist.");
            }

            var updatedReply = replyRepository.Update(id, mapper.Map<ReplyDb>(reply)).Result;

            return mapper.Map<ReplyResponseDTO>(updatedReply);
        }

        public ReplyResponseDTO Delete(Guid replyId, string username)
        {
            var deletedReply = replyRepository.Delete(replyId).Result;

            return mapper.Map<ReplyResponseDTO>(deletedReply);
        }

		public ReplyResponseDTO Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
