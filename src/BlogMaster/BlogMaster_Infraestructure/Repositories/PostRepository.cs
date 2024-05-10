﻿using BlogMaster_Domain.Entities;
using BlogMaster_Infraestructure.AppDbContext;
using BlogMaster_Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogMaster_Infraestructure.Repositories {
    public class PostRepository : IPostRepository {
        private readonly Context _context;
        public PostRepository(Context context) {
            _context = context;
        }

        public async Task Add(Post post) {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Post post) {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsPagination(int page, int quantityItems) {
            IEnumerable<Post> postList = await _context
                                        .Posts
                                        .OrderBy(p=>p.PostDate)
                                        .Skip(page)
                                        .Take(quantityItems)
                                        .ToListAsync();

            return postList;
        }

        public async Task<Post> GetById(int id) {
            var post = await _context.Posts.FirstOrDefaultAsync(p=>p.Id == id);
            return post;
        }

        public async Task Update(Post post) {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public Task<List<Post>> GetPostsAdvancedSearchPagination(int page, int quantityItems, string parameter) {
            var parameterTrim = parameter.Trim().ToLower();
            var postList = _context
                         .Posts
                         .Where(p => 
                         (p.Title.Trim().ToLower().Contains(parameterTrim)) || 
                         (p.AuthorId.ToString().Trim().Contains(parameterTrim)) || 
                         (p.Id.ToString().Trim().Contains(parameterTrim)))
                         .Distinct()
                         .Skip(page)
                         .Take(quantityItems)
                         .ToListAsync();

            return postList;
        }
    }
}
