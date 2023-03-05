using Application.Posts.Commands.CreatePost;
using Application.Posts.Commands.UpdateDocument;
using Application.Posts.Dtos;
using AutoMapper;
using Domain;

namespace Application.Posts.MappingProfile
{
    internal class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<CreatePostCommand, Post>();
            CreateMap<UpdatePostCommand, Post>()
                .ForMember(p => p.Name, p => p.Condition(p => p.Name != null))
                .ForMember(p => p.Description, p => p.Condition(p => p.Description != null))
            ;
            CreateMap<Post, PostDto>();

        }
    }
}
