using BlogMaster_Application.DTOs.CommentDTO;
using BlogMaster_Application.Services.Interfaces;
using BlogMaster_Domain.ValueObjects;
using BlogMaster_Infraestructure.Repositories.Interfaces;

namespace BlogMaster_Application.Services {
    public class CommentService : ICommentService {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Add(CommentDTO commentDTO) {
            var comment = commentDTO.ConvertoToComment();

            await _commentRepository.Add(comment);
        }

        public async Task Delete(CommentDTO commentDTO) {
            var comment = commentDTO.ConvertoToComment();

            await _commentRepository.Delete(comment);
        }

        public async Task<List<Comment>> GetByPostId(int postId) {
            var commentList = await _commentRepository.GetByPostId(postId);

            return commentList;
        }
    }
}
