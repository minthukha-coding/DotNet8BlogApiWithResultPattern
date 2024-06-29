using DotNet8BlogApiWithResultPattern.BlogSamplesList;
using DotNet8BlogApiWithResultPattern.Models;
using DotNet8BlogApiWithResultPattern.Shared;

namespace DotNet8BlogApiWithResultPattern.Services
{
    public class BlogService : IBlogService
    {
        public Task<Result<IEnumerable<BlogModel>>> GetBlogs()
        {
            var blog = BlogSimpleList.GetBlogs();
            if (blog == null || !blog.Any())
            {
                return Task.FromResult(Result.Failure<IEnumerable<BlogModel>>("No blogs found."));
            }
            return Task.FromResult(Result.Success(blog));
        }
        public Task<Result<BlogModel>> GetBlog(int blogId)
        {
            var blog = BlogSimpleList.GetBlog(blogId);
            if(blog == null)
            {
                return Task.FromResult(Result.Failure<BlogModel>($"Blog with BlogID {blogId} is not found"));
            }
            return Task.FromResult(Result.Success(blog));
        }
        public Task<Result<BlogModel>> UpdateBlog(BlogModel reqModel)
        {
            if(reqModel == null)
            {
                return Task.FromResult(Result.Failure<BlogModel>("ReqModel is required"));
            }
            BlogSimpleList.UpdateBlog(reqModel);
            return Task.FromResult(Result.Success(reqModel));
        }
    }
}