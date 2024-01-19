using ForumManagmentSystem.Infrastructure.Data;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using ForumManagmentSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
namespace ForumManagmentSystem.Infrastructure.Repositories
{
    public class PostRepository : IPostsRepository
    {
        private readonly FMSContext _context;
        public PostRepository(FMSContext c)
        {
            _context = c;
        }

        public IList<PostDb> GetAll()
        {
            return _context.Posts.Include(p => p.User).Include(p => p.Replies).ToList();
        }

        public IEnumerable<PostDb> GetAllLikedByUser(string username)
        {
            return _context.PostLikes
                .Include(pl => pl.User)
                .Include(pl => pl.Post)
                .Select(pl => pl.Post)
                .Where(pl=> pl.User.Username == username)
                .ToList();
        }
        public PostDb GetById(Guid id)
        {
            return _context.Posts.Include(p => p.Replies).Include(p => p.User).FirstOrDefault(p => p.Id == id) ??
                throw new EntityNotFoundException($"Post with id {id} not found.");
        }
        public PostDb GetByTitle(string title)
        {
            return _context.Posts.Include(p => p.User).Include(p => p.Replies).ThenInclude(r => r.User).FirstOrDefault(p => p.Title == title) ??
                throw new EntityNotFoundException($"Post with title:{title} not found.");
        }
        public IEnumerable<PostDb> GetTopTenByComments()
        {
            return _context.Posts.
                Include(p => p.Replies)
                .OrderByDescending(p => p.Replies.Count)
                .Take(10);
        }
        public IEnumerable<PostDb> GetTopTenRecent()
        {
            return _context.Posts                
                .OrderByDescending(p => p.CreatedOn)
                .Take(10);
        }
        public PostDb Create(PostDb newPost)
        {
            _context.Posts.Add(newPost);
            _context.SaveChanges();
            return newPost;
        }
        public PostDb Update(Guid id, PostDb post)
        {
            PostDb toUpdate = GetById(id);
            toUpdate.Title = post.Title;
            toUpdate.Content = post.Content;

            _context.SaveChanges();
            return toUpdate;

        }
        public PostDb Delete(Guid id)
        {
            PostDb toDelete = GetById(id);
            _context.Posts.Remove(toDelete);
            _context.SaveChanges();

            return toDelete;
        }
        public bool PostExists(string name)
        {
            return _context.Posts.Any(p => p.Title.Equals(name));
        }
        public int Count()
        {
            return _context.Posts.Count();
        }
        public bool AddLike(PostLikesDb postlikesDb)
        {
            _context.PostLikes.Add(postlikesDb);
            _context.SaveChanges();
            return true;
        }
        public bool RemoveLike(PostLikesDb postlikesDB)
        {

            var existingLike = _context.PostLikes
                .FirstOrDefault(pl => pl.PostId == postlikesDB.PostId && pl.UserId == postlikesDB.UserId);

            if (existingLike != null)
            {
                _context.PostLikes.Remove(existingLike);
                _context.SaveChanges();
                return true;
            }
            //_context.PostLikes.Remove(postlikesDB);
            //_context.SaveChanges();
            return false;
        }
        
    }
}
