using BlogMaster_Domain.ValueObjects;
using BlogMaster_Infraestructure.AppDbContext;
using BlogMaster_Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogMaster_Infraestructure.Repositories {
    public class KeywordRepository : IKeywordRepository {
        private readonly Context _context;
        public KeywordRepository(Context context) {
            _context = context;
        }

        public async Task Add(Keyword keyword) {
            _context.Keyword.Add(keyword);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Keyword keyword) {
            _context.Keyword.Remove(keyword);
            await _context.SaveChangesAsync();
        }

        public async Task<Keyword> Get(Keyword keyword) {
            var keywordFilter = await _context
                                    .Keyword
                                    .FirstOrDefaultAsync(k => k.PostId == keyword.PostId && k.Word.ToUpper() == keyword.Word.ToUpper());

            return keywordFilter;
        }

        public async Task<List<Keyword>> GetAllByPostId(int postId) {
            var keywordList = await _context
                                    .Keyword
                                    .Where(k => k.PostId == postId)
                                    .ToListAsync();

            return keywordList;
        }

        public async Task Update(Keyword keyword) {
            _context.Keyword.Update(keyword);
            await _context.SaveChangesAsync();
        }

        public async Task<List<int>> GetPostIdByKeyword(string word) {
            var postIdList = await _context
                            .Keyword
                            .Where(k=>k.Word == word)
                            .Select(k => k.PostId)
                            .ToListAsync();

            return postIdList;
        }
    }
}
