using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.Exceptions;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;


namespace ForumManagmentSystem.Core.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;
        private readonly IUsersRepository userRepository;

        public TagService(ITagRepository tagRepository, IMapper mapper, IUsersRepository userRepository)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public TagResponseDTO Create(Guid userId, TagDTO tag)
        {
            var user = userRepository.GetById(userId);

            if (!user.IsAdmin)
            {
                throw new UnauthorizedOperationException($"User {user.Username} can not create new tags.");
            }


            if(tagRepository.DoesNameExist(tag.Name).Result)
            {
                throw new NameDuplicationException($"Tag with name {tag.Name} already exist.");
            }


            var tagToAdd = mapper.Map<TagDb>(tag);

            _ = tagRepository.Create(tagToAdd);

            return mapper.Map<TagResponseDTO>(tagToAdd);

        }
        public IEnumerable<TagResponseDTO> GetAll()
        {
            var tags = tagRepository.GetAll().Result.Select(x => mapper.Map<TagResponseDTO>(x));

            return tags;
        }

        public TagResponseDTO GetById(Guid id)
        {
            var tag = tagRepository.GetById(id).Result;

            return mapper.Map<TagResponseDTO>(tag);
        }

        public TagResponseDTO GetByName(string name)
        {
            var tag = tagRepository.GetByName(name).Result;

            return mapper.Map<TagResponseDTO>(tag);
        }

        public TagResponseDTO Update(Guid userId, Guid tagId, TagDTO tag)
        {
            var user = userRepository.GetById(userId);

            if (!user.IsAdmin)
            {
                throw new UnauthorizedOperationException($"User {user.Username} can not create new tags.");
            }

            var newTag = mapper.Map<TagDb>(tag);
            newTag.Id = tagId;

            if (tagRepository.DoesNameExist(tag.Name).Result)
            {
                throw new NameDuplicationException($"Tag with name {tag.Name} already exist.");
            }

            var updatedTag = tagRepository.Update(newTag).Result;

            return mapper.Map<TagResponseDTO>(updatedTag);
        }

        public TagResponseDTO Delete(Guid userId, string name)
        {
            var user = userRepository.GetById(userId);

            if (!user.IsAdmin)
            {
                throw new UnauthorizedOperationException($"User {user.Username} can not create new tags.");
            }

            var tag = tagRepository.Delete(name).Result;

            return mapper.Map<TagResponseDTO>(tag);
        }

        public TagResponseDTO Delete(Guid userId, Guid tagId)
        {
            var user = userRepository.GetById(userId);

            if (!user.IsAdmin)
            {
                throw new UnauthorizedOperationException($"User {user.Username} can not create new tags.");
            }

            var tag = tagRepository.Delete(tagId).Result;

            return mapper.Map<TagResponseDTO>(tag);
        }
    }
}
