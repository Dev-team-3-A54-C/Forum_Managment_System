using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;

namespace ForumManagmentSystem.Core.Services
{
    public class PostService : IPostService
    {
        private const string UNAUTHORIZED_ERROR_MESSAGE = "User {0} is not authorized for this action.";

        private readonly IPostsRepository postsRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper autoMapper;
        public PostService(IPostsRepository pRepo, IUsersRepository uRepo, IMapper mapper)
        {
            postsRepository = pRepo;
            usersRepository = uRepo;
            autoMapper = mapper;
        }

        public PostResponseDTO CreatePost(string username, string title, string content)
        {
            if (postsRepository.PostExists(title))
            {
                throw new NameDuplicationException($"Post with title: {title} already exists.");
            }
            UserDb creator = usersRepository.GetByName(username);
            PostDb post = new PostDb()
            {
                Title = title,
                Content = content,
                User = creator,
                CreatedOn = DateTime.Now
            };
            return autoMapper.Map<PostResponseDTO>(postsRepository.Create(post));
        }



        public PostResponseDTO Get(Guid id)
        {
            PostDb temp = postsRepository.GetById(id);
            return autoMapper.Map<PostResponseDTO>(temp);
        }

        public PostResponseDTO Get(string title)
        {
            PostDb temp = postsRepository.GetByTitle(title);
            return autoMapper.Map<PostResponseDTO>(temp);
        }

        public IList<PostResponseDTO> GetAll()
        {
            return postsRepository.GetAll()
                .Select(p => autoMapper.Map<PostResponseDTO>(p))
                .ToList();
        }

        public int GetCount()
        {
            return postsRepository.Count();
        }

        public IList<PostResponseDTO> GetTopTenByComments()
        {
            return postsRepository.GetTopTenByComments()
               .Select(p => autoMapper.Map<PostResponseDTO>(p))
               .ToList();
        }

        public IList<PostResponseDTO> GetTopTenRecent()
        {
            return postsRepository.GetTopTenRecent()
                .Select(p => autoMapper.Map<PostResponseDTO>(p))
                .ToList();
        }       

        public PostResponseDTO Update(Guid postId, string username, PostDTO newData)
        {
            UserDb user = usersRepository.GetByName(username);
            
            PostDb p = new PostDb()
            {
                Title = newData.Title,
                Content = newData.Content,
            };
            if (!user.IsAdmin && !user.MyPosts.Contains(p))
            {
                throw new UnauthorizedOperationException
                    (String.Format(UNAUTHORIZED_ERROR_MESSAGE, user.Username));
            }
            return autoMapper.Map<PostResponseDTO>(postsRepository.Update(postId, p));
        }
        public PostResponseDTO Delete(string username, Guid postId)
        {
            UserDb user = usersRepository.GetByName(username);
            PostDb post = postsRepository.GetById(postId);
            if(!user.IsAdmin && !user.MyPosts.Contains(post))
            {
                throw new UnauthorizedOperationException
                    (String.Format(UNAUTHORIZED_ERROR_MESSAGE, user.Username));
            }
            return autoMapper.Map<PostResponseDTO>(postsRepository.Delete(postId));
        }
        public bool AddLike(Guid userID, Guid postID)
        {
            UserDb u = usersRepository.GetById(userID);
            PostDb p = postsRepository.GetById(userID);
            
            PostLikesDb postLikesDb = new PostLikesDb();
            postLikesDb.UserId = userID;
            postLikesDb.PostId = postID;
            if(u.LikedPosts.Contains(postLikesDb))
            {
                p.LikesCount--;
                return postsRepository.RemoveLike(postLikesDb);
            }
            p.LikesCount++;
            return postsRepository.AddLike(postLikesDb);
        }

    }
}
