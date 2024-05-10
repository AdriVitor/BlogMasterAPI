using BlogMaster_Application.DTOs.CommentDTO;
using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Application.Services.Interfaces {
    public interface ICommentService {
        Task Add(CommentDTO commentDTO);
        Task Delete(CommentDTO commentDTO);
        Task<List<Comment>> GetByPostId(int postId);
    }
}
