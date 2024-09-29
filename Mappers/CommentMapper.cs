using _1st_Project_Api.Dtos.Comment;
using _1st_Project_Api.Models;
using System.Runtime.CompilerServices;

namespace _1st_Project_Api.Mappers
{
    public static class CommentMapper
    {

        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
                CreatedBy = commentModel.AppUser.UserName
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {
               
                Title = commentDto.Title,
                StockId = stockId,
                Content = commentDto.Content,
              

            };
        }


        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int stockId)
        {
            return new Comment
            {

                Title = commentDto.Title,
               
                Content = commentDto.Content,


            };
        }

    }
}
