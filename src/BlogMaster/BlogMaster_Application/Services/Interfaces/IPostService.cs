using BlogMaster_Application.DTOs.PostDTO;
using BlogMaster_Domain.Entities;

namespace BlogMaster_Application.Services.Interfaces {
    public interface IPostService {
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetPostsPagination(int page, int quantityItems);
        Task Add(PostDTO postDTO);
        Task Delete(int id);
        Task Update(PostDTO postDTO);
        Task<List<Post>> GetPostsAdvancedSearchPagination(int page, int quantityItems, string parameter);
    }
}
