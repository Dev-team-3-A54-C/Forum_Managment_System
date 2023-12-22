using AutoMapper;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Core.Helpers.MappingConfig
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            this.CreateMap<PostDb, PostResponseDTO>()
                .ForMember(d => d.Likes, p => p.MapFrom(s => s.LikesCount));
        }
    }
}
