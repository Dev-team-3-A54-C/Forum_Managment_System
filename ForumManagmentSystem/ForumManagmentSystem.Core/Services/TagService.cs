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

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }

        public TagResponseDTO Create(TagDTO tag)
        {
            if(tagRepository.DoesNameExist(tag.Name).Result)
            {
                throw new NameDuplicationException($"Tag with name {tag.Name} already exist.");
            }


            //TODO: Check if automapper works properly
            var tagToAdd = mapper.Map<TagDb>(tag);

            tagRepository.Create(tagToAdd);

            return mapper.Map<TagResponseDTO>(tagToAdd);

        }
        public IEnumerable<TagResponseDTO> GetAll()
        {
            var tags = tagRepository.GetAll().Result.Select(x => mapper.Map<TagResponseDTO>(x));
            //TODO check if automapper works properly
            return tags;
        }

        public TagResponseDTO GetByName(string name)
        {
            var tag = tagRepository.GetByName(name).Result;
            //TODO check if automapper works properly
            return mapper.Map<TagResponseDTO>(tag);
        }

        public TagResponseDTO Update(Guid id, TagDTO tag)
        {
            var newTag = mapper.Map<TagDb>(tag);
            newTag.Id = id;
            var updatedTag = tagRepository.Update(newTag).Result;

            return mapper.Map<TagResponseDTO>(updatedTag);
        }

        public TagResponseDTO DeleteByName(string name)
        {
            var tag = tagRepository.Delete(name).Result;
            //TODO check if automapper works properly
            return mapper.Map<TagResponseDTO>(tag);
        }

    }
}
