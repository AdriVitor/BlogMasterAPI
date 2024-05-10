using BlogMaster_Domain.ValueObjects;
using BlogMaster_Infraestructure.AppDbContext;
using BlogMaster_Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogMaster_Infraestructure.Repositories {
    public class CommentRepository : ICommentRepository {
        private readonly Context _context;
        public CommentRepository(Context context) {
            _context = context;
        }

        public async Task Add(Comment comment) {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Comment comment) {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetByPostId(int postId) {
            var commentList = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
            return commentList;
        }
    }
}
