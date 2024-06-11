using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.Agreggates;

namespace BlogMaster_Application.Services {
    public class PostAgreggateService : IPostAgreggateService {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IKeywordService _keywordService;
        public PostAgreggateService(IPostService postService, ICommentService commentService, IKeywordService keywordService)
        {
            _postService = postService;
            _commentService = commentService;
            _keywordService = keywordService;
        }

        #region Public Methods
        public async Task<PostAgreggate> GetByPostId(int id) {
            var post = await _postService.GetById(id);
            var commentList = await _commentService.GetByPostId(id);
            var keywordList = await _keywordService.GetAllByPostId(id);

            var postAgreggate = new PostAgreggate(post, commentList, keywordList);

            return postAgreggate;
        }

        #endregion
    }
}
