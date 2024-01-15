using ForumManagmentSystem.Infrastructure.Data;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace ForumManagmentSystem.Infrastructure.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly FMSContext context;

        public ReplyRepository(FMSContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ReplyDb>> GetAll()
        {
            var replies = await context.Replies.ToListAsync();

            return replies;
        }

        public async Task<ReplyDb> GetById(Guid id)
        {
            var reply = await context
                .Replies
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new EntityNotFoundException($"Reply with id {id.ToString()} does not exist.");

            return reply;
        }

        public async Task<IEnumerable<ReplyLikesDb>> GetLikedRepliesFromUser(string username)
        {
            var userLikedReplies = await context.ReplyLikes
                .Include(rl => rl.Reply)
                .Include(rl => rl.User)
                .Where(r => r.User.Username == username)
                .ToListAsync();

            return userLikedReplies;
        }

        public async Task<IEnumerable<ReplyDb>> GetRepliesFromUser(string username)
        {
            var userReplies = await context.Replies
                .Include(r => r.User)
                .Where(r => r.User.Username == username)
                .ToListAsync();

            return userReplies;
        }
        public async Task<IEnumerable<ReplyDb>> GetRepliesFromPost(string postTitle)
        {
            var postReplies = await context.Replies
                .Include(r => r.Post)
                .Where(r => r.Post.Title == postTitle)
                .ToListAsync();

            return postReplies;
        }

        public async Task<ReplyDb> Create(ReplyDb reply)
        {
            await context.Replies.AddAsync(reply);
            return reply;
        }
        public async Task<ReplyDb> Update(Guid id, ReplyDb newReply)
        {
            var replyForUpdate = await context
                .Replies
                .FirstOrDefaultAsync(r => r.Id == id) ?? throw new EntityNotFoundException($"Reply with Id: {id} does not exist.");  

            replyForUpdate.Content = newReply.Content;

            await context.SaveChangesAsync();

            return replyForUpdate;
        }
        public async Task<ReplyDb> AddLike(ReplyLikesDb replyLike)
        {
            await context.ReplyLikes.AddAsync(replyLike);

            var reply = await context
                .Replies
                .FirstOrDefaultAsync(r => r.Id == replyLike.ReplyId) ?? throw new EntityNotFoundException($"Reply with Id: {replyLike.ReplyId} does not exist.");

            reply.LikesCount++;

            var user = await context
                .Users
                .FirstOrDefaultAsync(u => u.Id == replyLike.UserId) ?? throw new EntityNotFoundException($"User with Id: {replyLike.UserId} does not exist.");

            user.MyLikedReplies.Add(replyLike);

            await context.SaveChangesAsync();

            return reply;
        }
        public async Task<ReplyDb> RemoveLike(ReplyLikesDb replyLike)
        {
            var replyLikeForDeletion = await context.ReplyLikes.FirstOrDefaultAsync(rl => rl.UserId == replyLike.UserId && rl.ReplyId == replyLike.ReplyId) ?? throw new EntityNotFoundException($"There is no like from user {replyLike.UserId} on reply {replyLike.ReplyId}.");

            var reply = await context
                .Replies
                .FirstOrDefaultAsync(r => r.Id == replyLike.ReplyId) ?? throw new EntityNotFoundException($"Reply with Id: {replyLike.ReplyId} does not exist.");

            reply.LikesCount--;

            var user = await context
                .Users
                .FirstOrDefaultAsync(u => u.Id == replyLike.UserId) ?? throw new EntityNotFoundException($"User with Id: {replyLike.UserId} does not exist.");


            user.MyLikedReplies.Remove(replyLikeForDeletion);

            context.ReplyLikes.Remove(replyLikeForDeletion);

            await context.SaveChangesAsync();

            return reply;
        }

        public async Task<ReplyDb> Delete(Guid id)
        {
            var replyForDeletion = await context.Replies.FirstOrDefaultAsync(r => r.Id == id);

            context.Replies.Remove(replyForDeletion);

            context.SaveChanges();

            return replyForDeletion;

        }

        public async Task<bool> ReplyExist(Guid id)
        {
            return await context.Replies.AnyAsync(r => r.Id == id);
        }
    }
}
