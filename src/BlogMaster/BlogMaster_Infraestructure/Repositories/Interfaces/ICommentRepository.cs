using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Infraestructure.Repositories.Interfaces {
    public interface ICommentRepository {
        Task Add(Comment comment);
        Task Delete(Comment comment);
        Task<List<Comment>> GetByPostId(int postId);
    }
}
