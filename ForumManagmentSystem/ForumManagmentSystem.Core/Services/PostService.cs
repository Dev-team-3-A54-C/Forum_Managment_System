using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;

namespace ForumManagmentSystem.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostsRepository postsRepository;
        private readonly IUsersRepository usersRepository;
        public PostService(IPostsRepository pRepo, IUsersRepository uRepo)
        {
            postsRepository = pRepo;
            usersRepository = uRepo;
        }

        public PostResponseDTO CreatePost(string username, string title, string content)
        {
            UserDb user = usersRepository.GetByName(username);
            PostDb newPost = new PostDb();
            newPost.Title = title;
            newPost.Content = content;
            newPost.User = user;
            //TODO: Check if the name is unique
            //TODO: Use automapper
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
            IList<PostResponseDTO> result = postsRepository.GetAll()
                .Select(x =>  new PostResponseDTO()
                {
                    Title = x.Title,
                    Content = x.Content,
                    Likes = x.LikesCount,
                    CreatedBy = x.User.Username
                })
                .ToList();
            return result.ToList();
        }

        public PostResponseDTO Update(Guid postId, string username, PostDTO newData)
        {
            UserDb u = usersRepository.GetByName(username);
            PostDb p = postsRepository.GetByTitle(newData.Title);
            //TODO: map to postResponseDTO
            return postsRepository.Update(postId, p);
        }
        public void Delete(string username, Guid postId)
        {
            UserDb user = usersRepository.GetByName(username);
            PostDb post = postsRepository.GetById(postId);
            if(!user.IsAdmin && !user.MyPosts.Contains(post))
            {
                throw new UnauthorizedAccessException($"User {user.Username} is not authorized for this action.");
            }
            postsRepository.Delete(postId);
            user.MyPosts.Remove(post);
            // should delete post from user's posts and from all posts
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
                return postsRepository.RemoveLike(postLikesDb);
            }
            return postsRepository.AddLike(postLikesDb);
        }
    }
}
