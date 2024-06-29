using DotNet8BlogApiWithResultPattern.BlogSamplesList;
using DotNet8BlogApiWithResultPattern.Models;
using DotNet8BlogApiWithResultPattern.Shared;

namespace DotNet8BlogApiWithResultPattern.Services
{
    public class BlogService : IBlogService
    {
        public Task<Result<IEnumerable<BlogModel>>> GetBlogsAsync()
        {
            //var blog = BlogSimpleList.GetBlogs();
            //if(blog == null)
            //{
            //    return Task.FromResult(Result.Failure<BlogModel>("Blogs are not found"));
            //}
            //return Task.FromResult(Result.Success(blog));

            var blog = BlogSimpleList.GetBlogs();
            return Task.FromResult(Result.Success(blog));
        }
    }
}
