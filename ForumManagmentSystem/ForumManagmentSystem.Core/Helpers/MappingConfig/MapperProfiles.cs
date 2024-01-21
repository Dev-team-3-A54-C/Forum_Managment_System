using AutoMapper;
using ForumManagmentSystem.Core.RequestDTOs;
using ForumManagmentSystem.Core.ResponseDTOs;
using ForumManagmentSystem.Core.ViewModels;
using ForumManagmentSystem.Infrastructure.Data.Models;
using System.Collections.Generic;


namespace ForumManagmentSystem.Core.Helpers.MappingConfig
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()//(IConfigurationProvider config) : base(config) //just to get the error out
        {
            this.CreateMap<PostDb, PostResponseDTO>()
                .ForMember(d => d.Likes, p => p.MapFrom(s => s.LikesCount))
                .ForMember(d => d.CreatedBy, p => p.MapFrom(s => s.User.Username));
            
            this.CreateMap<ReplyDb, PostReplyResponseDTO>()
                .ForMember(d => d.CreatedBy, p => p.MapFrom(s => s.User.Username));
			this.CreateMap<ReplyDb, ReplyResponseDTO>()
                .ForMember(d => d.CreatedBy, p => p.MapFrom(s => s.User.Username))
                .ForMember(d => d.PostTitle, p => p.MapFrom(s => s.Post.Title));
            this.CreateMap<UserDb, UserResponseDTO>();
            this.CreateMap<TagDb, TagResponseDTO>();
            this.CreateMap<PostLikesDb, PostResponseDTO>()
                .ForMember(d => d.ID, p => p.MapFrom(s => s.Post.Id))
                .ForMember(d => d.Title, p => p.MapFrom(s => s.Post.Title))
                .ForMember(d => d.Content, p => p.MapFrom(s => s.Post.Content))
                .ForMember(d => d.Likes, p => p.MapFrom(s => s.Post.LikesCount))
                .ForMember(d => d.CreatedBy, p => p.MapFrom(s => s.Post.CreatedBy))
                .ForMember(d => d.CreatedOn, p => p.MapFrom(s => s.Post.CreatedOn))
                .ForMember(d => d.Replies, p => p.MapFrom(s => s.Post.Replies));

            this.CreateMap<ReplyLikesDb, ReplyResponseDTO>()
                .ForMember(d => d.PostTitle, p => p.MapFrom(s => s.Reply.Post.Title))
                .ForMember(d => d.CreatedBy, p => p.MapFrom(s => s.Reply.User.Username))
                .ForMember(d => d.CreatedOn, p => p.MapFrom(s => s.Reply.CreatedOn))
                .ForMember(d => d.Content, p => p.MapFrom(s => s.Reply.Content));

            this.CreateMap<UserDTO, UserDb>()
                .ForMember(x => x.CreatedOn, d => d.MapFrom(src => DateTime.Now)).ReverseMap();
            //.ReverceMap() creates the same map profile with switched source and destination
            this.CreateMap<PostDTO, PostDb>();
            this.CreateMap<TagDTO, TagDb>();
            this.CreateMap<ReplyDTO, ReplyDb>();

            this.CreateMap<RegisterViewModel, UserDTO>();
            this.CreateMap<PostViewModel, PostDTO>();
            this.CreateMap<CreatePostViewModel, PostDTO>();
            this.CreateMap<EditProfileViewModel, EditUserDTO>();
            this.CreateMap<EditUserDTO, UserDb>();
            this.CreateMap<AddReplyLikeDTO, ReplyLikesDb>();
            this.CreateMap<PostDetailViewModel, PostDTO>();
            this.CreateMap<PostDTO, PostDetailViewModel>();
            this.CreateMap<PostResponseDTO, PostDTO>();
            this.CreateMap<ReplyResponseDTO, ReplyDTO>();


        }
    }
}
