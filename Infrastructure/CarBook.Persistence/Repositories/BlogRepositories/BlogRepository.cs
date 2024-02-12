using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthorAsync()
        {
            return await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToListAsync();
        }
        
        public async Task<List<Blog>> GetAllBlogsWithAuthorAsync()
        {
            return await _context.Blogs.Include(x => x.Author).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogByAuthorIdAsync(int id)
        {
            return await _context.Blogs.Include(x => x.Author).Where(y => y.BlogID == id).ToListAsync();
        }
    }
}
