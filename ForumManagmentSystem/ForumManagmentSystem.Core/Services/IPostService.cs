using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumManagmentSystem.Core.ResponseDTOs;


namespace ForumManagmentSystem.Core.Services
{
    public interface IPostService
    {
        List<PostResponseDTO> GetAll();
        PostResponseDTO Get(int id);
        PostResponseDTO Get(string title);
    }
}
