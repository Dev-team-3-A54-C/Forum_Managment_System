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

        public TagResponseDTO DeleteByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagResponseDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TagResponseDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public TagResponseDTO Update(TagDTO tag)
        {
            throw new NotImplementedException();
        }
    }
}
