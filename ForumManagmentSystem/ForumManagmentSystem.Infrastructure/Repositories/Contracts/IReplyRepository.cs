using ForumManagmentSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface IReplyRepository
    {
        Task<IEnumerable<ReplyDb>> GetAll();
        Task<IEnumerable<ReplyDb>> GetRepliesFromUser(string username);
        Task<IEnumerable<ReplyDb>> GetLikedRepliesFromUser(string username);
        Task<IEnumerable<ReplyDb>> PostReplies(string postTitle);
        Task<ReplyDb> Create(ReplyDb reply);
        Task<ReplyDb> Update(Guid id, ReplyDb newReply);
        Task<ReplyDb> Delete(Guid id);
    }
}
