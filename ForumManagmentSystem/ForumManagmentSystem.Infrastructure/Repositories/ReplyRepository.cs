using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        public Task<ReplyDb> Create(ReplyDb reply)
        {
            throw new NotImplementedException();
        }

        public Task<ReplyDb> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReplyDb>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReplyDb>> GetLikedRepliesFromUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReplyDb>> GetRepliesFromUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReplyDb>> PostReplies(string postTitle)
        {
            throw new NotImplementedException();
        }

        public Task<ReplyDb> Update(Guid id, ReplyDb newReply)
        {
            throw new NotImplementedException();
        }
    }
}
