using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface ITagService
    {
        IEnumerable<TagResponseDTO> GetAll();
        TagResponseDTO GetByName(string name);
        TagResponseDTO GetById(Guid id);
        TagResponseDTO Create(TagDTO tag);
        TagResponseDTO Update(Guid id, TagDTO tag);
        TagResponseDTO Delete(string name);
        TagResponseDTO Delete(Guid id);
    }
}
