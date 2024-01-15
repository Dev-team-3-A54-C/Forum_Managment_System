using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface ITagService
    {
        IEnumerable<TagResponseDTO> GetAll();
        TagResponseDTO GetByName(string name);
        TagResponseDTO GetById(Guid id);
        TagResponseDTO Create(Guid userId, TagDTO tag);
        TagResponseDTO Update(Guid userId, Guid tagId, TagDTO tag);
        TagResponseDTO Delete(Guid userId, string tagName);
        TagResponseDTO Delete(Guid userId, Guid tagId);
    }
}
