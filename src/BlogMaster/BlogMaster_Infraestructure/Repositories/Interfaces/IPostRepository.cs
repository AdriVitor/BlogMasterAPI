using BlogMaster_Domain.Entities;

namespace BlogMaster_Infraestructure.Repositories.Interfaces {
    public interface IPostRepository {
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetPostsPagination(int page, int quantityItems);
        Task<List<Post>> GetPostsAdvancedSearchPagination(int page, int quantityItems, string parameters);
        Task Add(Post post);
        Task Delete(Post post);
        Task Update(Post post);
        Task<List<Post>> GetPostListByAuthorId(int authorId);
    }
}
