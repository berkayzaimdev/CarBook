using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWithAuthorAsync();
        Task<List<Blog>> GetAllBlogsWithAuthorAsync();
        Task<List<Blog>> GetBlogByAuthorIdAsync(int id);

    }
}
