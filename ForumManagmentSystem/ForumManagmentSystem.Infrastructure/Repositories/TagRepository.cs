﻿using ForumManagmentSystem.Infrastructure.Data;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace ForumManagmentSystem.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FMSContext context;

        public TagRepository(FMSContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TagDb>> GetAll()
        {
            var tags = await context.Tags.ToListAsync();

            return tags;
        }

        public async Task<TagDb> GetByName(string name)
        {
            var tag = await context
                .Tags
                .FirstOrDefaultAsync(x => x.Name == name) ?? throw new EntityNotFoundException($"Tag with name: {name} does not exist.");

            return tag;
        }

        public async Task<bool> DoesNameExist(string name)
        {
            return await context
                .Tags
                .FirstOrDefaultAsync(x => x.Name == name) != null;
        }

        public async Task<TagDb> Create(TagDb newTag)
        {
            await context.Tags.AddAsync(newTag);
            return newTag;
        }

        public async Task<TagDb> Update(TagDb newTag)
        {
            var tagToUpdate = await context
            .Tags
                .FirstOrDefaultAsync(t => t.Id == newTag.Id) ?? throw new EntityNotFoundException($"Tag with Id: {newTag.Id} does not exist.");

            tagToUpdate.Name = newTag.Name;

            await context.SaveChangesAsync();

            return tagToUpdate;
        }
        public async Task<TagDb> Delete(string name)
        {
            var tagForDeletion = await context
                .Tags
                .FirstOrDefaultAsync(t => t.Name == name) ?? throw new EntityNotFoundException($"Tag with name: {name} does not exist.");

            context.Tags.Remove(tagForDeletion);

            await context.SaveChangesAsync();

            return tagForDeletion;
        }


    }
}
