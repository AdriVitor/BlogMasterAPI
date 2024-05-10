using BlogMaster_Application.DTOs.PostDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Entities;
using BlogMaster_Infraestructure.Repositories.Interfaces;

namespace BlogMaster_Application.Services {
    public class PostService : IPostService {
        private readonly IPostRepository _postRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IKeywordRepository _keywordRepository;
        public PostService(IPostRepository postRepository, IAuthorRepository authorRepository, IKeywordRepository keywordRepository)
        {
            _postRepository = postRepository;
            _authorRepository = authorRepository;
            _keywordRepository = keywordRepository;
        }

        public async Task Add(PostDTO postDTO) {
            var post = postDTO.ConvertToPost();

            await _postRepository.Add(post);
        }

        public async Task Delete(int id) {
            var post = await GetById(id);

            await _postRepository.Delete(post);
        }

        public Task<Post> GetById(int id) {
            var post = _postRepository.GetById(id);
            if (post is null) {
                return null;
            }

            return post;
        }

        public async Task<List<Post>> GetPostsAdvancedSearchPagination(int page, int quantityItems, string parameter) {
            var postListAdvancedSearch = await _postRepository.GetPostsAdvancedSearchPagination(page, quantityItems, parameter);

            return postListAdvancedSearch;
        }

        public async Task<IEnumerable<Post>> GetPostsPagination(int page, int quantityItems) {
            var postListPagination = await _postRepository.GetPostsPagination(page, quantityItems);

            return postListPagination;
        }

        public async Task Update(PostDTO postDTO) {
            var post = postDTO.ConvertToPost();

            await _postRepository.Update(post);
        }
    }
}
