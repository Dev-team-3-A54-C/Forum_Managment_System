﻿using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Infrastructure.Data.Models;


namespace ForumManagmentSystem.Core.Helpers.MappingConfig
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()//(IConfigurationProvider config) : base(config) //just to get the error out
        {
            this.CreateMap<PostDb, PostResponseDTO>()
                .ForMember(d => d.Likes, p => p.MapFrom(s => s.LikesCount));
            this.CreateMap<ReplyDb, ReplyResponseDTO>()
                .ForMember(d => d.CreatedBy, p => p.MapFrom(s => s.User.Username));
            this.CreateMap<UserDb, UserResponseDTO>();
            this.CreateMap<TagDb, TagResponseDTO>();

            this.CreateMap<UserDTO, UserDb>()
                .ForMember(x => x.CreatedOn, d => d.MapFrom(src => DateTime.Now)).ReverseMap();
            //.ReverceMap() creates the same map profile with switched source and destination
            this.CreateMap<PostDTO, PostDb>();
            this.CreateMap<TagDTO, TagDb>();
            this.CreateMap<ReplyDTO, ReplyDb>();
            //TODO: check if the maps are right
        }
    }
}
