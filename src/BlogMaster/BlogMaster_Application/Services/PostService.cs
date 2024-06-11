using BlogMaster_Application.DTOs.PostDTO;
using BlogMaster_Application.Extensions;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Entities;
using BlogMaster_Infraestructure.Repositories.Interfaces;

namespace BlogMaster_Application.Services {
    public class PostService : IPostService {
        private readonly IPostRepository _postRepository;
        private readonly ICacheRepository _cacheRepository;
        private string prefixCacheKey = "postsAuthorId:";

        #region Public Methods
        public PostService(IPostRepository postRepository, ICacheRepository cacheRepository)
        {
            _postRepository = postRepository;
            _cacheRepository = cacheRepository;
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
            UpdatePostDTOCache(postDTO);
        }

        public async Task<List<Post>> GetPostListByAuthorId(int authorId, int page, int quantityItems)
        {
            List<Post> posts = new();

            string cacheKey = GenerateCacheKey(authorId.ToString());
            var postListCache = _cacheRepository.GetList<PostDTO>(cacheKey);
            if (!postListCache.Any())
            {
                posts = await FetchAndCacheAuthorPosts(posts, authorId, cacheKey);

                return posts;
            }

            posts = postListCache.ConvertAll(p => p.ConvertToPost());
            posts = posts.ImplementPagination<Post>(page, quantityItems);

            return posts;
        }

        #endregion

        #region Private Methods

        private void UpdatePostDTOCache(PostDTO postDTO)
        {
            var cacheKey = GenerateCacheKey(postDTO.AuthorId.ToString());
            var postListCache = _cacheRepository.GetList<PostDTO>(cacheKey);
            var postFilter = postListCache.SingleOrDefault(p => p.Id == postDTO.Id);
            if (postFilter is not null)
            {
                _cacheRepository.Set(cacheKey, postFilter);
            }
        }

        private string GenerateCacheKey(string keyAuthorId)
        {
            keyAuthorId = keyAuthorId.ToString();
            string cacheKey = prefixCacheKey + keyAuthorId;

            return cacheKey;
        }

        private async Task<List<Post>> FetchAndCacheAuthorPosts(List<Post> posts, int authorId, string cacheKey)
        {
            posts = await _postRepository.GetPostListByAuthorId(authorId);

            if (!posts.Any())
            {
                throw new Exception("Não existe post vinculado a esse autor");
            }

            _cacheRepository.SetList(cacheKey, posts);

            return posts;
        }

        #endregion
    }
}
