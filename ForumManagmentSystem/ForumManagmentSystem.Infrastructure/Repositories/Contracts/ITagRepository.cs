﻿using ForumManagmentSystem.Infrastructure.Data.Models;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface ITagRepository
    {
        Task<TagDb> GetByName(string name);
        Task<TagDb> GetById(Guid id);
        Task<IEnumerable<TagDb>> GetAll();
        Task<bool> DoesNameExist(string name);
        Task<TagDb> Create(TagDb newTag);
        Task<TagDb> Update(TagDb name);
        Task<TagDb> Delete(string name);
        Task<TagDb> Delete(Guid id);
    }
}
