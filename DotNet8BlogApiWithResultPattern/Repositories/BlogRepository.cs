using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DotNet8BlogApiWithResultPattern.Repositories
{
    public class BlogRepository
    {
        private readonly AppDbContext _appDbcontext;

        public BlogRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<BlogModel>> GetBlogs()
        {
            return await _appDbcontext.Blogs.ToListAsync();
        }

        public async Task<BlogModel> GetBlog(int blogId)
        {
            return await _appDbcontext.Blogs.FirstOrDefaultAsync(b => b.BlogId == blogId);
        }
        public async Task<BlogModel> CreateBlog(BlogModel reqModel)
        {
            _appDbcontext.Blogs.Add(reqModel);
            await _appDbcontext.SaveChangesAsync();
            return reqModel;
        }
        public async Task UpdateBlogAsync(BlogModel blog)
        {
            _appDbcontext.Entry(blog).State = EntityState.Modified;
            await _appDbcontext.SaveChangesAsync();
        }
        public async Task DeleteBlogAsync(int blogId)
        {
            var blog = await _appDbcontext.Blogs.FindAsync(blogId);
            if (blog != null)
            {
                _appDbcontext.Blogs.Remove(blog);
                await _appDbcontext.SaveChangesAsync();
            }
        }

    }
}
