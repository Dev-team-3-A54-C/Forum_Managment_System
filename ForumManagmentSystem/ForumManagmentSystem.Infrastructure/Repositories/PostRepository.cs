﻿using ForumManagmentSystem.Infrastructure.Data;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Infrastructure.Exceptions;
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
            return _context.Posts.ToList();
        }
        public PostDb GetById(Guid id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id) ??
                throw new EntityNotFoundException($"Post with id {id} not found.");
        }
        public PostDb GetByTitle(string title)
        {
            return _context.Posts.FirstOrDefault(p => p.Title == title) ??
                throw new EntityNotFoundException($"Post with title:{title} not found.");
        }
        public PostDb Create(PostDb newPost)
        {
            _context.Posts.Add(newPost);
            return newPost;
        }
        public PostDb Update(Guid id, PostDb post)
        {
            PostDb toUpdate = GetById(id);
            toUpdate.Title = post.Title;
            toUpdate.Content = post.Content;
            return toUpdate;

        }
        public bool Delete(Guid id)
        {
            try
            {
                PostDb toDelete = GetById(id);
                toDelete.IsDeleted = true;
                return true;
            }
            catch(EntityNotFoundException e)
            {
                return false;
            }
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
            return true;
        }
        public bool RemoveLike(PostLikesDb postlikesDB)
        {
            _context.PostLikes.Remove(postlikesDB);
            return false;
        }
        
    }
}
