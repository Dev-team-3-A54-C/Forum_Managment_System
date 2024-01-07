using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;

namespace ForumManagmentSystem.Core.Services.Contracts
{
    public interface ITagService
    {
        IEnumerable<TagResponseDTO> GetAll();
        TagResponseDTO GetByName(string name);
        TagResponseDTO Create(TagDTO tag);
        TagResponseDTO Update(TagDTO tag);
        TagResponseDTO DeleteByName(string name);
    }
}
