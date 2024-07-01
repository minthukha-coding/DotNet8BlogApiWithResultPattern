namespace DotNet8BlogApiWithResultPattern.Services;

public interface IBlogService
{
    Task<Result<IEnumerable<BlogModel>>> GetBlogs();
    Task<Result<BlogModel>> GetBlog(int  blogId);
    Task<Result<BlogModel>> UpdateBlog(BlogModel  reqModel);
    Task<Result<bool>> DeleteBlogAsync(int blogId);
    Task<Result<BlogModel>> CreateBlog(BlogModel reqModel);
}