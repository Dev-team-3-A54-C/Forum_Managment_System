using AutoMapper;
using ForumManagmentSystem.Core.Helpers.MappingConfig;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using System.Linq;

namespace ForumManagmentSystem.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostsRepository postsRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper autoMapper;
        public PostService(IPostsRepository pRepo, IUsersRepository uRepo, IMapper mapper)
        {
            postsRepository = pRepo;
            usersRepository = uRepo;
            autoMapper = mapper;
        }

        public PostDb CreatePost(UserDb user, string title, string content)
        {
            PostDb newPost = new PostDb();
            newPost.Title = title;
            newPost.Content = content;
            newPost.User = user;
            return postsRepository.Create(newPost);
        }



        public PostResponseDTO Get(Guid id)
        {
            PostDb temp = postsRepository.GetById(id);
            return new PostResponseDTO()
            {
                Title = temp.Title,
                Content = temp.Content,
                Likes = temp.LikesCount,
                CreatedBy = temp.User.Username
            };
        }

        public PostResponseDTO Get(string title)
        {
            PostDb temp = postsRepository.GetByTitle(title);
            return new PostResponseDTO()
            {
                Title = temp.Title,
                Content = temp.Content,
                Likes = temp.LikesCount,
                CreatedBy = temp.User.Username
            };
        }

        public IList<PostResponseDTO> GetAll()
        {
            //IList<PostResponseDTO> result = postsRepository.GetAll()
            //    .Select(x => new PostResponseDTO()
            //    {
            //        Title = x.Title,
            //        Content = x.Content,
            //        Likes = x.LikesCount,
            //        CreatedBy = x.User.Username
            //    })
            //    .ToList();

            IList<PostResponseDTO> result = postsRepository.GetAll()
            .Select(x => autoMapper.Map<PostResponseDTO>(x))
            .ToList();
           //TODO: check if thats the right way to map
            return result.ToList();
        }

        public PostDb Update(Guid postId, UserDTO user, PostDTO newData)
        {
            PostDb p = postsRepository.GetByTitle(newData.Title);
            return postsRepository.Update(postId, p);
        }
        public void Delete(UserDb user, Guid postId)
        {
            postsRepository.Delete(postId); // should delete post from user's posts and from all posts
        }
        public bool AddLike(Guid userID, Guid postID)
        {
            UserDb u = usersRepository.GetById(userID);
            PostDb p = postsRepository.GetById(postID);
            
            PostLikesDb postLikesDb = new PostLikesDb()
            {
                UserId = userID,
                PostId = postID,
                User = u,
                Post = p
            };

            if (u.LikedPosts.Contains(postLikesDb))
            {
                return postsRepository.RemoveLike(postLikesDb);
            }
            return postsRepository.AddLike(postLikesDb);
        }
    }
}
