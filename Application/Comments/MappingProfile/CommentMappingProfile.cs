using Application.Comments.Commands.CreateComment;
using Application.Comments.Commands.UpdateComment;
using Application.Comments.Dtos;
using AutoMapper;
using Domain;

namespace Application.Comments.MappingProfile
{
    internal class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<UpdateCommentCommand, Comment>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
