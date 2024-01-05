using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
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

        public PostDb CreatePost(UserDb user, string title, string content)
        {
            PostDb newPost = new PostDb();
            newPost.Title = title;
            newPost.Content = content;
            newPost.User = user;
            return postsRepository.Create(newPost);
        }



        public PostResponseDTO Get(int id)
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
            PostDb temp = postsRepository.GetByName(title);
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

        public PostDb Update(int postId, UserDTO user, PostDTO newData)
        {
            UserDb u = usersRepository.GetByName(user.Username);
            PostDb p = postsRepository.GetByName(newData.Title);
            return postsRepository.Update(postId, p);
        }
        public void Delete(UserDb user, int postId)
        {
            postsRepository.Delete(postId); // should delete post from user's posts and from all posts
        }
    }
}
